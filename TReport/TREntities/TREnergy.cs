﻿using Measurement;
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
            public IEnergySutki energy_sutki { get; set; }
            public EnergySutkiObject(trObj trobj, IEnergySutki es)
                : base()
            {
                this.trobj = trobj;
                this.energy_sutki = es;
            }
        }

        protected List<EnergySutkiObject> list_energy_sutki = new List<EnergySutkiObject>(); // Список всех данных по всем объектам
        public List<EnergySutkiObject> ListEnergySutki { get { return this.list_energy_sutki; } }

        protected List<GroupEnergyValueObjEntity> list_group_energy_value = new List<GroupEnergyValueObjEntity>(); // Список полученых наборов данных по энергоресурсам
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
            return new EnergySutkiObject(trobj, data.GetEnergySutkiObject(date, trobj));

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
                list.Add(GetEnergySutkiObject(date, obj));
            }
            return list;
        }
        #endregion

        #region Природный газ

        public enum teNaturGas : int
        {
            natur_gas_bf = 1,
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
            EnergyValueObjEntity evoe = new EnergyValueObjEntity()
            {
                obj = (int)obj,
                name = GetEnergyResource(teNaturGas.natur_gas_bf.ToString()) + " " + base.GetResource(obj.ToString()),
                flow = new FlowValue(
                    (eso.energy_sutki.NG_flow != null ? (double)eso.energy_sutki.NG_flow : 0.0),
                    GetEnergyResource("flow_sutky"),
                    eso.energy_sutki.NG_flow_unit,
                    eso.energy_sutki.NG_flow_multiplier
                    ),
                avg_temp = new TempValue(
                    (eso.energy_sutki.NG_temp != null ? (double)eso.energy_sutki.NG_temp : 0.0),
                    GetEnergyResource("avg_temp"),
                    eso.energy_sutki.NG_temp_unit,
                    eso.energy_sutki.NG_temp_multiplier
                    ),
                avg_pressure = new PressureValue(
                    (eso.energy_sutki.NG_pressure != null ? (double)eso.energy_sutki.NG_pressure : 0.0),
                    GetEnergyResource("avg_pressure"),
                    eso.energy_sutki.NG_pressure_unit,
                    eso.energy_sutki.NG_pressure_multiplier
                    ),
                planimetric = new PlanimetricValue(
                    (eso.energy_sutki.NG_planimetric != null ? (double)eso.energy_sutki.NG_planimetric : 0.0),
                    GetEnergyResource("planimetric_value"),
                    eso.energy_sutki.NG_planimetric_unit,
                    eso.energy_sutki.NG_planimetric_multiplier
                    ),
                pr_flow = new FlowValue(
                    (eso.energy_sutki.NG_pr_flow != null ? (double)eso.energy_sutki.NG_pr_flow : 0.0),
                    GetEnergyResource("pr_flow_sutky"),
                    eso.energy_sutki.NG_pr_flow_unit,
                    eso.energy_sutki.NG_pr_flow_multiplier
                    ),
                time_norm = new TimeValue(
                    (eso.energy_sutki.NG_time_norm != null ? (int)eso.energy_sutki.NG_time_norm : 0),
                    GetEnergyResource("time_norm"),
                    eso.energy_sutki.NG_time_norm_unit,
                    eso.energy_sutki.NG_time_norm_multiplier
                    ),
                time_max = new TimeValue(
                    (eso.energy_sutki.NG_time_max != null ? (int)eso.energy_sutki.NG_time_max : 0),
                    GetEnergyResource("time_max"),
                    eso.energy_sutki.NG_time_max_unit,
                    eso.energy_sutki.NG_time_max_multiplier
                    ),
            };
            return evoe;
        }
        /// <summary>
        /// Получить набор данных природный газ
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public TypeEnergyValueObjEntity GetTypeNaturGas(teNaturGas type)
        {
            List<EnergyValueObjEntity> list = new List<EnergyValueObjEntity>();
            foreach (trObj obj in base.trObjs)
            {
                if (type == teNaturGas.natur_gas_bf) list.Add(GetNaturGasBF(obj));
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
        public List<TypeEnergyValueObjEntity> GetTypeNaturGas()
        {
            List<TypeEnergyValueObjEntity> list = new List<TypeEnergyValueObjEntity>();
            foreach (teNaturGas type in Enum.GetValues(typeof(teNaturGas)))
            {
                list.Add(GetTypeNaturGas(type));
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
                case groupEnergy.natur_gas: list = GetTypeNaturGas(); break;
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

        //public class TREnergoSutki
        //{
        //    public trObj trObj { get; set; }
        //    public DateTime datetime { get; set; }
        //    public EnergyValueEntity natural_gas_bf { get; set; }
        //    public EnergyValueEntity natural_gas_hpp { get; set; }
        //    public EnergyValueEntity natural_gas_technical_needs { get; set; }
        //}

        //public class BF9_TREnergoSutki : DataMeasurement<TREnergoSutki>
        //{
        //    public BF9_TREnergoSutki(EnergoSutki obj)
        //        : base(obj)
        //    {

        //    }

        //    public BF9_TREnergoSutki(List<EnergoSutki> list_obj)
        //        : base(list_obj)
        //    {

        //    }

        //    public string GetStringResource(string key)
        //    {
        //        ResourceManager resourceManager = new ResourceManager(typeof(Resources));
        //        return resourceManager.GetString(key, CultureInfo.CurrentCulture);
        //    }

        //    public override TREnergoSutki Convert(object obj)
        //    {
        //        try
        //        {
        //            return new TREnergoSutki()
        //            {
        //                trObj = TReport.trObj.dc2_dp9,
        //                datetime = ((EnergoSutki)obj).Date,
        //                natural_gas_bf = new EnergyValueEntity()
        //                {
        //                    name = GetStringResource("natural_gas_bf9"),//"Природный газ на ДП9",
        //                    flow = new FlowValue((double)((EnergoSutki)obj).DP_FPG24, "Расход за сутки", uFlow.m3_hour, Multiplier.thousand),
        //                    avg_temp = new TempValue((double)((EnergoSutki)obj).PrGazPech_T, "Средняя температура", uTemp.grad_C, Multiplier.No),
        //                    avg_pressure = new PressureValue((double)((EnergoSutki)obj).PrGazPech_P, "Средне давление", uPressure.kgs_sm2, Multiplier.No),
        //                    planimetric = new PlanimetricValue((double)((EnergoSutki)obj).PrGazPech_a, "Планиметрическое число", uPlanimetric.Np, Multiplier.No),
        //                    pr_flow = new FlowValue((((EnergoSutki)obj).Pr_Gaz_naPech != null ? (double)((EnergoSutki)obj).Pr_Gaz_naPech : 0.0), "Приведенный расход за сутки", uFlow.m3_hour, Multiplier.thousand),
        //                    time_norm = new TimeValue((double)((EnergoSutki)obj).PG_TimeN, "Время подачи, норма", uTime.min, Multiplier.No),
        //                    time_max = new TimeValue((double)((EnergoSutki)obj).PG_TimeM, "Время подачи, макс", uTime.min, Multiplier.No),
        //                },
        //                natural_gas_hpp = new EnergyValueEntity()
        //                {
        //                    name = "Природный газ на ТЭЦ-3",
        //                    flow = new FlowValue((double)((EnergoSutki)obj).DP_FGTets3sut, "Расход за сутки", uFlow.m3_hour, Multiplier.thousand),
        //                    planimetric = new PlanimetricValue((double)((EnergoSutki)obj).DP_PCHPGT3, "Планиметрическое число", uPlanimetric.Np, Multiplier.No),
        //                },
        //                natural_gas_technical_needs = new EnergyValueEntity()
        //                {
        //                    name = "Природный газ на технужды ДП9",
        //                    flow = new FlowValue((double)((EnergoSutki)obj).DP_FPGND24, "Расход за сутки", uFlow.m3_hour, Multiplier.thousand),
        //                }

        //            };
        //        }
        //        catch (Exception e)
        //        {
        //            return null;
        //        }
        //    }
        //}

        //public void GetEnergoSutki(DateTime date){
        //    foreach (trObj obj in Enum.GetValues(typeof(trObj)))
        //    {
        //        switch (obj) {
        //            case TReport.trObj.dc2_dp9:
        //                EFBF9.Concrete.EFBF9 efdp9 = new EFBF9.Concrete.EFBF9();
        //                List<EnergoSutki> list = efdp9.GetBF9EnergoSutki(DateTime.Now.AddDays(-1));
        //                if (list != null && list.Count > 0) {
        //                    this.list.Add(new BF9_TREnergoSutki(list[0]).ListData[0]);
        //                }
        //                break;


        //        }
        //    }


    }
}