using Measurement;
using MessageLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TReport.TData;
using TReport.TRForms;

namespace TReport.TREntities
{
    public class TREnergy:TR
    {
        private eventID eventID = eventID.TR_TREnergy;

        private FormEnergyFlowDay formEnergyFlowDay;
        public FormEnergyFlowDay ReportEnergyFlowDay { get { return this.formEnergyFlowDay; } }
        private FormEnergyDay formEnergyDay;
        public FormEnergyDay ReportEnergyDay { get { return this.formEnergyDay; } }

        public TREnergy(trObj trObj) : base(trObj) { GetForms(); }

        public TREnergy(trObj[] trObjs) : base(trObjs) {  GetForms(); }

        public TREnergy(List<trObj> trObjs) : base(trObjs) {  GetForms(); }

        public void GetForms() { 
            
            this.formEnergyDay = base.forms.GetForm<FormEnergyDay>();
            this.formEnergyFlowDay = base.forms.GetForm <FormEnergyFlowDay>(); 
            //this.formEnergyDay = base.forms.GetForm<FormEnergyDay>(@"D:\Мои документы\Visual Studio 2013\Projects\Work\TReports\TReport\XMLForms\EnergyDay.xml");
            //this.formEnergyFlowDay = base.forms.GetForm <FormEnergyFlowDay>(@"D:\Мои документы\Visual Studio 2013\Projects\Work\TReports\TReport\XMLForms\FlowEnergyDay.xml"); 
       

        }

        #region Energyday
        /// <summary>
        /// Получить отчет среднесуточные значения
        /// </summary>
        /// <param name="date"></param>
        public void GetEnergyDay(DateTime date) {
            if (this.formEnergyDay == null) return;
            // получим список тегов из формы, с учетом объектов
            List<int> lists = base.forms.GetIDTags(this.formEnergyDay, base.trObjs.Cast<int>().Select(o => o).ToArray());
            // получим переменные для запроса на выборку
            TData.TDataSources t_data = new TData.TDataSources();
            SQLParameter[] sqlpars = new SQLParameter[] { 
                new SQLParameter() { where = type_where.DATE, value = date } 
            };
            // получим значения тегов после выборки
            List<DataMeasurement> list_data_measurement = t_data.GetDataMeasurement(lists, sqlpars);
            // Заполним значениями форму
            foreach (GroupEnergyDay ged in this.formEnergyDay.Groups.OrderBy(g=>g.position)) {
                foreach (TypeEnergyDay ted in ged.Types.OrderBy(t => t.position)) {
                    foreach (ItemEnergyDay ied in ted.Items.OrderBy(i => i.position)) {
                        foreach (trObj obj in base.trObjs) {
                            ItemObject io = ied.ItemObject.Find(o => o.trobj == (int)obj);
                            if (io != null) {
                                DBValueMeasurement val = list_data_measurement.Find(m => m.id == io.parameter.tag).value_measurement;
                                val = val != null && io.parameter.multiplier != null ? val.ConvertMultiplier((Multiplier)io.parameter.multiplier) : val;
                                io.parameter.value = val;
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region EnergyFlowDay
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        public void GetEnergyFlowDay(DateTime date)
        {
            if (this.formEnergyFlowDay == null) return;
            // получим список тегов из формы, с учетом объектов
            List<int> lists = base.forms.GetIDTags(this.formEnergyFlowDay, base.trObjs.Cast<int>().Select(o => o).ToArray());
            // получим переменные для запроса на выборку
            TData.TDataSources t_data = new TData.TDataSources();
           SQLParameter[] sqlpars =  new SQLParameter[] { 
                new SQLParameter() { where = type_where.DATE, value = date } 
            };
           // получим значения тегов после выборки
           List<DataMeasurement> list_data_measurement = t_data.GetDataMeasurement(lists, sqlpars);
           // Заполним значениями форму
           foreach (GroupEnergyFlowDay ged in this.formEnergyFlowDay.Groups.OrderBy(g => g.position))
           {
               foreach (TypeEnergyFlowDay ted in ged.Types.OrderBy(t => t.position))
               {
                   foreach (ItemEnergyFlowDay item in ted.Items.OrderBy(i => i.position))
                   {
                       foreach (trObj obj in base.trObjs)
                       {

                           try {
                               //Преобразование 
                               DBFlowValue flow = item.flow != null && item.flow.tag > 0 ? (DBFlowValue)list_data_measurement.Find(m => m.id == item.flow.tag).value_measurement : null;
                               item.flow.value = flow != null && item.flow.multiplier != null ? (DBFlowValue)flow.ConvertMultiplier((Multiplier)item.flow.multiplier) : flow;

                               DBTempValue avg_temp = item.avg_temp != null && item.avg_temp.tag > 0 ? (DBTempValue)list_data_measurement.Find(m => m.id == item.avg_temp.tag).value_measurement : null;
                               item.avg_temp.value = avg_temp != null && item.avg_temp.multiplier != null ? (DBTempValue)avg_temp.ConvertMultiplier((Multiplier)item.avg_temp.multiplier) : avg_temp;

                               DBPressureValue avg_pressure = item.avg_pressure != null && item.avg_pressure.tag > 0 ? (DBPressureValue)list_data_measurement.Find(m => m.id == item.avg_pressure.tag).value_measurement : null;
                               item.avg_pressure.value = avg_pressure != null && item.avg_pressure.multiplier != null ? (DBPressureValue)avg_pressure.ConvertMultiplier((Multiplier)item.avg_pressure.multiplier) : avg_pressure;

                               DBPlanimetricValue planimetric = item.planimetric != null && item.planimetric.tag > 0 ? (DBPlanimetricValue)list_data_measurement.Find(m => m.id == item.planimetric.tag).value_measurement : null;
                               item.planimetric.value = planimetric != null && item.planimetric.multiplier != null ? (DBPlanimetricValue)planimetric.ConvertMultiplier((Multiplier)item.planimetric.multiplier) : planimetric;

                               DBFlowValue pr_flow = item.pr_flow != null && item.pr_flow.tag > 0 ? (DBFlowValue)list_data_measurement.Find(m => m.id == item.pr_flow.tag).value_measurement : null;
                               item.pr_flow.value = pr_flow != null && item.pr_flow.multiplier != null ? (DBFlowValue)pr_flow.ConvertMultiplier((Multiplier)item.pr_flow.multiplier) : pr_flow;

                               DBTimeValue time_norm = item.time_norm != null && item.time_norm.tag > 0 ? (DBTimeValue)list_data_measurement.Find(m => m.id == item.time_norm.tag).value_measurement : null;
                               item.time_norm.value = time_norm != null && item.time_norm.multiplier != null ? (DBTimeValue)time_norm.ConvertMultiplier((Multiplier)item.time_norm.multiplier) : time_norm;

                               DBTimeValue time_max = item.time_max != null && item.time_max.tag > 0 ? (DBTimeValue)list_data_measurement.Find(m => m.id == item.time_max.tag).value_measurement : null;
                               item.time_max.value = time_max != null && item.time_max.multiplier != null ? (DBTimeValue)time_max.ConvertMultiplier((Multiplier)item.time_max.multiplier) : time_max;
                           }
                           catch (Exception e)
                           {
                               e.WriteError(String.Format("Ошибка полученния параметра :{0}, объект: {1}", item.name, item.trobj), eventID);
                           }
                       }
                   }
               }
           }
        }
        #endregion
    }
}
