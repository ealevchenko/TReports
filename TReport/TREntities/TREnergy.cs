using Measurement;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using TReport.App_LocalResources;
using TReport.TData;
using TReport.TData.DataSet;
using TReport.TData.Interfaces;

namespace TReport.TREntities
{

    public class TREnergy : TR
    {



        public class EnergySutkiObject
        {
            public trObj trobj { get; set; }
            public object energy_sutki { get; set; }
            public EnergySutkiObject(trObj trobj, object es)
                : base()
            {
                this.trobj = trobj;
                this.energy_sutki = es;
            }
        }
        // Список всех данных по всем объектам
        protected List<EnergySutkiObject> list_energy_sutki = new List<EnergySutkiObject>(); 
        public List<EnergySutkiObject> ListEnergySutki { get { return this.list_energy_sutki; } }
        // Список полученых наборов данных по энергоресурсам
        protected List<GroupEnergyValueObjEntity> list_group_energy_value = new List<GroupEnergyValueObjEntity>(); 
        public List<GroupEnergyValueObjEntity> ListGroupEnergyValue { get { return this.list_group_energy_value; } }

        public TREnergy(trObj trObj) : base(trObj) { }

        public TREnergy(trObj[] trObjs) : base(trObjs) { }

        public TREnergy(List<trObj> trObjs) : base(trObjs) { }

        /// <summary>
        /// Получить строку с учетом культуры
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetEnergyResource(string key)
        {
            ResourceManager resourceManager = new ResourceManager(typeof(EnergyResource));
            return resourceManager.GetString(key, CultureInfo.CurrentCulture);
        }

        #region методы для работы с исходными данными EnergoSutki & EnergoSutkiObject
        /// <summary>
        /// получить список всех параметров EnergoSutki по указанному объекту
        /// </summary>
        /// <param name="date"></param>
        /// <param name="trobj"></param>
        /// <returns></returns>
        public EnergySutkiObject GetEnergySutkiObject(DateTime date, trObj trobj)
        {
            TData.TData data = new TData.TData();
            object ies = data.GetEnergySutkiObject(date, trobj);
            if (ies == null) return null; // Данных нет
            return new EnergySutkiObject(trobj, ies);

        }
        /// <summary>
        /// получить список всех параметров EnergoSutki по всем объектам
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<EnergySutkiObject> GetEnergySutkiObject(DateTime date)
        {
            List<EnergySutkiObject> list = new List<EnergySutkiObject>();
            foreach (trObj obj in base.trObjs)
            {
                EnergySutkiObject eso = GetEnergySutkiObject(date, obj);
                if (eso != null) { list.Add(eso);}
                
            }
            return list;
        }
        #endregion

        #region Природный газ

        public enum teNaturGas : int
        {
            natur_gas_bf = 1,
            natur_gas_hpp3,
            natur_gas_tn,
        }
        /// <summary>
        /// Получить набор данных природный газ на печь
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public EnergyValueObjEntity GetNaturGasBF(trObj obj)
        {
            EnergySutkiObject eso = list_energy_sutki.Find(e => e.trobj == obj);
            if (eso == null) return null;
            if (eso.energy_sutki is INaturGas_BF)
            {
                EnergyValueObjEntity evoe = new EnergyValueObjEntity()
                {
                    obj = (int)obj,
                    name = GetEnergyResource(teNaturGas.natur_gas_bf.ToString()) + " " + base.GetResource(obj.ToString()),
                    flow = new FlowValue(((INaturGas_BF)eso.energy_sutki).NG_BF_flow, GetEnergyResource("flow_sutky"), ((INaturGas_BF)eso.energy_sutki).NG_BF_flow_unit, ((INaturGas_BF)eso.energy_sutki).NG_BF_flow_multiplier),
                    avg_temp = new TempValue(((INaturGas_BF)eso.energy_sutki).NG_BF_temp, GetEnergyResource("avg_temp"), ((INaturGas_BF)eso.energy_sutki).NG_BF_temp_unit, ((INaturGas_BF)eso.energy_sutki).NG_BF_temp_multiplier),
                    avg_pressure = new PressureValue(((INaturGas_BF)eso.energy_sutki).NG_BF_pressure, GetEnergyResource("avg_pressure"), ((INaturGas_BF)eso.energy_sutki).NG_BF_pressure_unit, ((INaturGas_BF)eso.energy_sutki).NG_BF_pressure_multiplier),
                    planimetric = new PlanimetricValue(((INaturGas_BF)eso.energy_sutki).NG_BF_planimetric, GetEnergyResource("planimetric_value"), ((INaturGas_BF)eso.energy_sutki).NG_BF_planimetric_unit, ((INaturGas_BF)eso.energy_sutki).NG_BF_planimetric_multiplier),
                    pr_flow = new FlowValue(((INaturGas_BF)eso.energy_sutki).NG_BF_pr_flow, GetEnergyResource("pr_flow_sutky"), ((INaturGas_BF)eso.energy_sutki).NG_BF_pr_flow_unit, ((INaturGas_BF)eso.energy_sutki).NG_BF_pr_flow_multiplier),
                    time_norm = new TimeValue(((INaturGas_BF)eso.energy_sutki).NG_BF_time_norm, GetEnergyResource("time_norm"), ((INaturGas_BF)eso.energy_sutki).NG_BF_time_norm_unit, ((INaturGas_BF)eso.energy_sutki).NG_BF_time_norm_multiplier),
                    time_max = new TimeValue(((INaturGas_BF)eso.energy_sutki).NG_BF_time_max, GetEnergyResource("time_max"), ((INaturGas_BF)eso.energy_sutki).NG_BF_time_max_unit, ((INaturGas_BF)eso.energy_sutki).NG_BF_time_max_multiplier),
                };
                return evoe;
            }
            return null;
        }
        /// <summary>
        /// Получить набор данных природный газ на ТЭЦ-3
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public EnergyValueObjEntity GetNaturGasHPP3(trObj obj)
        {
            //if (obj != trObj.dc2_dp9) return null;
            EnergySutkiObject eso = list_energy_sutki.Find(e => e.trobj == obj);
            if (eso == null) return null;
            if (eso.energy_sutki is INaturGas_HPP3)
            {

                EnergyValueObjEntity evoe = new EnergyValueObjEntity()
                {
                    obj = (int)obj,
                    name = GetEnergyResource(teNaturGas.natur_gas_hpp3.ToString()),
                    flow = new FlowValue(((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_flow, GetEnergyResource("flow_sutky"), ((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_flow_unit, ((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_flow_multiplier),
                    avg_temp = new TempValue(((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_temp, GetEnergyResource("avg_temp"), ((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_temp_unit, ((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_temp_multiplier),
                    avg_pressure = new PressureValue(((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_pressure, GetEnergyResource("avg_pressure"), ((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_pressure_unit, ((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_pressure_multiplier),
                    planimetric = new PlanimetricValue(((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_planimetric, GetEnergyResource("planimetric_value"), ((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_planimetric_unit, ((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_planimetric_multiplier),
                    pr_flow = new FlowValue(((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_pr_flow, GetEnergyResource("pr_flow_sutky"), ((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_pr_flow_unit, ((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_pr_flow_multiplier),
                    time_norm = new TimeValue(((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_time_norm, GetEnergyResource("time_norm"), ((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_time_norm_unit, ((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_time_norm_multiplier),
                    time_max = new TimeValue(((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_time_max, GetEnergyResource("time_max"), ((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_time_max_unit, ((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_time_max_multiplier),
                };
                return evoe;
            }
            return null;
        }
        /// <summary>
        /// Получить набор данных природный газ на тех нужды
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public EnergyValueObjEntity GetNaturGasTN(trObj obj)
        {
            EnergySutkiObject eso = list_energy_sutki.Find(e => e.trobj == obj);
            if (eso == null) return null;
            if (eso.energy_sutki is INaturGas_TN)
            {

                EnergyValueObjEntity evoe = new EnergyValueObjEntity()
                {
                    obj = (int)obj,
                    name = GetEnergyResource(teNaturGas.natur_gas_tn.ToString()) + " " + base.GetResource(obj.ToString()),
                    flow = new FlowValue(((INaturGas_TN)eso.energy_sutki).NG_TN_flow, GetEnergyResource("flow_sutky"), ((INaturGas_TN)eso.energy_sutki).NG_TN_flow_unit, ((INaturGas_TN)eso.energy_sutki).NG_TN_flow_multiplier),
                    avg_temp = new TempValue(((INaturGas_TN)eso.energy_sutki).NG_TN_temp, GetEnergyResource("avg_temp"), ((INaturGas_TN)eso.energy_sutki).NG_TN_temp_unit, ((INaturGas_TN)eso.energy_sutki).NG_TN_temp_multiplier),
                    avg_pressure = new PressureValue(((INaturGas_TN)eso.energy_sutki).NG_TN_pressure, GetEnergyResource("avg_pressure"), ((INaturGas_TN)eso.energy_sutki).NG_TN_pressure_unit, ((INaturGas_TN)eso.energy_sutki).NG_TN_pressure_multiplier),
                    planimetric = new PlanimetricValue(((INaturGas_TN)eso.energy_sutki).NG_TN_planimetric, GetEnergyResource("planimetric_value"), ((INaturGas_TN)eso.energy_sutki).NG_TN_planimetric_unit, ((INaturGas_TN)eso.energy_sutki).NG_TN_planimetric_multiplier),
                    pr_flow = new FlowValue(((INaturGas_TN)eso.energy_sutki).NG_TN_pr_flow, GetEnergyResource("pr_flow_sutky"), ((INaturGas_TN)eso.energy_sutki).NG_TN_pr_flow_unit, ((INaturGas_TN)eso.energy_sutki).NG_TN_pr_flow_multiplier),
                    time_norm = new TimeValue(((INaturGas_TN)eso.energy_sutki).NG_TN_time_norm, GetEnergyResource("time_norm"), ((INaturGas_TN)eso.energy_sutki).NG_TN_time_norm_unit, ((INaturGas_TN)eso.energy_sutki).NG_TN_time_norm_multiplier),
                    time_max = new TimeValue(((INaturGas_TN)eso.energy_sutki).NG_TN_time_max, GetEnergyResource("time_max"), ((INaturGas_TN)eso.energy_sutki).NG_TN_time_max_unit, ((INaturGas_TN)eso.energy_sutki).NG_TN_time_max_multiplier),
                };
                return evoe;
            }
            return null;
        }
        /// <summary>
        /// Получить набор данных природный газ
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public TypeEnergyValueObjEntity GetTypeNaturGas(teNaturGas type)
        {
            List<EnergyValueObjEntity> list = new List<EnergyValueObjEntity>();
            EnergyValueObjEntity evoe = null;
            foreach (trObj obj in base.trObjs)
            {
                switch (type) { 
                    case teNaturGas.natur_gas_bf: evoe = GetNaturGasBF(obj); break;
                    case teNaturGas.natur_gas_hpp3: evoe = GetNaturGasHPP3(obj); break;
                    case teNaturGas.natur_gas_tn: evoe = GetNaturGasTN(obj); break;
                    default: evoe=null; break;
                }
                if (evoe != null) {
                    list.Add(evoe);
                }
            }
            return new TypeEnergyValueObjEntity()
            {
                type = (int)type,
                name = GetEnergyResource(type.ToString()),
                list_energy = list,
            };
        }
        /// <summary>
        /// Получить список набора данных природный газ
        /// </summary>
        /// <returns></returns>
        public List<TypeEnergyValueObjEntity> GetNaturGas()
        {
            List<TypeEnergyValueObjEntity> list = new List<TypeEnergyValueObjEntity>();
            foreach (teNaturGas type in Enum.GetValues(typeof(teNaturGas)))
            {
                list.Add(GetTypeNaturGas(type));
            }
            return list;
        }
        #endregion

        #region Доменный газ
        public enum teBlastFurnaceGas : int
        {
            blast_furnace_gas_bvn = 1,
            top_gas,
            blast_furnace_gas_gsu5,
        }

        public EnergyValueObjEntity GetBlastFurnaceGasBVN(trObj obj)
        {
            EnergySutkiObject eso = list_energy_sutki.Find(e => e.trobj == obj);
            if (eso == null) return null;
            if (eso.energy_sutki is IBlastFurnaceGas_BVN)
            {
                EnergyValueObjEntity evoe = new EnergyValueObjEntity()
                {
                    obj = (int)obj,
                    name = GetEnergyResource(teBlastFurnaceGas.blast_furnace_gas_bvn.ToString()) + " " + base.GetResource(obj.ToString()),
                    flow = new FlowValue(((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_flow, GetEnergyResource("flow_sutky"), ((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_flow_unit, ((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_flow_multiplier),
                    avg_temp = new TempValue(((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_temp, GetEnergyResource("avg_temp"), ((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_temp_unit, ((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_temp_multiplier),
                    avg_pressure = new PressureValue(((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_pressure, GetEnergyResource("avg_pressure"), ((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_pressure_unit, ((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_pressure_multiplier),
                    planimetric = new PlanimetricValue(((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_planimetric, GetEnergyResource("planimetric_value"), ((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_planimetric_unit, ((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_planimetric_multiplier),
                    pr_flow = new FlowValue(((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_pr_flow, GetEnergyResource("pr_flow_sutky"), ((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_pr_flow_unit, ((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_pr_flow_multiplier),
                    time_norm = new TimeValue(((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_time_norm, GetEnergyResource("time_norm"), ((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_time_norm_unit, ((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_time_norm_multiplier),
                    time_max = new TimeValue(((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_time_max, GetEnergyResource("time_max"), ((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_time_max_unit, ((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_time_max_multiplier),
                };
                return evoe;
            }
            return null;
        }

        public TypeEnergyValueObjEntity GetTypeBlastFurnaceGas(teBlastFurnaceGas type)
        {
            List<EnergyValueObjEntity> list = new List<EnergyValueObjEntity>();
            EnergyValueObjEntity evoe = null;
            foreach (trObj obj in base.trObjs)
            {
                switch (type) {
                    case teBlastFurnaceGas.blast_furnace_gas_bvn: evoe = GetBlastFurnaceGasBVN(obj); break;
                    //case teBlastFurnaceGas.top_gas: evoe = GetNaturGasHPP3(obj); break;
                    //case teBlastFurnaceGas.blast_furnace_gas_gsu5: evoe = GetNaturGasTN(obj); break;
                    default: evoe=null; break;
                }
                if (evoe != null) {
                    list.Add(evoe);
                }
            }
            return new TypeEnergyValueObjEntity()
            {
                type = (int)type,
                name = GetEnergyResource(type.ToString()),
                list_energy = list,
            };
        }

        public List<TypeEnergyValueObjEntity> GetBlastFurnaceGas()
        {
            List<TypeEnergyValueObjEntity> list = new List<TypeEnergyValueObjEntity>();
            foreach (teBlastFurnaceGas type in Enum.GetValues(typeof(teBlastFurnaceGas)))
            {
                list.Add(GetTypeBlastFurnaceGas(type));
            }
            return list;
        }
        #endregion

        #region GroupEnergy
        /// <summary>
        /// Получить группу набора данных groupEnergy
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public GroupEnergyValueObjEntity GetGroup(groupEnergy group)
        {
            List<TypeEnergyValueObjEntity> list = new List<TypeEnergyValueObjEntity>();
            switch (group)
            {
                case groupEnergy.natur_gas: list = GetNaturGas(); break;
                case groupEnergy.blast_furnace_gas: list = GetBlastFurnaceGas(); break;
            }
            return new GroupEnergyValueObjEntity()
            {
                group = group,
                name = GetEnergyResource(group.ToString()),
                list_type_energy = list
            };
        }

        public List<GroupEnergyValueObjEntity> GetGroup() {
            List<GroupEnergyValueObjEntity> list = new List<GroupEnergyValueObjEntity>();
            foreach (groupEnergy group in Enum.GetValues(typeof(groupEnergy))) {
                list.Add(GetGroup(group));}
                return list;
        }
        #endregion

        public void GetEnergySutki(DateTime date)
        {

            this.list_energy_sutki = GetEnergySutkiObject(date);    // Соберем исходные данные из баз данных всех указаных объектов
            this.list_group_energy_value = GetGroup();              // формируем набор данных по энергоресурсам

        }

    }
}
