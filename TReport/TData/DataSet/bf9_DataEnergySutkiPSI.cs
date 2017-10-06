using EFBF9.DataSet;
using Measurement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TReport.TData.Interfaces;

namespace TReport.TData.DataSet
{
    public class bf9_DataEnergySutkiPSI : bf9_EnergySutkiPSI, INaturGas_PSI
    {
        #region INaturGas_PSI

        #region Flow
        public double? NG_PSI_flow
        {
            get { return base.PG_PUT_F_SUT; }
        }

        public uFlow NG_PSI_flow_unit
        {
            get { return uFlow.m3_sutki; }
        }

        public Multiplier NG_PSI_flow_multiplier
        {
            get { return Multiplier.not; }
        }
        #endregion

        #region Temp
        public double? NG_PSI_temp
        {
            get { return base.PG_PUT_T_AVG; }
        }

        public uTemp NG_PSI_temp_unit
        {
            get { return uTemp.grad_C; }
        }

        public Multiplier NG_PSI_temp_multiplier
        {
            get { return Multiplier.not; }
        }
        #endregion

        #region Pressure
        public double? NG_PSI_pressure
        {
            get { return base.PG_PUT_P_AVG; }
        }

        public uPressure NG_PSI_pressure_unit
        {
            get { return uPressure.bar; }
        }

        public Multiplier NG_PSI_pressure_multiplier
        {
            get { return Multiplier.not; }
        }
        #endregion

        #region Planimetric
        public double? NG_PSI_planimetric
        {
            get { return null; }
        }

        public uPlanimetric NG_PSI_planimetric_unit
        {
            get { return uPlanimetric.not; }
        }

        public Multiplier NG_PSI_planimetric_multiplier
        {
            get { return Multiplier.not; }
        }
        #endregion

        #region pr_Flow
        public double? NG_PSI_pr_flow
        {
            get { return base.PG_PUT_F_SUT_PRIV; }
        }

        public uFlow NG_PSI_pr_flow_unit
        {
            get { return uFlow.m3_sutki; }
        }

        public Multiplier NG_PSI_pr_flow_multiplier
        {
            get { return Multiplier.not; }
        }
        #endregion

        #region pr_Time_norm
        public int? NG_PSI_time_norm
        {
            get { return (int?)base.PG_PUT_F_TIME; }
        }

        public uTime NG_PSI_time_norm_unit
        {
            get { return uTime.min; }
        }

        public Multiplier NG_PSI_time_norm_multiplier
        {
            get { return Multiplier.not; }
        }
        #endregion

        #region pr_Time_max
        public int? NG_PSI_time_max
        {
            get { return (int?)null; }
        }

        public uTime NG_PSI_time_max_unit
        {
            get { return uTime.not; }
        }

        public Multiplier NG_PSI_time_max_multiplier
        {
            get { return Multiplier.not; }
        }
        #endregion

        #endregion

        public bf9_DataEnergySutkiPSI(bf9_EnergySutkiPSI es)
        {
            base.id_es_put = es.id_es_put;
            base.DT = es.DT;
            base.PG_PUT_F_AVG = es.PG_PUT_F_AVG;
            base.PG_PUT_F_SUT = es.PG_PUT_F_SUT;
            base.PG_PUT_F_SUT_PRIV = es.PG_PUT_F_SUT_PRIV;
            base.PG_PUT_F_TIME = es.PG_PUT_F_TIME;
            base.PG_PUT_P_AVG = es.PG_PUT_P_AVG;
            base.PG_PUT_T_AVG = es.PG_PUT_T_AVG;
            base.PG_PUT_F_SUT_DANIELI = es.PG_PUT_F_SUT_DANIELI;
            base.PCI_AVG_N2_P = es.PCI_AVG_N2_P;
            base.PCI_AVG_N2_T = es.PCI_AVG_N2_T;
            base.PCI_AVG_N2_F = es.PCI_AVG_N2_F;
            base.PCI_N2_F_SUTKI = es.PCI_N2_F_SUTKI;
            base.PCI_N2_TIME = es.PCI_N2_TIME;
            base.PCI_N2_F_PRIV = es.PCI_N2_F_PRIV;
            base.PCI_N2_F_PRIV_SUT_RAZGAR = es.PCI_N2_F_PRIV_SUT_RAZGAR;
            base.PCI_N2_F_PRIV_SUT_DANIELI = es.PCI_N2_F_PRIV_SUT_DANIELI;
            base.PCI_N2_PRIV_TIME = es.PCI_N2_PRIV_TIME;
            base.PCI_AVG_WATER_P = es.PCI_AVG_WATER_P;
            base.PCI_AVG_WATER_F = es.PCI_AVG_WATER_F;
            base.PCI_WATER_F_SUT_RAZGAR = es.PCI_WATER_F_SUT_RAZGAR;
            base.PCI_WATER_F_SUT_DANIELI = es.PCI_WATER_F_SUT_DANIELI;
            base.PCI_WATER_TIME = es.PCI_WATER_TIME;
            base.PCI_AVG_FY = es.PCI_AVG_FY;
            base.PCI_FY_SUTKI = es.PCI_FY_SUTKI;
            base.PCI_FY_TIME = es.PCI_FY_TIME;
            base.PCI_TKG_D1 = es.PCI_TKG_D1;
            base.PCI_TKG_D2 = es.PCI_TKG_D2;
            base.PCI_FPG_AVG_M_ON = es.PCI_FPG_AVG_M_ON;
            base.PCI_FPG_TIME_M_ON = es.PCI_FPG_TIME_M_ON;
            base.PCI_FPG_AVG_M_OFF = es.PCI_FPG_AVG_M_OFF;
            base.PCI_FPG_TIME_M_OFF = es.PCI_FPG_TIME_M_OFF;
            base.PCI_FY_SUTKI_2 = es.PCI_FY_SUTKI_2;
        }

    }
}
