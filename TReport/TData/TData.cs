using EFBF8.DataSet;
using EFBF9.DataSet;
using EFTReports.Concrete;
using EFTReports.Entities;
using Measurement;
using MessageLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TReport.TData
{
    public class DataMeasurement{
        public int id { get; set; }
        public int id_dataset { get; set; }
        public DBValueMeasurement value_measurement { get; set; }
    }
    
    /// <summary>
    /// Класс формирования набора данных для TReport из баз данных технологических серверов (EFBF7,EFBF8,EFBF9...)
    /// </summary>
    public class TData
    {
        private eventID eventID = eventID.TData;

        public TData() { }
        /// <summary>
        /// Получить объект с данными Энергосутки ДП-9 по указаному dataset за указаный период
        /// </summary>
        /// <param name="date"></param>
        /// <param name="sp"></param>
        /// <returns></returns>
        public bf9_EnergySutki GetBF9EnergyDay(DateTime date, string sp)
        {
            try
            {
                EFBF9.Concrete.EFBF9 ef = new EFBF9.Concrete.EFBF9();
                List<bf9_EnergySutki> list = null;
                list = ef.GetBF9EnergySutki(date, sp);
                return (list != null && list.Count() > 0) ? list[0] : new bf9_EnergySutki();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetBF9EnergyDay(date={0}, sp={1})", date, sp), eventID);
                return new bf9_EnergySutki();
            }
        }

        public bf9_EnergySutkiPSI GetBF9EnergyDayPSI(DateTime date, string sp)
        {
            try
            {
                EFBF9.Concrete.EFBF9 ef = new EFBF9.Concrete.EFBF9();
                List<bf9_EnergySutkiPSI> list = null;
                list = ef.GetBF9EnergySutkiPSI(date, sp);
                return (list != null && list.Count() > 0) ? list[0] : new bf9_EnergySutkiPSI();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetBF9EnergyDayPSI(date={0}, sp={1})", date, sp), eventID);
                return new bf9_EnergySutkiPSI();
            }
        }

        public bf8_EnergySutki GetBF8EnergyDay(DateTime date, string sp)
        {
            try
            {
                EFBF8.Concrete.EFBF8 ef = new EFBF8.Concrete.EFBF8();
                List<bf8_EnergySutki> list = null;
                list = ef.GetBF8EnergySutki(date, sp);
                return (list != null && list.Count() > 0) ? list[0] : new bf8_EnergySutki();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetBF8EnergyDay(date={0}, sp={1})", date, sp), eventID);
                return new bf8_EnergySutki();
            }
        }

        /// <summary>
        /// Получить объект с данными по указаному dataset за указаный период
        /// </summary>
        /// <param name="date"></param>
        /// <param name="id_dataset"></param>
        /// <returns></returns>
        public object GetDataObject(DateTime date, int id_dataset)
        {
            try
            {
                EFDataSet efds = new EFDataSet();
                TRDataSet trds = efds.GetDataSet(id_dataset);
                switch (trds.id)
                {
                    case 1: return GetBF9EnergyDay(date, trds.dataset1);
                    case 2: return GetBF9EnergyDayPSI(date, trds.dataset1);
                    case 3: return GetBF8EnergyDay(date, trds.dataset1);
                    //case 4: return GetBF7EnergyDay(date, trds.dataset1);
                    //case 5: return GetBF6EnergyDay(date, trds.dataset1);
                    //TODO: Доработать вызов DataObject-ов в базе храним методы и автоматически вызываем
                    default: return null;
                }
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetEnergySutkiObject(date={0}, id_dataset={1})", date, id_dataset), eventID);
                return null;
            }

        }
        /// <summary>
        /// Вернуть список DataMeasurement по указаным id TRTags за указаную дату 
        /// </summary>
        /// <param name="list_id"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<DataMeasurement> GetDataMeasurement(List<int> list_id, DateTime date) {
            List<DataMeasurement> list = new List<DataMeasurement>();
            EFDataSet efds = new EFDataSet();
            List<TRTags> list_tags = efds.GetTRTags(list_id.ToArray()).ToList();
            List<IGrouping<int, TRTags>> result = list_tags.GroupBy(t => t.id_dataset).ToList();
            foreach (IGrouping<int, TRTags> ds in result) {
                object data = GetDataObject(date, ds.Key);

                FieldInfo[] myFieldInfo;
                myFieldInfo = data.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                foreach (TRTags tg in ds) {
                    FieldInfo fi = myFieldInfo.ToList().Find(f => f.Name == "<" + tg.tag + ">k__BackingField");
                    //Type type = fi.GetValue(data).GetType();
                    //string val = fi.GetValue(data).ToString();
                    //object val = fi.GetValue(data);
                    list.Add(new DataMeasurement() { 
                        id = tg.id, 
                        id_dataset = tg.id_dataset,
                        value_measurement = ((TypeMeasurement)tg.type_measurement).GetDBValueMeasurement(fi.GetValue(data), tg.tag, "", tg.unit, (Multiplier)tg.multiplier)
                    });
                }
            }
            return list;
        }
    }
}
