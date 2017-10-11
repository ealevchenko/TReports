using EFTReports.Concrete;
using EFTReports.Entities;
using Measurement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TReport.TData;

namespace TReport.TREntities
{
    public class TREnergy:TR
    {
        public class EnergyFlowValueEntity
        {
            public trObj trObj { get; set; }
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
        
        public TREnergy(trObj trObj) : base(trObj) { }

        public TREnergy(trObj[] trObjs) : base(trObjs) { }

        public TREnergy(List<trObj> trObjs) : base(trObjs) { }

        private List<GroupEnergyFlowValueEntity> list_energy_flow_day = new List<GroupEnergyFlowValueEntity>();
        public List<GroupEnergyFlowValueEntity> ListFlowDay { get { return this.list_energy_flow_day; } }


        /// <summary>
        /// Получить список тегов для отчета расход за сутки
        /// </summary>
        /// <returns></returns>
        private List<int> GetIDTagsEnergyDay() {
            List<int> list = new List<int>();
            EFEnergyReports efer = new EFEnergyReports();
            foreach (REnergyDay ed in efer.GetTREnergyDay())
            { 
                if (ed.flow!=null) list.Add((int)ed.flow);
                if (ed.avg_temp != null) list.Add((int)ed.avg_temp);
                if (ed.avg_pressure != null) list.Add((int)ed.avg_pressure);
                if (ed.planimetric != null) list.Add((int)ed.planimetric);
                if (ed.pr_flow != null) list.Add((int)ed.pr_flow);
                if (ed.time_norm != null) list.Add((int)ed.time_norm);
                if (ed.time_max != null) list.Add((int)ed.time_max);
            }
            return list;
        }

        public void GetEnergyFlowDay(DateTime date)
        {
            //List<int> list_tags = GetIDTagsEnergyDay();
            TData.TData td = new TData.TData();
            List<DataMeasurement> list_data_measurement = td.GetDataMeasurement(GetIDTagsEnergyDay(), date);


            EFEnergyReports efer = new EFEnergyReports();
            foreach (GroupEnergy group in efer.GetGroupEnergy().ToList())
            {
                GroupEnergyFlowValueEntity ge = new GroupEnergyFlowValueEntity()
                {
                    name = group.group_energy_ru,
                    position = 0
                };
                foreach (TypeEnergy type in efer.GetTypeEnergyOfGroup(group.id))
                {
                    TypeEnergyFlowValueEntity te = new TypeEnergyFlowValueEntity()
                    {
                        name = type.type_energy_ru,
                        position = 0
                    };

                    foreach (REnergyDay ed in efer.GetREnergyDayOfType(type.id))
                    {
                        EnergyFlowValueEntity ef = new EnergyFlowValueEntity()
                         {
                             name = ed.name_energy_ru,
                             trObj = (trObj)ed.trobj,
                             position = ed.position,
                             flow = (DBFlowValue)list_data_measurement.Find(m => m.id == ed.flow).value_measurement,
                             avg_temp = ed.avg_temp !=null ?(DBTempValue)list_data_measurement.Find(m => m.id == ed.avg_temp).value_measurement : null,
                             avg_pressure = ed.avg_pressure !=null ?(DBPressureValue)list_data_measurement.Find(m => m.id == ed.avg_pressure).value_measurement : null,
                             planimetric = ed.planimetric !=null ?(DBPlanimetricValue)list_data_measurement.Find(m => m.id == ed.planimetric).value_measurement : null,
                             pr_flow = ed.pr_flow !=null ?(DBFlowValue)list_data_measurement.Find(m => m.id == ed.pr_flow).value_measurement : null,
                             time_norm = ed.time_norm !=null ?(DBTimeValue)list_data_measurement.Find(m => m.id == ed.time_norm).value_measurement : null,
                             time_max = ed.time_max !=null ? (DBTimeValue)list_data_measurement.Find(m => m.id == ed.time_max).value_measurement : null,
                         };
                        te.list_type_flow.Add(ef);
                    }
                    ge.list_type.Add(te);
                }
                this.list_energy_flow_day.Add(ge);
            }
            
            //IQueryable<ReportEnergyDay> list  GetReportEnergyDay()


            //this.list_energy_sutki = GetEnergySutkiObject(date);    // Соберем исходные данные из баз данных всех указаных объектов
            //this.list_group_energy_value = GetGroup();              // формируем набор данных по энергоресурсам

        }
    }
}
