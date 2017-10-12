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
                            if (i.flow != null) list.Add((int)i.flow);
                            if (i.avg_temp != null) list.Add((int)i.avg_temp);
                            if (i.avg_pressure != null) list.Add((int)i.avg_pressure);
                            if (i.planimetric != null) list.Add((int)i.planimetric);
                            if (i.pr_flow != null) list.Add((int)i.pr_flow);
                            if (i.time_norm != null) list.Add((int)i.time_norm);
                            if (i.time_max != null) list.Add((int)i.time_max);
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

                                EnergyFlowValueEntity ef = new EnergyFlowValueEntity()
                                 {
                                     name = item.name_energy_ru,
                                     trObj = (trObj)item.trobj,
                                     position = item.position,
                                     flow = item.flow != null ? (DBFlowValue)list_data_measurement.Find(m => m.id == item.flow).value_measurement : null,
                                     avg_temp = item.avg_temp != null ? (DBTempValue)list_data_measurement.Find(m => m.id == item.avg_temp).value_measurement : null,
                                     avg_pressure = item.avg_pressure != null ? (DBPressureValue)list_data_measurement.Find(m => m.id == item.avg_pressure).value_measurement : null,
                                     planimetric = item.planimetric != null ? (DBPlanimetricValue)list_data_measurement.Find(m => m.id == item.planimetric).value_measurement : null,
                                     pr_flow = item.pr_flow != null ? (DBFlowValue)list_data_measurement.Find(m => m.id == item.pr_flow).value_measurement : null,
                                     time_norm = item.time_norm != null ? (DBTimeValue)list_data_measurement.Find(m => m.id == item.time_norm).value_measurement : null,
                                     time_max = item.time_max != null ? (DBTimeValue)list_data_measurement.Find(m => m.id == item.time_max).value_measurement : null,
                                 };
                                type.list_type_flow.Add(ef);
                            }
                            catch (Exception e)
                            {
                                e.WriteError(String.Format("Ошибка формирования строки отчета. Параметр :{0}, объект: {1}", item.name_energy_ru, item.trobj), eventID);
                                type.list_type_flow.Add(new EnergyFlowValueEntity()
                                {
                                    name = item.name_energy_ru,
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
