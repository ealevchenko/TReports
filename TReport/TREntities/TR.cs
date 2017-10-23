using Measurement;
using MessageLog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using TReport.App_LocalResources;
using TReport.TData;
using TReport.TRForms;

namespace TReport.TREntities
{

    public class TR
    {
        private eventID eventID = eventID.TR;
        
        protected TRForm forms = new TRForm();
        protected List<trObj> trObjs = new List<trObj>();

        public TR(trObj trObj)
        {
            this.trObjs.Add(trObj);
        }

        public TR(trObj[] trObjs) {
            this.trObjs = trObjs.ToList();
        }

        public TR(List<trObj> trObjs) {
            this.trObjs = trObjs;
        }

        /// <summary>
        /// Получить строку с учетом культуры
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetResource(string key)
        {
            ResourceManager resourceManager = new ResourceManager(typeof(Resources));
            return resourceManager.GetString(key, CultureInfo.CurrentCulture);
        }

        public void GetFormValue(DateTime date, Form fm)
        {
            if (fm == null) return;
            // получим список тегов из формы, с учетом объектов
            List<int> lists = this.forms.GetIDTags(fm, this.trObjs.Cast<int>().Select(o => o).ToArray());
            // получим переменные для запроса на выборку
            TData.TDataSources t_data = new TData.TDataSources();
            SQLParameter[] sqlpars = new SQLParameter[] { 
                new SQLParameter() { where = type_where.DATE, value = date } 
            };
            // получим значения тегов после выборки
            List<DataMeasurement> list_data_measurement = t_data.GetDataMeasurement(lists, sqlpars);
            // Заполним значениями форму
            foreach (Group ged in fm.Groups.OrderBy(g => g.position))
            {
                foreach (TReport.TRForms.Type ted in ged.Types.OrderBy(t => t.position))
                {
                    foreach (Item item in ted.Items.OrderBy(i => i.position))
                    {
                        foreach (ItemObject io in item.ItemObjects.OrderBy(o => o.trobj))
                        {
                            trObj obj = this.trObjs.Find(o => o == (trObj)io.trobj);
                            if (obj != trObj.not)
                            {
                                foreach (ItemValue iv in io.ItemValues)
                                {
                                    foreach (Value val in iv.Values)
                                    {
                                        try
                                        {
                                            DBValueMeasurement param = val != null && val.tag > 0 ? (DBValueMeasurement)list_data_measurement.Find(m => m.id == val.tag).value_measurement : null;
                                            val.value = param != null && val.multiplier != null ? (DBValueMeasurement)param.ConvertMultiplier((Multiplier)val.multiplier) : param;

                                        }
                                        catch (Exception e)
                                        {
                                            e.WriteError(String.Format("Ошибка полученния параметра :{0}, объект: {1}, tag: {2}", item.name, io.Object, val.tag), eventID);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                item.ItemObjects.Remove(io);  // Удалить объект 
                            }
                        }
                    }
                }
            }
        }
    }
}
