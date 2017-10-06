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
    public class bf9_DataEnergySutki : bf9_EnergySutki, INaturGas_BF, INaturGas_HPP3, INaturGas_TN, IBlastFurnaceGas_BVN, ITopGas
    {

        #region IESNaturGas

        #region Flow
        public double? NG_BF_flow
        {
            get { return base.DP_FPG24; }
        }

        public uFlow NG_BF_flow_unit
        {
            get { return uFlow.m3_sutki; }
        }

        public Multiplier NG_BF_flow_multiplier
        {
            get { return Multiplier.thousand; }
        }
        #endregion

        #region Temp
        public double? NG_BF_temp
        {
            get { return base.PrGazPech_T; }
        }

        public uTemp NG_BF_temp_unit
        {
            get { return uTemp.grad_C; }
        }

        public Multiplier NG_BF_temp_multiplier
        {
            get { return Multiplier.not; }
        }
        #endregion

        #region Pressure
        public double? NG_BF_pressure
        {
            get { return base.PrGazPech_P; }
        }

        public uPressure NG_BF_pressure_unit
        {
            get { return uPressure.kg_sm2; }
        }

        public Multiplier NG_BF_pressure_multiplier
        {
            get { return Multiplier.not; }
        }
        #endregion

        #region Planimetric
        public double? NG_BF_planimetric
        {
            get { return base.PrGazPech_a; }
        }

        public uPlanimetric NG_BF_planimetric_unit
        {
            get { return uPlanimetric.Np; }
        }

        public Multiplier NG_BF_planimetric_multiplier
        {
            get { return Multiplier.not; }
        }
        #endregion

        #region pr_Flow
        public double? NG_BF_pr_flow
        {
            get { return base.Pr_Gaz_naPech; }
        }

        public uFlow NG_BF_pr_flow_unit
        {
            get { return uFlow.m3_sutki; }
        }

        public Multiplier NG_BF_pr_flow_multiplier
        {
            get { return Multiplier.thousand; }
        }
        #endregion

        #region pr_Time_norm
        public int? NG_BF_time_norm
        {
            get { return (int?)base.PG_TimeN; }
        }

        public uTime NG_BF_time_norm_unit
        {
            get { return uTime.min; }
        }

        public Multiplier NG_BF_time_norm_multiplier
        {
            get { return Multiplier.not; }
        }
        #endregion

        #region pr_Time_max
        public int? NG_BF_time_max
        {
            get { return (int?)base.PG_TimeM; }
        }

        public uTime NG_BF_time_max_unit
        {
            get { return uTime.min; }
        }

        public Multiplier NG_BF_time_max_multiplier
        {
            get { return Multiplier.not; }
        }
        #endregion

        #endregion

        #region INaturGas_HPP3

        public double? NG_HPP3_flow
        {
            get { return this.DP_FGTets3sut; }
        }

        public uFlow NG_HPP3_flow_unit
        {
            get { return uFlow.m3_sutki; }
        }

        public Multiplier NG_HPP3_flow_multiplier
        {
            get { return Multiplier.thousand; }
        }

        public double? NG_HPP3_temp
        {
            get { return null;  }
        }

        public uTemp NG_HPP3_temp_unit
        {
            get { return uTemp.not; }
        }

        public Multiplier NG_HPP3_temp_multiplier
        {
            get { return Multiplier.not; }
        }

        public double? NG_HPP3_pressure
        {
            get { return null; }
        }

        public uPressure NG_HPP3_pressure_unit
        {
            get { return uPressure.not; }
        }

        public Multiplier NG_HPP3_pressure_multiplier
        {
            get { return Multiplier.not; }
        }

        public double? NG_HPP3_planimetric
        {
            get { return this.DP_PCHPGT3; }
        }

        public uPlanimetric NG_HPP3_planimetric_unit
        {
            get { return uPlanimetric.Np; }
        }

        public Multiplier NG_HPP3_planimetric_multiplier
        {
            get { return Multiplier.not; }
        }

        public double? NG_HPP3_pr_flow
        {
            get { return null; }
        }

        public uFlow NG_HPP3_pr_flow_unit
        {
            get { return uFlow.not; }
        }

        public Multiplier NG_HPP3_pr_flow_multiplier
        {
            get { return Multiplier.not; }
        }

        public int? NG_HPP3_time_norm
        {
            get { return null; }
        }

        public uTime NG_HPP3_time_norm_unit
        {
            get { return uTime.not; }
        }

        public Multiplier NG_HPP3_time_norm_multiplier
        {
            get { return Multiplier.not; }
        }

        public int? NG_HPP3_time_max
        {
            get { return null; }
        }

        public uTime NG_HPP3_time_max_unit
        {
            get { return uTime.not; }
        }

        public Multiplier NG_HPP3_time_max_multiplier
        {
            get { return Multiplier.not; }
        }

        #endregion

        #region INaturGas_TN
        public double? NG_TN_flow
        {
            get { return this.DP_FPGND24; }
        }

        public uFlow NG_TN_flow_unit
        {
            get { return uFlow.m3_sutki; }
        }

        public Multiplier NG_TN_flow_multiplier
        {
            get { return Multiplier.thousand; }
        }

        public double? NG_TN_temp
        {
            get { return null; }
        }

        public uTemp NG_TN_temp_unit
        {
            get { return uTemp.not; }
        }

        public Multiplier NG_TN_temp_multiplier
        {
            get { return Multiplier.not; }
        }

        public double? NG_TN_pressure
        {
            get { return null; }
        }

        public uPressure NG_TN_pressure_unit
        {
            get { return uPressure.not; }
        }

        public Multiplier NG_TN_pressure_multiplier
        {
            get { return Multiplier.not; }
        }

        public double? NG_TN_planimetric
        {
            get { return null; }
        }

        public uPlanimetric NG_TN_planimetric_unit
        {
            get { return uPlanimetric.not; }
        }

        public Multiplier NG_TN_planimetric_multiplier
        {
            get { return Multiplier.not; }
        }

        public double? NG_TN_pr_flow
        {
            get { return null; }
        }

        public uFlow NG_TN_pr_flow_unit
        {
            get { return uFlow.not; }
        }

        public Multiplier NG_TN_pr_flow_multiplier
        {
            get { return Multiplier.not; }
        }

        public int? NG_TN_time_norm
        {
            get { return null; }
        }

        public uTime NG_TN_time_norm_unit
        {
            get { return uTime.not; }
        }

        public Multiplier NG_TN_time_norm_multiplier
        {
            get { return Multiplier.not; }
        }

        public int? NG_TN_time_max
        {
            get { return null; }
        }

        public uTime NG_TN_time_max_unit
        {
            get { return uTime.not; }
        }

        public Multiplier NG_TN_time_max_multiplier
        {
            get { return Multiplier.not; }
        }
        #endregion

        #region IBlastFurnaceGas_BVN

        #region Flow
        public double? BFG_BVN_flow
        {
            get { return base.FDG_BVN_24; }
        }

        public uFlow BFG_BVN_flow_unit
        {
            get { return uFlow.m3_sutki; }
        }

        public Multiplier BFG_BVN_flow_multiplier
        {
            get { return Multiplier.thousand; }
        }
        #endregion

        #region Temp
        public double? BFG_BVN_temp
        {
            get { return base.BVNdomgaz_T; }
        }

        public uTemp BFG_BVN_temp_unit
        {
            get { return uTemp.grad_C; }
        }

        public Multiplier BFG_BVN_temp_multiplier
        {
            get { return Multiplier.not; }
        }
        #endregion

        #region Pressure
        public double? BFG_BVN_pressure
        {
            get { return base.BVNdomgaz_P; }
        }

        public uPressure BFG_BVN_pressure_unit
        {
            get { return uPressure.kgs_sm2; }
        }

        public Multiplier BFG_BVN_pressure_multiplier
        {
            get { return Multiplier.not; }
        }
        #endregion

        #region Planimetric
        public double? BFG_BVN_planimetric
        {
            get { return base.BVNdomgaz_a; }
        }

        public uPlanimetric BFG_BVN_planimetric_unit
        {
            get { return uPlanimetric.Np; }
        }

        public Multiplier BFG_BVN_planimetric_multiplier
        {
            get { return Multiplier.not; }
        }
        #endregion

        #region pr_Flow
        public double? BFG_BVN_pr_flow
        {
            get { return base.Dom_Gaz_naBVN; }
        }

        public uFlow BFG_BVN_pr_flow_unit
        {
            get { return uFlow.m3_sutki; }
        }

        public Multiplier BFG_BVN_pr_flow_multiplier
        {
            get { return Multiplier.thousand; }
        }
        #endregion

        #region pr_Time_norm
        public int? BFG_BVN_time_norm
        {
            get { return (int?)base.DGBVN_TimeN; }
        }

        public uTime BFG_BVN_time_norm_unit
        {
            get { return uTime.min; }
        }

        public Multiplier BFG_BVN_time_norm_multiplier
        {
            get { return Multiplier.not; }
        }
        #endregion

        #region pr_Time_max
        public int? BFG_BVN_time_max
        {
            get { return (int?)base.DGBVN_TimeM; }
        }

        public uTime BFG_BVN_time_max_unit
        {
            get { return uTime.min; }
        }

        public Multiplier BFG_BVN_time_max_multiplier
        {
            get { return Multiplier.not; }
        }
        #endregion

        #endregion

        #region ITopGas

        #region Flow
        public double? TopGas_flow
        {
            get { return base.FDG_CLR_24; }
        }

        public uFlow TopGas_flow_unit
        {
            get { return uFlow.m3_sutki; }
        }

        public Multiplier TopGas_flow_multiplier
        {
            get { return Multiplier.thousand; }
        }
        #endregion

        #region Temp
        public double? TopGas_temp
        {
            get { return base.PrGazPech_T; }
        }

        public uTemp TopGas_temp_unit
        {
            get { return uTemp.grad_C; }
        }

        public Multiplier TopGas_temp_multiplier
        {
            get { return Multiplier.not; }
        }
        #endregion

        #region Pressure
        public double? TopGas_pressure
        {
            get { return base.CLRdomgas_P; }
        }

        public uPressure TopGas_pressure_unit
        {
            get { return uPressure.kgs_sm2; }
        }

        public Multiplier TopGas_pressure_multiplier
        {
            get { return Multiplier.not; }
        }
        #endregion

        #region Planimetric
        public double? TopGas_planimetric
        {
            get { return base.CLRdomgas_a; }
        }

        public uPlanimetric TopGas_planimetric_unit
        {
            get { return uPlanimetric.Nk; }
        }

        public Multiplier TopGas_planimetric_multiplier
        {
            get { return Multiplier.not; }
        }
        #endregion

        #region pr_Flow
        public double? TopGas_pr_flow
        {
            get { return base.Vixod_poluchistogo; }
        }

        public uFlow TopGas_pr_flow_unit
        {
            get { return uFlow.m3_sutki; }
        }

        public Multiplier TopGas_pr_flow_multiplier
        {
            get { return Multiplier.thousand; }
        }
        #endregion

        #region pr_Time_norm
        public int? TopGas_time_norm
        {
            get { return (int?)base.VKG_TimeN; }
        }

        public uTime TopGas_time_norm_unit
        {
            get { return uTime.min; }
        }

        public Multiplier TopGas_time_norm_multiplier
        {
            get { return Multiplier.not; }
        }
        #endregion

        #region pr_Time_max
        public int? TopGas_time_max
        {
            get { return (int?)base.VKG_TimeM; }
        }

        public uTime TopGas_time_max_unit
        {
            get { return uTime.min; }
        }

        public Multiplier TopGas_time_max_multiplier
        {
            get { return Multiplier.not; }
        }
        #endregion

        #endregion

        public bf9_DataEnergySutki(bf9_EnergySutki es)
        {
            base.Date = es.Date;
            base.Rodom_Gaz = es.Rodom_Gaz;
            base.Ronatur_Gaz = es.Ronatur_Gaz;
            base.Pb = es.Pb;
            base.Q = es.Q;
            base.Vixod_poluchistogo = es.Vixod_poluchistogo;
            base.Dom_Gaz_naBVN = es.Dom_Gaz_naBVN;
            base.Pr_Gaz_naPech = es.Pr_Gaz_naPech;
            base.Blow_Cold_m = es.Blow_Cold_m;
            base.Blow_Cold_s = es.Blow_Cold_s;
            base.Rasxod_Pres_air_GU = es.Rasxod_Pres_air_GU;
            base.Rasxod_Pres_air_LD = es.Rasxod_Pres_air_LD;
            base.FDG_BVN_24 = es.FDG_BVN_24;
            base.FDG_CLR_24 = es.FDG_CLR_24;
            base.CLRdomgas_T = es.CLRdomgas_T;
            base.CLRdomgas_P = es.CLRdomgas_P;
            base.CLRdomgas_a = es.CLRdomgas_a;
            base.BVNdomgaz_T = es.BVNdomgaz_T;
            base.BVNdomgaz_P = es.BVNdomgaz_P;
            base.BVNdomgaz_a = es.BVNdomgaz_a;
            base.CoolFlow_T = es.CoolFlow_T;
            base.CoolFlow_P = es.CoolFlow_P;
            base.CoolFlow_a = es.CoolFlow_a;
            base.Par1_T = es.Par1_T;
            base.Par1_P = es.Par1_P;
            base.Par1_a = es.Par1_a;
            base.Par2_T = es.Par2_T;
            base.Par2_P = es.Par2_P;
            base.Par2_a = es.Par2_a;
            base.N1_T = es.N1_T;
            base.N1_P = es.N1_P;
            base.N1_a = es.N1_a;
            base.PrGazPech_T = es.PrGazPech_T;
            base.PrGazPech_P = es.PrGazPech_P;
            base.PrGazPech_a = es.PrGazPech_a;
            base.PresAirLD_T = es.PresAirLD_T;
            base.PresAirLD_P = es.PresAirLD_P;
            base.PresAirLD_a = es.PresAirLD_a;
            base.PressAirGL_T = es.PressAirGL_T;
            base.PressAirGL_P = es.PressAirGL_P;
            base.PressAirGR_T = es.PressAirGR_T;
            base.PressAirGR_P = es.PressAirGR_P;
            base.DP_FPG24 = es.DP_FPG24;
            base.DP_FCB24 = es.DP_FCB24;
            base.DP_FPRP124 = es.DP_FPRP124;
            base.DP_FPRP224 = es.DP_FPRP224;
            base.DP_FN2P124 = es.DP_FN2P124;
            base.DP_FN2P224 = es.DP_FN2P224;
            base.DP_FWCP124 = es.DP_FWCP124;
            base.DP_FWCP224 = es.DP_FWCP224;
            base.DP_FWCP324 = es.DP_FWCP324;
            base.SHIHTA_MKSute = es.SHIHTA_MKSute;
            base.DP_FPGND24 = es.DP_FPGND24;
            base.DP_FZV24 = es.DP_FZV24;
            base.DP_FGTets3sut = es.DP_FGTets3sut;
            base.DP_twb = es.DP_twb;
            base.GL_FVG124 = es.GL_FVG124;
            base.GL_FVG224 = es.GL_FVG224;
            base.GL_FVWL124 = es.GL_FVWL124;
            base.GL_FVWL224 = es.GL_FVWL224;
            base.GL_FVSL124 = es.GL_FVSL124;
            base.GL_FVSL224 = es.GL_FVSL224;
            base.GR_FVG124 = es.GR_FVG124;
            base.GR_FVG224 = es.GR_FVG224;
            base.GR_FVWL124 = es.GR_FVWL124;
            base.GR_FVWL224 = es.GR_FVWL224;
            base.GR_FVSL124 = es.GR_FVSL124;
            base.GR_FVSL224 = es.GR_FVSL224;
            base.DP_FPRBL24 = es.DP_FPRBL24;
            base.BVN1_SEP_FPV24 = es.BVN1_SEP_FPV24;
            base.BVN2_SEP_FPV24 = es.BVN2_SEP_FPV24;
            base.BVN3_SEP_FPV24 = es.BVN3_SEP_FPV24;
            base.BVN4_SEP_FPV24 = es.BVN4_SEP_FPV24;
            base.GL_FCDL = es.GL_FCDL;
            base.GR_FCDR = es.GR_FCDR;
            base.GL_FCAL = es.GL_FCAL;
            base.GRL_FCAR = es.GRL_FCAR;
            base.DP_PKG24 = es.DP_PKG24;
            base.DP_TKG24 = es.DP_TKG24;
            base.DP_TPRBL24 = es.DP_TPRBL24;
            base.DP_PPRBL24 = es.DP_PPRBL24;
            base.N2_T = es.N2_T;
            base.N2_P = es.N2_P;
            base.N2_a = es.N2_a;
            base.PG_TimeN = es.PG_TimeN;
            base.PG_TimeM = es.PG_TimeM;
            base.VKG_TimeN = es.VKG_TimeN;
            base.VKG_TimeM = es.VKG_TimeM;
            base.DGBVN_TimeN = es.DGBVN_TimeN;
            base.DGBVN_TimeM = es.DGBVN_TimeM;
            base.O2_TN = es.O2_TN;
            base.Gran_Shlak = es.Gran_Shlak;
            base.O2_TN_P = es.O2_TN_P;
            base.O2_TN_T = es.O2_TN_T;
            base.O2_TN_a = es.O2_TN_a;
            base.DP_PCHPGT3 = es.DP_PCHPGT3;
            base.DP_TGD24 = es.DP_TGD24;
            base.DP_PGD24 = es.DP_PGD24;
            base.GL_TCAPGU = es.GL_TCAPGU;
            base.GR_PCAR = es.GR_PCAR;
            base.GL_PCAL = es.GL_PCAL;
            base.GUNS_TLetkiAvgSutki = es.GUNS_TLetkiAvgSutki;
            base.BVN_TRN1avg = es.BVN_TRN1avg;
            base.BVN_TRN2avg = es.BVN_TRN2avg;
            base.BVN_TRN3avg = es.BVN_TRN3avg;
            base.BVN_TRN4avg = es.BVN_TRN4avg;
            base.BVN_TRD1avg = es.BVN_TRD1avg;
            base.BVN_TRD2avg = es.BVN_TRD2avg;
            base.BVN_TRD3avg = es.BVN_TRD3avg;
            base.BVN_TRD4avg = es.BVN_TRD4avg;
            base.BVN_TKMaxRN1avg = es.BVN_TKMaxRN1avg;
            base.BVN_TKMaxRN2avg = es.BVN_TKMaxRN2avg;
            base.BVN_TKMaxRN3avg = es.BVN_TKMaxRN3avg;
            base.BVN_TKMaxRN4avg = es.BVN_TKMaxRN4avg;
            base.BVN_TKMaxRD1avg = es.BVN_TKMaxRD1avg;
            base.BVN_TKMaxRD2avg = es.BVN_TKMaxRD2avg;
            base.BVN_TKMaxRD3avg = es.BVN_TKMaxRD3avg;
            base.BVN_TKMaxRD4avg = es.BVN_TKMaxRD4avg;
            base.BVN_TDMaxRN1avg = es.BVN_TDMaxRN1avg;
            base.BVN_TDMaxRN2avg = es.BVN_TDMaxRN2avg;
            base.BVN_TDMaxRN3avg = es.BVN_TDMaxRN3avg;
            base.BVN_TDMaxRN4avg = es.BVN_TDMaxRN4avg;
            base.BVN_FDG1avg = es.BVN_FDG1avg;
            base.BVN_FDG2avg = es.BVN_FDG2avg;
            base.BVN_FDG3avg = es.BVN_FDG3avg;
            base.BVN_FDG4avg = es.BVN_FDG4avg;
            base.BVN_FVG1avg = es.BVN_FVG1avg;
            base.BVN_FVG2avg = es.BVN_FVG2avg;
            base.BVN_FVG3avg = es.BVN_FVG3avg;
            base.BVN_FVG4avg = es.BVN_FVG4avg;
            base.DP_O2CD124 = es.DP_O2CD124;
            base.WL_domgaz = es.WL_domgaz;
        }

    }
}
