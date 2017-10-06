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
        #region Описание наборов данных для построетия списков парметров учета энергоресурсов

        public enum groupEnergy : int
        {
            natur_gas = 1,
            blast_furnace_gas,
            blast,
            steam,
            nitrogen,
            compressed_air,
            oxygen
        }

        /// <summary>
        /// Набор данных параметра учета энергоресурса
        /// </summary>
        public class EnergyValueEntity
        {
            public string name { get; set; }
            public FlowValue flow { get; set; }
            public TempValue avg_temp { get; set; }
            public PressureValue avg_pressure { get; set; }
            public PlanimetricValue planimetric { get; set; }
            public FlowValue pr_flow { get; set; }
            public TimeValue time_norm { get; set; }
            public TimeValue time_max { get; set; }
            public EnergyValueEntity()
            {

            }
        }
        /// <summary>
        /// Набор данных параметра учета энергоресурса c привязкой к объекту
        /// </summary>
        public class EnergyValueObjEntity : EnergyValueEntity
        {
            public int obj { get; set; }
            public string Object
            {
                get
                {
                    return ((trObj)obj).ToString().GetResources();
                }
            }
            public EnergyValueObjEntity()
                : base()
            {

            }
        }
        /// <summary>
        /// Набор типов данных параметра учета энергоресурса c привязкой к объекту 
        /// </summary>
        public class TypeEnergyValueObjEntity
        {
            public int type { get; set; }
            public string name { get; set; }
            public List<EnergyValueObjEntity> list_energy = new List<EnergyValueObjEntity>();
            public TypeEnergyValueObjEntity() { }
        }
        /// <summary>
        /// Набор uhegg типов данных параметра учета энергоресурса c привязкой к объекту 
        /// </summary>
        public class GroupEnergyValueObjEntity
        {
            public groupEnergy group { get; set; }
            public string name { get; set; }
            public List<TypeEnergyValueObjEntity> list_type_energy = new List<TypeEnergyValueObjEntity>();
            public GroupEnergyValueObjEntity() { }
        }
        #endregion


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

        ///// <summary>
        ///// Получить строку с учетом культуры
        ///// </summary>
        ///// <param name="key"></param>
        ///// <returns></returns>
        //public string GetEnergyResource(string key)
        //{
        //    ResourceManager resourceManager = new ResourceManager(typeof(EnergyResource));
        //    return resourceManager.GetString(key, CultureInfo.CurrentCulture);
        //}

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
            natur_gas_psi,
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
                    name = teNaturGas.natur_gas_bf.ToString().GetREnergy() + " " + obj.ToString().GetResources(),
                    flow = new FlowValue(((INaturGas_BF)eso.energy_sutki).NG_BF_flow, ("flow_sutky").GetREnergy(), ((INaturGas_BF)eso.energy_sutki).NG_BF_flow_unit, ((INaturGas_BF)eso.energy_sutki).NG_BF_flow_multiplier),
                    avg_temp = new TempValue(((INaturGas_BF)eso.energy_sutki).NG_BF_temp, ("avg_temp").GetREnergy(), ((INaturGas_BF)eso.energy_sutki).NG_BF_temp_unit, ((INaturGas_BF)eso.energy_sutki).NG_BF_temp_multiplier),
                    avg_pressure = new PressureValue(((INaturGas_BF)eso.energy_sutki).NG_BF_pressure, ("avg_pressure").GetREnergy(), ((INaturGas_BF)eso.energy_sutki).NG_BF_pressure_unit, ((INaturGas_BF)eso.energy_sutki).NG_BF_pressure_multiplier),
                    planimetric = new PlanimetricValue(((INaturGas_BF)eso.energy_sutki).NG_BF_planimetric, ("planimetric_value").GetREnergy(), ((INaturGas_BF)eso.energy_sutki).NG_BF_planimetric_unit, ((INaturGas_BF)eso.energy_sutki).NG_BF_planimetric_multiplier),
                    pr_flow = new FlowValue(((INaturGas_BF)eso.energy_sutki).NG_BF_pr_flow, ("pr_flow_sutky").GetREnergy(), ((INaturGas_BF)eso.energy_sutki).NG_BF_pr_flow_unit, ((INaturGas_BF)eso.energy_sutki).NG_BF_pr_flow_multiplier),
                    time_norm = new TimeValue(((INaturGas_BF)eso.energy_sutki).NG_BF_time_norm, ("time_norm").GetREnergy(), ((INaturGas_BF)eso.energy_sutki).NG_BF_time_norm_unit, ((INaturGas_BF)eso.energy_sutki).NG_BF_time_norm_multiplier),
                    time_max = new TimeValue(((INaturGas_BF)eso.energy_sutki).NG_BF_time_max, ("time_max").GetREnergy(), ((INaturGas_BF)eso.energy_sutki).NG_BF_time_max_unit, ((INaturGas_BF)eso.energy_sutki).NG_BF_time_max_multiplier),
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
                    name = teNaturGas.natur_gas_hpp3.ToString().GetREnergy(),
                    flow = new FlowValue(((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_flow, ("flow_sutky").GetREnergy(), ((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_flow_unit, ((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_flow_multiplier),
                    avg_temp = new TempValue(((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_temp, ("avg_temp").GetREnergy(), ((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_temp_unit, ((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_temp_multiplier),
                    avg_pressure = new PressureValue(((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_pressure, ("avg_pressure").GetREnergy(), ((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_pressure_unit, ((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_pressure_multiplier),
                    planimetric = new PlanimetricValue(((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_planimetric, ("planimetric_value").GetREnergy(), ((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_planimetric_unit, ((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_planimetric_multiplier),
                    pr_flow = new FlowValue(((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_pr_flow, ("pr_flow_sutky").GetREnergy(), ((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_pr_flow_unit, ((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_pr_flow_multiplier),
                    time_norm = new TimeValue(((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_time_norm, ("time_norm").GetREnergy(), ((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_time_norm_unit, ((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_time_norm_multiplier),
                    time_max = new TimeValue(((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_time_max, ("time_max").GetREnergy(), ((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_time_max_unit, ((INaturGas_HPP3)eso.energy_sutki).NG_HPP3_time_max_multiplier),
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
                    name = teNaturGas.natur_gas_tn.ToString().GetREnergy() + " " + obj.ToString().GetResources(),
                    flow = new FlowValue(((INaturGas_TN)eso.energy_sutki).NG_TN_flow, ("flow_sutky").GetREnergy(), ((INaturGas_TN)eso.energy_sutki).NG_TN_flow_unit, ((INaturGas_TN)eso.energy_sutki).NG_TN_flow_multiplier),
                    avg_temp = new TempValue(((INaturGas_TN)eso.energy_sutki).NG_TN_temp, ("avg_temp").GetREnergy(), ((INaturGas_TN)eso.energy_sutki).NG_TN_temp_unit, ((INaturGas_TN)eso.energy_sutki).NG_TN_temp_multiplier),
                    avg_pressure = new PressureValue(((INaturGas_TN)eso.energy_sutki).NG_TN_pressure, ("avg_pressure").GetREnergy(), ((INaturGas_TN)eso.energy_sutki).NG_TN_pressure_unit, ((INaturGas_TN)eso.energy_sutki).NG_TN_pressure_multiplier),
                    planimetric = new PlanimetricValue(((INaturGas_TN)eso.energy_sutki).NG_TN_planimetric, ("planimetric_value").GetREnergy(), ((INaturGas_TN)eso.energy_sutki).NG_TN_planimetric_unit, ((INaturGas_TN)eso.energy_sutki).NG_TN_planimetric_multiplier),
                    pr_flow = new FlowValue(((INaturGas_TN)eso.energy_sutki).NG_TN_pr_flow, ("pr_flow_sutky").GetREnergy(), ((INaturGas_TN)eso.energy_sutki).NG_TN_pr_flow_unit, ((INaturGas_TN)eso.energy_sutki).NG_TN_pr_flow_multiplier),
                    time_norm = new TimeValue(((INaturGas_TN)eso.energy_sutki).NG_TN_time_norm, ("time_norm").GetREnergy(), ((INaturGas_TN)eso.energy_sutki).NG_TN_time_norm_unit, ((INaturGas_TN)eso.energy_sutki).NG_TN_time_norm_multiplier),
                    time_max = new TimeValue(((INaturGas_TN)eso.energy_sutki).NG_TN_time_max, ("time_max").GetREnergy(), ((INaturGas_TN)eso.energy_sutki).NG_TN_time_max_unit, ((INaturGas_TN)eso.energy_sutki).NG_TN_time_max_multiplier),
                };
                return evoe;
            }
            return null;
        }
        /// <summary>
        /// Получить набор данных природный газ на ПУТ
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public EnergyValueObjEntity GetNaturGasPSI(trObj obj)
        {
            EnergySutkiObject eso = list_energy_sutki.Find(e => e.trobj == obj);
            if (eso == null) return null;
            if (eso.energy_sutki is INaturGas_PSI)
            {

                EnergyValueObjEntity evoe = new EnergyValueObjEntity()
                {
                    obj = (int)obj,
                    name = teNaturGas.natur_gas_psi.ToString().GetREnergy()  + " " + obj.ToString().GetResources(),
                    flow = new FlowValue(((INaturGas_PSI)eso.energy_sutki).NG_PSI_flow, ("flow_sutky").GetREnergy(), ((INaturGas_PSI)eso.energy_sutki).NG_PSI_flow_unit, ((INaturGas_PSI)eso.energy_sutki).NG_PSI_flow_multiplier),
                    avg_temp = new TempValue(((INaturGas_PSI)eso.energy_sutki).NG_PSI_temp, ("avg_temp").GetREnergy(), ((INaturGas_PSI)eso.energy_sutki).NG_PSI_temp_unit, ((INaturGas_PSI)eso.energy_sutki).NG_PSI_temp_multiplier),
                    avg_pressure = new PressureValue(((INaturGas_PSI)eso.energy_sutki).NG_PSI_pressure, ("avg_pressure").GetREnergy(), ((INaturGas_PSI)eso.energy_sutki).NG_PSI_pressure_unit, ((INaturGas_PSI)eso.energy_sutki).NG_PSI_pressure_multiplier),
                    planimetric = new PlanimetricValue(((INaturGas_PSI)eso.energy_sutki).NG_PSI_planimetric, ("planimetric_value").GetREnergy(), ((INaturGas_PSI)eso.energy_sutki).NG_PSI_planimetric_unit, ((INaturGas_PSI)eso.energy_sutki).NG_PSI_planimetric_multiplier),
                    pr_flow = new FlowValue(((INaturGas_PSI)eso.energy_sutki).NG_PSI_pr_flow, ("pr_flow_sutky").GetREnergy(), ((INaturGas_PSI)eso.energy_sutki).NG_PSI_pr_flow_unit, ((INaturGas_PSI)eso.energy_sutki).NG_PSI_pr_flow_multiplier),
                    time_norm = new TimeValue(((INaturGas_PSI)eso.energy_sutki).NG_PSI_time_norm, ("time_norm").GetREnergy(), ((INaturGas_PSI)eso.energy_sutki).NG_PSI_time_norm_unit, ((INaturGas_PSI)eso.energy_sutki).NG_PSI_time_norm_multiplier),
                    time_max = new TimeValue(((INaturGas_PSI)eso.energy_sutki).NG_PSI_time_max, ("time_max").GetREnergy(), ((INaturGas_PSI)eso.energy_sutki).NG_PSI_time_max_unit, ((INaturGas_PSI)eso.energy_sutki).NG_PSI_time_max_multiplier),
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
                    case teNaturGas.natur_gas_psi: evoe = GetNaturGasPSI(obj); break;

                    default: evoe=null; break;
                }
                if (evoe != null) {
                    list.Add(evoe);
                }
            }
            return new TypeEnergyValueObjEntity()
            {
                type = (int)type,
                name = type.ToString().GetREnergy(),
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
        /// <summary>
        /// Получить набор данных Доменный газ на БВН
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public EnergyValueObjEntity GetBlastFurnaceGasBVN(trObj obj)
        {
            EnergySutkiObject eso = list_energy_sutki.Find(e => e.trobj == obj);
            if (eso == null) return null;
            if (eso.energy_sutki is IBlastFurnaceGas_BVN)
            {
                EnergyValueObjEntity evoe = new EnergyValueObjEntity()
                {
                    obj = (int)obj,
                    name = teBlastFurnaceGas.blast_furnace_gas_bvn.ToString().GetREnergy() + " " + obj.ToString().GetResources(),
                    flow = new FlowValue(((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_flow, ("flow_sutky").GetREnergy(), ((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_flow_unit, ((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_flow_multiplier),
                    avg_temp = new TempValue(((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_temp, ("avg_temp").GetREnergy(), ((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_temp_unit, ((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_temp_multiplier),
                    avg_pressure = new PressureValue(((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_pressure, ("avg_pressure").GetREnergy(), ((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_pressure_unit, ((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_pressure_multiplier),
                    planimetric = new PlanimetricValue(((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_planimetric, ("planimetric_value").GetREnergy(), ((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_planimetric_unit, ((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_planimetric_multiplier),
                    pr_flow = new FlowValue(((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_pr_flow, ("pr_flow_sutky").GetREnergy(), ((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_pr_flow_unit, ((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_pr_flow_multiplier),
                    time_norm = new TimeValue(((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_time_norm, ("time_norm").GetREnergy(), ((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_time_norm_unit, ((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_time_norm_multiplier),
                    time_max = new TimeValue(((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_time_max, ("time_max").GetREnergy(), ((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_time_max_unit, ((IBlastFurnaceGas_BVN)eso.energy_sutki).BFG_BVN_time_max_multiplier),
                };
                return evoe;
            }
            return null;
        }
        /// <summary>
        /// Получить набор данных  Колошниковый газ на выходе
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public EnergyValueObjEntity GetTopGas(trObj obj)
        {
            EnergySutkiObject eso = list_energy_sutki.Find(e => e.trobj == obj);
            if (eso == null) return null;
            if (eso.energy_sutki is ITopGas)
            {
                EnergyValueObjEntity evoe = new EnergyValueObjEntity()
                {
                    obj = (int)obj,
                    name = teBlastFurnaceGas.top_gas.ToString().GetREnergy() + " " + obj.ToString().GetResources(),
                    flow = new FlowValue(((ITopGas)eso.energy_sutki).TopGas_flow, ("flow_sutky").GetREnergy(), ((ITopGas)eso.energy_sutki).TopGas_flow_unit, ((ITopGas)eso.energy_sutki).TopGas_flow_multiplier),
                    avg_temp = new TempValue(((ITopGas)eso.energy_sutki).TopGas_temp, ("avg_temp").GetREnergy(), ((ITopGas)eso.energy_sutki).TopGas_temp_unit, ((ITopGas)eso.energy_sutki).TopGas_temp_multiplier),
                    avg_pressure = new PressureValue(((ITopGas)eso.energy_sutki).TopGas_pressure, ("avg_pressure").GetREnergy(), ((ITopGas)eso.energy_sutki).TopGas_pressure_unit, ((ITopGas)eso.energy_sutki).TopGas_pressure_multiplier),
                    planimetric = new PlanimetricValue(((ITopGas)eso.energy_sutki).TopGas_planimetric, ("planimetric_value").GetREnergy(), ((ITopGas)eso.energy_sutki).TopGas_planimetric_unit, ((ITopGas)eso.energy_sutki).TopGas_planimetric_multiplier),
                    pr_flow = new FlowValue(((ITopGas)eso.energy_sutki).TopGas_pr_flow, ("pr_flow_sutky").GetREnergy(), ((ITopGas)eso.energy_sutki).TopGas_pr_flow_unit, ((ITopGas)eso.energy_sutki).TopGas_pr_flow_multiplier),
                    time_norm = new TimeValue(((ITopGas)eso.energy_sutki).TopGas_time_norm, ("time_norm").GetREnergy(), ((ITopGas)eso.energy_sutki).TopGas_time_norm_unit, ((ITopGas)eso.energy_sutki).TopGas_time_norm_multiplier),
                    time_max = new TimeValue(((ITopGas)eso.energy_sutki).TopGas_time_max, ("time_max").GetREnergy(), ((ITopGas)eso.energy_sutki).TopGas_time_max_unit, ((ITopGas)eso.energy_sutki).TopGas_time_max_multiplier),
                };
                return evoe;
            }
            return null;
        }
        /// <summary>
        /// Получить набор данных Выход доменного газа на ГСУ5
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public EnergyValueObjEntity GetBlastFurnaceGasGSU5(trObj obj)
        {
            EnergySutkiObject eso = list_energy_sutki.Find(e => e.trobj == obj);
            if (eso == null) return null;
            if (eso.energy_sutki is IBlastFurnaceGas_GSU5)
            {
                EnergyValueObjEntity evoe = new EnergyValueObjEntity()
                {
                    obj = (int)obj,
                    name = teBlastFurnaceGas.blast_furnace_gas_gsu5.ToString().GetREnergy() + " " + obj.ToString().GetResources(),
                    flow = new FlowValue(((IBlastFurnaceGas_GSU5)eso.energy_sutki).BFG_GSU5_flow, ("flow_sutky").GetREnergy(), ((IBlastFurnaceGas_GSU5)eso.energy_sutki).BFG_GSU5_flow_unit, ((IBlastFurnaceGas_GSU5)eso.energy_sutki).BFG_GSU5_flow_multiplier),
                    avg_temp = new TempValue(((IBlastFurnaceGas_GSU5)eso.energy_sutki).BFG_GSU5_temp, ("avg_temp").GetREnergy(), ((IBlastFurnaceGas_GSU5)eso.energy_sutki).BFG_GSU5_temp_unit, ((IBlastFurnaceGas_GSU5)eso.energy_sutki).BFG_GSU5_temp_multiplier),
                    avg_pressure = new PressureValue(((IBlastFurnaceGas_GSU5)eso.energy_sutki).BFG_GSU5_pressure, ("avg_pressure").GetREnergy(), ((IBlastFurnaceGas_GSU5)eso.energy_sutki).BFG_GSU5_pressure_unit, ((IBlastFurnaceGas_GSU5)eso.energy_sutki).BFG_GSU5_pressure_multiplier),
                    planimetric = new PlanimetricValue(((IBlastFurnaceGas_GSU5)eso.energy_sutki).BFG_GSU5_planimetric, ("planimetric_value").GetREnergy(), ((IBlastFurnaceGas_GSU5)eso.energy_sutki).BFG_GSU5_planimetric_unit, ((IBlastFurnaceGas_GSU5)eso.energy_sutki).BFG_GSU5_planimetric_multiplier),
                    pr_flow = new FlowValue(((IBlastFurnaceGas_GSU5)eso.energy_sutki).BFG_GSU5_pr_flow, ("pr_flow_sutky").GetREnergy(), ((IBlastFurnaceGas_GSU5)eso.energy_sutki).BFG_GSU5_pr_flow_unit, ((IBlastFurnaceGas_GSU5)eso.energy_sutki).BFG_GSU5_pr_flow_multiplier),
                    time_norm = new TimeValue(((IBlastFurnaceGas_GSU5)eso.energy_sutki).BFG_GSU5_time_norm, ("time_norm").GetREnergy(), ((IBlastFurnaceGas_GSU5)eso.energy_sutki).BFG_GSU5_time_norm_unit, ((IBlastFurnaceGas_GSU5)eso.energy_sutki).BFG_GSU5_time_norm_multiplier),
                    time_max = new TimeValue(((IBlastFurnaceGas_GSU5)eso.energy_sutki).BFG_GSU5_time_max, ("time_max").GetREnergy(), ((IBlastFurnaceGas_GSU5)eso.energy_sutki).BFG_GSU5_time_max_unit, ((IBlastFurnaceGas_GSU5)eso.energy_sutki).BFG_GSU5_time_max_multiplier),
                };
                return evoe;
            }
            return null;
        }

        /// <summary>
        /// Получить набор данных доменный газ
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public TypeEnergyValueObjEntity GetTypeBlastFurnaceGas(teBlastFurnaceGas type)
        {
            List<EnergyValueObjEntity> list = new List<EnergyValueObjEntity>();
            EnergyValueObjEntity evoe = null;
            foreach (trObj obj in base.trObjs)
            {
                switch (type) {
                    case teBlastFurnaceGas.blast_furnace_gas_bvn: evoe = GetBlastFurnaceGasBVN(obj); break;
                    case teBlastFurnaceGas.top_gas: evoe = GetTopGas(obj); break;
                    case teBlastFurnaceGas.blast_furnace_gas_gsu5: evoe = GetBlastFurnaceGasGSU5(obj); break;

                    default: evoe=null; break;
                }
                if (evoe != null) {
                    list.Add(evoe);
                }
            }
            return new TypeEnergyValueObjEntity()
            {
                type = (int)type,
                name = type.ToString().GetREnergy(),
                list_energy = list,
            };
        }
        /// <summary>
        /// Получить список набора данных Доменный газ
        /// </summary>
        /// <returns></returns>
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

        #region Дутье
        public enum teBlast : int
        {
            cold_blast = 1,
            hot_blast
        }
        /// <summary>
        /// Получить набор данных Холодное дутье
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public EnergyValueObjEntity GetColdBlast(trObj obj)
        {
            EnergySutkiObject eso = list_energy_sutki.Find(e => e.trobj == obj);
            if (eso == null) return null;
            if (eso.energy_sutki is IColdBlast)
            {
                EnergyValueObjEntity evoe = new EnergyValueObjEntity()
                {
                    obj = (int)obj,
                    name = teBlast.cold_blast.ToString().GetREnergy() + " " + obj.ToString().GetResources(),
                    flow = new FlowValue(((IColdBlast)eso.energy_sutki).ColdBlast_flow, ("flow_sutky").GetREnergy(), ((IColdBlast)eso.energy_sutki).ColdBlast_flow_unit, ((IColdBlast)eso.energy_sutki).ColdBlast_flow_multiplier),
                    avg_temp = new TempValue(((IColdBlast)eso.energy_sutki).ColdBlast_temp, ("avg_temp").GetREnergy(), ((IColdBlast)eso.energy_sutki).ColdBlast_temp_unit, ((IColdBlast)eso.energy_sutki).ColdBlast_temp_multiplier),
                    avg_pressure = new PressureValue(((IColdBlast)eso.energy_sutki).ColdBlast_pressure, ("avg_pressure").GetREnergy(), ((IColdBlast)eso.energy_sutki).ColdBlast_pressure_unit, ((IColdBlast)eso.energy_sutki).ColdBlast_pressure_multiplier),
                    planimetric = new PlanimetricValue(((IColdBlast)eso.energy_sutki).ColdBlast_planimetric, ("planimetric_value").GetREnergy(), ((IColdBlast)eso.energy_sutki).ColdBlast_planimetric_unit, ((IColdBlast)eso.energy_sutki).ColdBlast_planimetric_multiplier),
                    pr_flow = new FlowValue(((IColdBlast)eso.energy_sutki).ColdBlast_pr_flow, ("pr_flow_sutky").GetREnergy(), ((IColdBlast)eso.energy_sutki).ColdBlast_pr_flow_unit, ((IColdBlast)eso.energy_sutki).ColdBlast_pr_flow_multiplier),
                    time_norm = new TimeValue(((IColdBlast)eso.energy_sutki).ColdBlast_time_norm, ("time_norm").GetREnergy(), ((IColdBlast)eso.energy_sutki).ColdBlast_time_norm_unit, ((IColdBlast)eso.energy_sutki).ColdBlast_time_norm_multiplier),
                    time_max = new TimeValue(((IColdBlast)eso.energy_sutki).ColdBlast_time_max, ("time_max").GetREnergy(), ((IColdBlast)eso.energy_sutki).ColdBlast_time_max_unit, ((IColdBlast)eso.energy_sutki).ColdBlast_time_max_multiplier),
                };
                return evoe;
            }
            return null;
        }
        /// <summary>
        /// Получить набор данных Горячее дутье
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public EnergyValueObjEntity GetHotBlast(trObj obj)
        {
            EnergySutkiObject eso = list_energy_sutki.Find(e => e.trobj == obj);
            if (eso == null) return null;
            if (eso.energy_sutki is IHotBlast)
            {
                EnergyValueObjEntity evoe = new EnergyValueObjEntity()
                {
                    obj = (int)obj,
                    name = teBlast.hot_blast.ToString().GetREnergy() + " " + obj.ToString().GetResources(),
                    flow = new FlowValue(((IHotBlast)eso.energy_sutki).HotBlast_flow, ("flow_sutky").GetREnergy(), ((IHotBlast)eso.energy_sutki).HotBlast_flow_unit, ((IHotBlast)eso.energy_sutki).HotBlast_flow_multiplier),
                    avg_temp = new TempValue(((IHotBlast)eso.energy_sutki).HotBlast_temp, ("avg_temp").GetREnergy(), ((IHotBlast)eso.energy_sutki).HotBlast_temp_unit, ((IHotBlast)eso.energy_sutki).HotBlast_temp_multiplier),
                    avg_pressure = new PressureValue(((IHotBlast)eso.energy_sutki).HotBlast_pressure, ("avg_pressure").GetREnergy(), ((IHotBlast)eso.energy_sutki).HotBlast_pressure_unit, ((IHotBlast)eso.energy_sutki).HotBlast_pressure_multiplier),
                    planimetric = new PlanimetricValue(((IHotBlast)eso.energy_sutki).HotBlast_planimetric, ("planimetric_value").GetREnergy(), ((IHotBlast)eso.energy_sutki).HotBlast_planimetric_unit, ((IHotBlast)eso.energy_sutki).HotBlast_planimetric_multiplier),
                    pr_flow = new FlowValue(((IHotBlast)eso.energy_sutki).HotBlast_pr_flow, ("pr_flow_sutky").GetREnergy(), ((IHotBlast)eso.energy_sutki).HotBlast_pr_flow_unit, ((IHotBlast)eso.energy_sutki).HotBlast_pr_flow_multiplier),
                    time_norm = new TimeValue(((IHotBlast)eso.energy_sutki).HotBlast_time_norm, ("time_norm").GetREnergy(), ((IHotBlast)eso.energy_sutki).HotBlast_time_norm_unit, ((IHotBlast)eso.energy_sutki).HotBlast_time_norm_multiplier),
                    time_max = new TimeValue(((IHotBlast)eso.energy_sutki).HotBlast_time_max, ("time_max").GetREnergy(), ((IHotBlast)eso.energy_sutki).HotBlast_time_max_unit, ((IHotBlast)eso.energy_sutki).HotBlast_time_max_multiplier),
                };
                return evoe;
            }
            return null;
        }
        /// <summary>
        /// Получить набор данных дутье
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public TypeEnergyValueObjEntity GetTypeBlast(teBlast type)
        {
            List<EnergyValueObjEntity> list = new List<EnergyValueObjEntity>();
            EnergyValueObjEntity evoe = null;
            foreach (trObj obj in base.trObjs)
            {
                switch (type)
                {
                    case teBlast.cold_blast: evoe = GetColdBlast(obj); break;
                    case teBlast.hot_blast: evoe = GetHotBlast(obj); break;
                    default: evoe = null; break;
                }
                if (evoe != null)
                {
                    list.Add(evoe);
                }
            }
            return new TypeEnergyValueObjEntity()
            {
                type = (int)type,
                name = type.ToString().GetREnergy(),
                list_energy = list,
            };
        }
        /// <summary>
        /// Получить список набора данных дутье
        /// </summary>
        /// <returns></returns>
        public List<TypeEnergyValueObjEntity> GetBlast()
        {
            List<TypeEnergyValueObjEntity> list = new List<TypeEnergyValueObjEntity>();
            foreach (teBlast type in Enum.GetValues(typeof(teBlast)))
            {
                list.Add(GetTypeBlast(type));
            }
            return list;
        }
        #endregion

        #region ПАР
        public enum teSteam : int
        {
            steam_bf = 1,
            steam_bl,
            steam_bvn,
        }
        ///// <summary>
        ///// Получить набор данных Холодное дутье
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <returns></returns>
        //public EnergyValueObjEntity GetColdBlast(trObj obj)
        //{
        //    EnergySutkiObject eso = list_energy_sutki.Find(e => e.trobj == obj);
        //    if (eso == null) return null;
        //    if (eso.energy_sutki is IColdBlast)
        //    {
        //        EnergyValueObjEntity evoe = new EnergyValueObjEntity()
        //        {
        //            obj = (int)obj,
        //            name = teBlast.cold_blast.ToString().GetREnergy() + " " + obj.ToString().GetResources(),
        //            flow = new FlowValue(((IColdBlast)eso.energy_sutki).ColdBlast_flow, ("flow_sutky").GetREnergy(), ((IColdBlast)eso.energy_sutki).ColdBlast_flow_unit, ((IColdBlast)eso.energy_sutki).ColdBlast_flow_multiplier),
        //            avg_temp = new TempValue(((IColdBlast)eso.energy_sutki).ColdBlast_temp, ("avg_temp").GetREnergy(), ((IColdBlast)eso.energy_sutki).ColdBlast_temp_unit, ((IColdBlast)eso.energy_sutki).ColdBlast_temp_multiplier),
        //            avg_pressure = new PressureValue(((IColdBlast)eso.energy_sutki).ColdBlast_pressure, ("avg_pressure").GetREnergy(), ((IColdBlast)eso.energy_sutki).ColdBlast_pressure_unit, ((IColdBlast)eso.energy_sutki).ColdBlast_pressure_multiplier),
        //            planimetric = new PlanimetricValue(((IColdBlast)eso.energy_sutki).ColdBlast_planimetric, ("planimetric_value").GetREnergy(), ((IColdBlast)eso.energy_sutki).ColdBlast_planimetric_unit, ((IColdBlast)eso.energy_sutki).ColdBlast_planimetric_multiplier),
        //            pr_flow = new FlowValue(((IColdBlast)eso.energy_sutki).ColdBlast_pr_flow, ("pr_flow_sutky").GetREnergy(), ((IColdBlast)eso.energy_sutki).ColdBlast_pr_flow_unit, ((IColdBlast)eso.energy_sutki).ColdBlast_pr_flow_multiplier),
        //            time_norm = new TimeValue(((IColdBlast)eso.energy_sutki).ColdBlast_time_norm, ("time_norm").GetREnergy(), ((IColdBlast)eso.energy_sutki).ColdBlast_time_norm_unit, ((IColdBlast)eso.energy_sutki).ColdBlast_time_norm_multiplier),
        //            time_max = new TimeValue(((IColdBlast)eso.energy_sutki).ColdBlast_time_max, ("time_max").GetREnergy(), ((IColdBlast)eso.energy_sutki).ColdBlast_time_max_unit, ((IColdBlast)eso.energy_sutki).ColdBlast_time_max_multiplier),
        //        };
        //        return evoe;
        //    }
        //    return null;
        //}
        /// <summary>
        /// Получить набор данных Пар на печь
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        //public EnergyValueObjEntity GetSteamBF(trObj obj)
        //{
        //    EnergySutkiObject eso = list_energy_sutki.Find(e => e.trobj == obj);
        //    if (eso == null) return null;
        //    if (eso.energy_sutki is ISteamBF)
        //    {
        //        EnergyValueObjEntity evoe = new EnergyValueObjEntity()
        //        {
        //            obj = (int)obj,
        //            name = teBlast.hot_blast.ToString().GetREnergy() + " " + obj.ToString().GetResources(),
        //            flow = new FlowValue(((IHotBlast)eso.energy_sutki).HotBlast_flow, ("flow_sutky").GetREnergy(), ((IHotBlast)eso.energy_sutki).HotBlast_flow_unit, ((IHotBlast)eso.energy_sutki).HotBlast_flow_multiplier),
        //            avg_temp = new TempValue(((IHotBlast)eso.energy_sutki).HotBlast_temp, ("avg_temp").GetREnergy(), ((IHotBlast)eso.energy_sutki).HotBlast_temp_unit, ((IHotBlast)eso.energy_sutki).HotBlast_temp_multiplier),
        //            avg_pressure = new PressureValue(((IHotBlast)eso.energy_sutki).HotBlast_pressure, ("avg_pressure").GetREnergy(), ((IHotBlast)eso.energy_sutki).HotBlast_pressure_unit, ((IHotBlast)eso.energy_sutki).HotBlast_pressure_multiplier),
        //            planimetric = new PlanimetricValue(((IHotBlast)eso.energy_sutki).HotBlast_planimetric, ("planimetric_value").GetREnergy(), ((IHotBlast)eso.energy_sutki).HotBlast_planimetric_unit, ((IHotBlast)eso.energy_sutki).HotBlast_planimetric_multiplier),
        //            pr_flow = new FlowValue(((IHotBlast)eso.energy_sutki).HotBlast_pr_flow, ("pr_flow_sutky").GetREnergy(), ((IHotBlast)eso.energy_sutki).HotBlast_pr_flow_unit, ((IHotBlast)eso.energy_sutki).HotBlast_pr_flow_multiplier),
        //            time_norm = new TimeValue(((IHotBlast)eso.energy_sutki).HotBlast_time_norm, ("time_norm").GetREnergy(), ((IHotBlast)eso.energy_sutki).HotBlast_time_norm_unit, ((IHotBlast)eso.energy_sutki).HotBlast_time_norm_multiplier),
        //            time_max = new TimeValue(((IHotBlast)eso.energy_sutki).HotBlast_time_max, ("time_max").GetREnergy(), ((IHotBlast)eso.energy_sutki).HotBlast_time_max_unit, ((IHotBlast)eso.energy_sutki).HotBlast_time_max_multiplier),
        //        };
        //        return evoe;
        //    }
        //    return null;
        //}
        /// <summary>
        /// Получить набор данных пар
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public TypeEnergyValueObjEntity GetTypeSteam(teSteam type)
        {
            List<EnergyValueObjEntity> list = new List<EnergyValueObjEntity>();
            EnergyValueObjEntity evoe = null;
            foreach (trObj obj in base.trObjs)
            {
                switch (type)
                {
                    //case teSteam.steam_bf: evoe = GetSteamBF(obj); break;
                    default: evoe = null; break;
                }
                if (evoe != null)
                {
                    list.Add(evoe);
                }
            }
            return new TypeEnergyValueObjEntity()
            {
                type = (int)type,
                name = type.ToString().GetREnergy(),
                list_energy = list,
            };
        }
        /// <summary>
        /// Получить список набора данных пар
        /// </summary>
        /// <returns></returns>
        public List<TypeEnergyValueObjEntity> GetSteam()
        {
            List<TypeEnergyValueObjEntity> list = new List<TypeEnergyValueObjEntity>();
            foreach (teSteam type in Enum.GetValues(typeof(teSteam)))
            {
                list.Add(GetTypeSteam(type));
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
                case groupEnergy.blast: list = GetBlast(); break;
                case groupEnergy.steam: list = GetSteam(); break;
            }
            return new GroupEnergyValueObjEntity()
            {
                group = group,
                name = group.ToString().GetResources(),
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
