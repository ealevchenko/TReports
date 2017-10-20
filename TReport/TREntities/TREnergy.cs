using EFTReports.Concrete; //TODO: Убрать переделав отчет flowenergyday
//using EFTReports.Entities;
using Measurement;
using MessageLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TReport.App_LocalResources;
using TReport.TData;
using TReport.TRForms;

namespace TReport.TREntities
{
    public class TREnergy:TR
    {
        private eventID eventID = eventID.TR_TREnergy;

        public class EnergyFlowValueEntity
        {
            public trObj trObj { get; set; }
            public string Object { get { return  ((trObj)this.trObj).ToString().GetResources(); } }
            public string name { get; set; }
            public int position { get; set; } 
            public DBFlowValue flow { get; set; }
            public DBTempValue avg_temp { get; set; }
            public DBPressureValue avg_pressure { get; set; }
            public DBPlanimetricValue planimetric { get; set; }
            public DBFlowValue pr_flow { get; set; }
            public DBTimeValue time_norm { get; set; }
            public DBTimeValue time_max { get; set; }
            public EnergyFlowValueEntity()
            {

            }
        }

        public class TypeEnergyFlowValueEntity
        {
            public string name { get; set; }
            public int position { get; set; }
            public List<EnergyFlowValueEntity> list_type_flow = new List<EnergyFlowValueEntity>();
            public TypeEnergyFlowValueEntity() { }
        }

        public class GroupEnergyFlowValueEntity
        {
            public string name { get; set; }
            public int position { get; set; }
            public List<TypeEnergyFlowValueEntity> list_type = new List<TypeEnergyFlowValueEntity>();
            public GroupEnergyFlowValueEntity() { }
        }

        private EnergyFlowDay formEnergyFlowDay;
        private FormEnergyDay formEnergyDay;
        public FormEnergyDay ReportEnergyDay { get { return this.formEnergyDay; } }

        private List<GroupEnergyFlowValueEntity> list_energy_flow_day = new List<GroupEnergyFlowValueEntity>();
        public List<GroupEnergyFlowValueEntity> ListFlowDay { get { return this.list_energy_flow_day; } }

        public TREnergy(trObj trObj) : base(trObj) { GetForms(); }

        public TREnergy(trObj[] trObjs) : base(trObjs) {  GetForms(); }

        public TREnergy(List<trObj> trObjs) : base(trObjs) {  GetForms(); }

        public void GetForms() { 
            
            //this.formEnergyFlowDay = tr_forms.GetFormEnergyFlowDay();
            //this.formEnergyDay = tr_forms.GetForm<FormEnergyDay>();
            this.formEnergyDay = base.forms.GetForm<FormEnergyDay>(@"D:\Мои документы\Visual Studio 2013\Projects\Work\TReports\TReport\XMLForms\EnergyDay.xml");
            // десериализация
            //this.formEnergyFlowDay = tr_forms.GetFormEnergyFlowDay(@"D:\Мои документы\Visual Studio 2013\Projects\Work\TechnologicalReports\TReports\TReport\XMLForms\FlowEnergyDay.xml");            
            this.formEnergyFlowDay = base.forms.GetFormEnergyFlowDay(@"D:\Мои документы\Visual Studio 2013\Projects\Work\TReports\TReport\XMLForms\FlowEnergyDay.xml");            

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
        /// Получить список тегов для отчета расход за сутки
        /// </summary>
        /// <returns></returns>
        private List<int> GetIDTagsEnergyFlowDay() {
            List<int> list = new List<int>();
            if (this.formEnergyFlowDay == null) return list;
            foreach (GroupEnergyFlowDay g in this.formEnergyFlowDay.Groups)
            {
                foreach (TypeEnergyFlowDay t in g.Types) {
                    foreach (ItemEnergyFlowDay i in t.Items) {
                        if (base.trObjs.Find(o => o == (trObj)i.trobj) > 0) // если есть в списке разрешенных
                        {
                            if (i.flow != null) list.Add((int)i.flow.tag);
                            if (i.avg_temp != null) list.Add((int)i.avg_temp.tag);
                            if (i.avg_pressure != null) list.Add((int)i.avg_pressure.tag);
                            if (i.planimetric != null) list.Add((int)i.planimetric.tag);
                            if (i.pr_flow != null) list.Add((int)i.pr_flow.tag);
                            if (i.time_norm != null) list.Add((int)i.time_norm.tag);
                            if (i.time_max != null) list.Add((int)i.time_max.tag);

                        }
                    }
                }
            }  
            return list;
        }

        public void GetEnergyFlowDay(DateTime date)
        {
            TData.TDataSources t_data = new TData.TDataSources();
           SQLParameter[] sqlpars =  new SQLParameter[] { 
                new SQLParameter() { where = type_where.DATE, value = date } 
            };
           List<DataMeasurement> list_data_measurement = t_data.GetDataMeasurement(GetIDTagsEnergyFlowDay(), sqlpars);


            EFEnergyReports e_reports = new EFEnergyReports();
            if (this.formEnergyFlowDay == null) return;
            foreach (GroupEnergyFlowDay g in this.formEnergyFlowDay.Groups.OrderBy(g=>g.position))
            {
                GroupEnergyFlowValueEntity group = new GroupEnergyFlowValueEntity()
                {
                    name = e_reports.GetNameGroupEnergyCulture(g.id_group),
                    position = 0
                };
                foreach (TypeEnergyFlowDay t in g.Types.OrderBy(t=>t.position))
                {
                    TypeEnergyFlowValueEntity type = new TypeEnergyFlowValueEntity()
                    {
                        name = e_reports.GetNameTypeEnergyCulture(t.id_type),
                        position = 0
                    };
                    foreach (ItemEnergyFlowDay item in t.Items.OrderBy(i=>i.position))
                    {
                        if (base.trObjs.Find(o => o == (trObj)item.trobj) > 0) // если есть в списке разрешенных
                        {
                            try
                            {
                                //Преобразование 
                                DBFlowValue flow = item.flow != null && item.flow.tag >0 ? (DBFlowValue)list_data_measurement.Find(m => m.id == item.flow.tag).value_measurement : null;
                                flow = flow != null && item.flow.multiplier != null ? (DBFlowValue)flow.ConvertMultiplier((Multiplier)item.flow.multiplier) : flow;

                                DBTempValue avg_temp = item.avg_temp != null && item.avg_temp.tag > 0 ? (DBTempValue)list_data_measurement.Find(m => m.id == item.avg_temp.tag).value_measurement : null;
                                avg_temp = avg_temp != null && item.avg_temp.multiplier != null ? (DBTempValue)avg_temp.ConvertMultiplier((Multiplier)item.avg_temp.multiplier) : avg_temp;

                                DBPressureValue avg_pressure = item.avg_pressure != null && item.avg_pressure.tag > 0 ? (DBPressureValue)list_data_measurement.Find(m => m.id == item.avg_pressure.tag).value_measurement : null;
                                avg_pressure = avg_pressure != null && item.avg_pressure.multiplier != null ? (DBPressureValue)avg_pressure.ConvertMultiplier((Multiplier)item.avg_pressure.multiplier) : avg_pressure;

                                DBPlanimetricValue planimetric = item.planimetric != null && item.planimetric.tag > 0 ? (DBPlanimetricValue)list_data_measurement.Find(m => m.id == item.planimetric.tag).value_measurement : null;
                                planimetric = planimetric != null && item.planimetric.multiplier != null ? (DBPlanimetricValue)planimetric.ConvertMultiplier((Multiplier)item.planimetric.multiplier) : planimetric;

                                DBFlowValue pr_flow = item.pr_flow != null && item.pr_flow.tag > 0 ? (DBFlowValue)list_data_measurement.Find(m => m.id == item.pr_flow.tag).value_measurement : null;
                                pr_flow = pr_flow != null && item.pr_flow.multiplier != null ? (DBFlowValue)pr_flow.ConvertMultiplier((Multiplier)item.pr_flow.multiplier) : pr_flow;

                                DBTimeValue time_norm = item.time_norm != null && item.time_norm.tag > 0 ? (DBTimeValue)list_data_measurement.Find(m => m.id == item.time_norm.tag).value_measurement : null;
                                time_norm = time_norm != null && item.time_norm.multiplier != null ? (DBTimeValue)time_norm.ConvertMultiplier((Multiplier)item.time_norm.multiplier) : time_norm;

                                DBTimeValue time_max = item.time_max != null && item.time_max.tag > 0 ? (DBTimeValue)list_data_measurement.Find(m => m.id == item.time_max.tag).value_measurement : null;
                                time_max = time_max != null && item.time_max.multiplier != null ? (DBTimeValue)time_max.ConvertMultiplier((Multiplier)item.time_max.multiplier) : time_max;

                                EnergyFlowValueEntity ef = new EnergyFlowValueEntity()
                                 {
                                     name = item.name_energy,
                                     trObj = (trObj)item.trobj,
                                     position = item.position,
                                     flow = flow,
                                     avg_temp = avg_temp,
                                     avg_pressure = avg_pressure,
                                     planimetric = planimetric,
                                     pr_flow = pr_flow,
                                     time_norm = time_norm,
                                     time_max = time_max,
                                 };
                                type.list_type_flow.Add(ef);
                            }
                            catch (Exception e)
                            {
                                e.WriteError(String.Format("Ошибка формирования строки отчета. Параметр :{0}, объект: {1}", item.name_energy_ru, item.trobj), eventID);
                                type.list_type_flow.Add(new EnergyFlowValueEntity()
                                {
                                    name = item.name_energy,
                                    trObj = (trObj)item.trobj,
                                    position = item.position,
                                });
                            }
                        }
                    }
                    group.list_type.Add(type);
                }
                this.list_energy_flow_day.Add(group); // Добавим группу
            }
        }

        #endregion
    }
}
