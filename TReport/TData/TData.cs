using EFBF8.DataSet;
using EFBF9.DataSet;
using MessageLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TReport.TData.DataSet;
using TReport.TData.Interfaces;

namespace TReport.TData
{
    /// <summary>
    /// Класс формирования набора данных для TReport из баз данных технологических серверов (EFBF7,EFBF8,EFBF9...)
    /// </summary>
    public class TData
    {
        private eventID eventID = eventID.TData;

        public TData() { }

        #region EnergySutki
        /// <summary>
        /// Получить набор данных учет энергоресурсов за сутки по ДП-9 за указанную дату
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public bf9_DataEnergySutki GetBF9EnergySutki(DateTime date)
        {
            try
            {
                EFBF9.Concrete.EFBF9 ef = new EFBF9.Concrete.EFBF9();
                List<bf9_EnergySutki> list = null;
                list = ef.GetBF9EnergySutki(date);
                return (list != null && list.Count() > 0) ? new bf9_DataEnergySutki(list[0]) : new bf9_DataEnergySutki(new bf9_EnergySutki());
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetBF9EnergySutki(date={0})", date), eventID);
                return new bf9_DataEnergySutki(new bf9_EnergySutki());
            }
        }
        /// <summary>
        /// Получить набор данных учет энергоресурсов за сутки по ПУТ ДП-9 за указанную дату
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public bf9_DataEnergySutkiPSI GetBF9EnergySutkiPSI(DateTime date)
        {
            try
            {
                EFBF9.Concrete.EFBF9 ef = new EFBF9.Concrete.EFBF9();
                List<bf9_EnergySutkiPSI> list = null;
                list = ef.GetBF9EnergySutkiPSI(date);
                return (list != null && list.Count() > 0) ? new bf9_DataEnergySutkiPSI(list[0]) : new bf9_DataEnergySutkiPSI(new bf9_EnergySutkiPSI());
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetBF9EnergySutkiPSI(date={0})", date), eventID);
                return new bf9_DataEnergySutkiPSI(new bf9_EnergySutkiPSI());
            }
        }
        /// <summary>
        /// Получить набор данных учет энергоресурсов за сутки по ДП-8 за указанную дату
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public bf8_DataEnergySutki GetBF8EnergySutki(DateTime date)
        {
            try
            {
                EFBF8.Concrete.EFBF8 ef = new EFBF8.Concrete.EFBF8();
                List<bf8_EnergySutki> list = null;
                list = ef.GetBF8EnergySutki(date);
                return (list != null && list.Count() > 0) ? new bf8_DataEnergySutki(list[0]) : new  bf8_DataEnergySutki(new bf8_EnergySutki()); 
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetBF8EnergySutki(date={0})", date), eventID);
                return new bf8_DataEnergySutki(new bf8_EnergySutki()); 
            }
        }
        /// <summary>
        /// Вернуть значения энергоресурсов за сутки за указанную дату по указанному объекту
        /// </summary>
        /// <param name="date"></param>
        /// <param name="trobj"></param>
        /// <returns></returns>
        public object GetEnergySutkiObject(DateTime date, trObj trobj)
        {
            try
            {
                switch (trobj)
                {
                    case trObj.dc2_dp9:
                        return GetBF9EnergySutki(date);
                    case trObj.dc2_dp9_pci: 
                        return GetBF9EnergySutkiPSI(date);
                    case trObj.dc1_dp8:
                        return GetBF8EnergySutki(date);
                    default: return null;
                }
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetEnergySutkiObject(date={0}, trobj={1})", date, trobj.ToString()), eventID);
                return null;
            }

        }

        #endregion


    }
}
