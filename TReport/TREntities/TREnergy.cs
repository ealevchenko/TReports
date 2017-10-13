using EFTReports.Concrete;
using EFTReports.Entities;
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

        private TReport.TREntities.TRForms.EnergyFlowDay formEnergyFlowDay;

        private List<GroupEnergyFlowValueEntity> list_energy_flow_day = new List<GroupEnergyFlowValueEntity>();
        public List<GroupEnergyFlowValueEntity> ListFlowDay { get { return this.list_energy_flow_day; } }

        public TREnergy(trObj trObj) : base(trObj) { GetForms(); }

        public TREnergy(trObj[] trObjs) : base(trObjs) {  GetForms(); }

        public TREnergy(List<trObj> trObjs) : base(trObjs) {  GetForms(); }

        public void GetForms() { 
            TRForms tr_forms = new TRForms();
            this.formEnergyFlowDay = tr_forms.GetFormEnergyFlowDay();
            // десериализация
            //this.formEnergyFlowDay = tr_forms.GetFormEnergyFlowDay(@"D:\Мои документы\Visual Studio 2013\Projects\Work\TechnologicalReports\TReports\TReport\XMLForms\FlowEnergyDay.xml");            
            //this.formEnergyFlowDay = tr_forms.GetFormEnergyFlowDay(@"D:\Мои документы\Visual Studio 2013\Projects\Work\TReports\TReport\XMLForms\FlowEnergyDay.xml");            

        }

        /// <summary>
        /// Получить список тегов для отчета расход за сутки
        /// </summary>
        /// <returns></returns>
        private List<int> GetIDTagsEnergyFlowDay() {
            List<int> list = new List<int>();

            foreach (TReport.TREntities.TRForms.GroupEnergyFlowDay g in this.formEnergyFlowDay.Groups)
            {
                foreach (TReport.TREntities.TRForms.TypeEnergyFlowDay t in g.Types) {
                    foreach (TReport.TREntities.TRForms.ItemEnergyFlowDay i in t.Items) {
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
            //List<int> list_tags = GetIDTagsEnergyDay();
            TData.TData t_data = new TData.TData();
            List<DataMeasurement> list_data_measurement = t_data.GetDataMeasurement(GetIDTagsEnergyFlowDay(), date);

            EFEnergyReports e_reports = new EFEnergyReports();

            foreach (TReport.TREntities.TRForms.GroupEnergyFlowDay g in this.formEnergyFlowDay.Groups.OrderBy(g=>g.position))
            {
                GroupEnergyFlowValueEntity group = new GroupEnergyFlowValueEntity()
                {
                    name = e_reports.GetNameGroupEnergyCulture(g.id_group),
                    position = 0
                };
                foreach (TReport.TREntities.TRForms.TypeEnergyFlowDay t in g.Types.OrderBy(t=>t.position))
                {
                    TypeEnergyFlowValueEntity type = new TypeEnergyFlowValueEntity()
                    {
                        name = e_reports.GetNameTypeEnergyCulture(t.id_type),
                        position = 0
                    };
                    foreach (TReport.TREntities.TRForms.ItemEnergyFlowDay item in t.Items.OrderBy(i=>i.position))
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
    }
}
