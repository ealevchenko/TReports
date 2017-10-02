using EFBF8.DataSet;
using Measurement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TReport.TData.Interfaces;

namespace TReport.TData.DataSet
{
    public class bf8_DataEnergySutki : bf8_EnergySutki, IEnergySutki
    {
        public DateTime Date { get; set; }
        #region IESNaturGas

        #region Flow
        public double? NG_flow
        {
            get { return base.Fpg; }
        }

        public uFlow NG_flow_unit
        {
            get { return uFlow.m3_hour; }
        }

        public Multiplier NG_flow_multiplier
        {
            get { return Multiplier.thousand; }
        }
        #endregion

        #region Temp
        public double? NG_temp
        {
            get { return base.Tpg; }
        }

        public uTemp NG_temp_unit
        {
            get { return uTemp.grad_C; }
        }

        public Multiplier NG_temp_multiplier
        {
            get { return Multiplier.No; }
        }
        #endregion

        #region Pressure
        public double? NG_pressure
        {
            get { return base.Ppg; }
        }

        public uPressure NG_pressure_unit
        {
            get { return uPressure.kPa; }
        }

        public Multiplier NG_pressure_multiplier
        {
            get { return Multiplier.No; }
        }
        #endregion

        #region Planimetric
        public double? NG_planimetric
        {
            get { return base.Fpg_plan; }
        }

        public uPlanimetric NG_planimetric_unit
        {
            get { return uPlanimetric.Np; }
        }

        public Multiplier NG_planimetric_multiplier
        {
            get { return Multiplier.No; }
        }
        #endregion

        #region pr_Flow
        public double? NG_pr_flow
        {
            get { return null; }
        }

        public uFlow NG_pr_flow_unit
        {
            get { return uFlow.m3_hour; }
        }

        public Multiplier NG_pr_flow_multiplier
        {
            get { return Multiplier.thousand; }
        }
        #endregion

        #region pr_Time_norm
        public int? NG_time_norm
        {
            get { return (int)base.vr_pg_m; }
        }

        public uTime NG_time_norm_unit
        {
            get { return uTime.min; }
        }

        public Multiplier NG_time_norm_multiplier
        {
            get { return Multiplier.No; }
        }
        #endregion

        #region pr_Time_max
        public int? NG_time_max
        {
            get { return (int)base.vr_pg_m_98; }
        }

        public uTime NG_time_max_unit
        {
            get { return uTime.min; }
        }

        public Multiplier NG_time_max_multiplier
        {
            get { return Multiplier.No; }
        }
        #endregion

        #endregion

        public bf8_DataEnergySutki(bf8_EnergySutki es)
        {
            this.Date = DateTime.Parse(es.DT);
            base.Phd = es.Phd;
            base.Thd = es.Thd;
            base.Tgd = es.Tgd;
            base.Tkg_vyx = es.Tkg_vyx;
            base.Pkg_vyx = es.Pkg_vyx;
            base.O2_dut = es.O2_dut;
            base.Fhd_plan = es.Fhd_plan;
            base.Fkg_vyx_plan = es.Fkg_vyx_plan;
            base.Ppg = es.Ppg;
            base.Tpg = es.Tpg;
            base.Fpg_plan = es.Fpg_plan;
            base.Fpg = es.Fpg;
            base.klr_kg = es.klr_kg;
            base.Fskr_l = es.Fskr_l;
            base.Fskr_p = es.Fskr_p;
            base.Fdr_gr = es.Fdr_gr;
            base.Fvent_l = es.Fvent_l;
            base.Fvent_p = es.Fvent_p;
            base.P_hod_h = es.P_hod_h;
            base.P_hod_m = es.P_hod_m;
            base.P_hod_s = es.P_hod_s;
            base.t_hod_h = es.t_hod_h;
            base.t_hod_m = es.t_hod_m;
            base.t_hod_s = es.t_hod_s;
            base.ost_h = es.ost_h;
            base.ost_m = es.ost_m;
            base.ost_s = es.ost_s;
            base.vr_p_hod_m = es.vr_p_hod_m;
            base.vr_pg_m = es.vr_pg_m;
            base.vr_pg_m_98 = es.vr_pg_m_98;
            base.Fsj_tn = es.Fsj_tn;
            base.Fsj_RDU = es.Fsj_RDU;
            base.F_O2_tn = es.F_O2_tn;
            base.Fpar_pech = es.Fpar_pech;
            base.Fdg_VN1 = es.Fdg_VN1;
            base.T_kup_VN1 = es.T_kup_VN1;
            base.Tdym_VN1 = es.Tdym_VN1;
            base.nagr_h_VN1 = es.nagr_h_VN1;
            base.nagr_m_VN1 = es.nagr_m_VN1;
            base.dut_h_VN1 = es.dut_h_VN1;
            base.dut_m_VN1 = es.dut_m_VN1;
            base.ot_h_VN1 = es.ot_h_VN1;
            base.ot_m_VN1 = es.ot_m_VN1;
            base.Fdg_VN2 = es.Fdg_VN2;
            base.T_kup_VN2 = es.T_kup_VN2;
            base.Tdym_VN2 = es.Tdym_VN2;
            base.nagr_h_VN2 = es.nagr_h_VN2;
            base.nagr_m_VN2 = es.nagr_m_VN2;
            base.dut_h_VN2 = es.dut_h_VN2;
            base.dut_m_VN2 = es.dut_m_VN2;
            base.ot_h_VN2 = es.ot_h_VN2;
            base.ot_m_VN2 = es.ot_m_VN2;
            base.Fdg_VN3 = es.Fdg_VN3;
            base.T_kup_VN3 = es.T_kup_VN3;
            base.Tdym_VN3 = es.Tdym_VN3;
            base.nagr_h_VN3 = es.nagr_h_VN3;
            base.nagr_m_VN3 = es.nagr_m_VN3;
            base.dut_h_VN3 = es.dut_h_VN3;
            base.dut_m_VN3 = es.dut_m_VN3;
            base.ot_h_VN3 = es.ot_h_VN3;
            base.ot_m_VN3 = es.ot_m_VN3;
            base.Fdg_VN4 = es.Fdg_VN4;
            base.T_kup_VN4 = es.T_kup_VN4;
            base.Tdym_VN4 = es.Tdym_VN4;
            base.nagr_h_VN4 = es.nagr_h_VN4;
            base.nagr_m_VN4 = es.nagr_m_VN4;
            base.dut_h_VN4 = es.dut_h_VN4;
            base.dut_m_VN4 = es.dut_m_VN4;
            base.ot_h_VN4 = es.ot_h_VN4;
            base.ot_m_VN4 = es.ot_m_VN4;
            base.Fpar_mk = es.Fpar_mk;
            base.Fpar_uvl = es.Fpar_uvl;
            base.Fazot_pech = es.Fazot_pech;
            base.Fdg_BVN = es.Fdg_BVN;
            base.Fvozg_VN1 = es.Fvozg_VN1;
            base.Fvozg_VN2 = es.Fvozg_VN2;
            base.Fvozg_VN3 = es.Fvozg_VN3;
            base.Fvozg_VN4 = es.Fvozg_VN4;
            base.Ppar_all = es.Ppar_all;
            base.Tpar_all = es.Tpar_all;
            base.Fpar_all_plan = es.Fpar_all_plan;
            base.Psj_tn = es.Psj_tn;
            base.Tsj_tn = es.Tsj_tn;
            base.Fsj_tn_plan = es.Fsj_tn_plan;
            base.Psj_RDU = es.Psj_RDU;
            base.Tsj_RDU = es.Tsj_RDU;
            base.Fsj_RDU_plan = es.Fsj_RDU_plan;
            base.Pazot_pech = es.Pazot_pech;
            base.Tazot_pech = es.Tazot_pech;
            base.Fazot_pech_plan = es.Fazot_pech_plan;
            base.P_O2_tn = es.P_O2_tn;
            base.T_O2_tn = es.T_O2_tn;
            base.F_O2_tn_plan = es.F_O2_tn_plan;
            base.Fdg_VN1sr = es.Fdg_VN1sr;
            base.Tk_VN1sr_max_nagr = es.Tk_VN1sr_max_nagr;
            base.Td_VN1sr_max_nagr = es.Td_VN1sr_max_nagr;
            base.Tk_VN1sr_max_dut = es.Tk_VN1sr_max_dut;
            base.sr_vr_nagr_VN1 = es.sr_vr_nagr_VN1;
            base.sr_vr_dut_VN1 = es.sr_vr_dut_VN1;
            base.Fdg_VN2sr = es.Fdg_VN2sr;
            base.Tk_VN2sr_max_nagr = es.Tk_VN2sr_max_nagr;
            base.Td_VN2sr_max_nagr = es.Td_VN2sr_max_nagr;
            base.Tk_VN2sr_max_dut = es.Tk_VN2sr_max_dut;
            base.sr_vr_nagr_VN2 = es.sr_vr_nagr_VN2;
            base.sr_vr_dut_VN2 = es.sr_vr_dut_VN2;
            base.Fdg_VN3sr = es.Fdg_VN3sr;
            base.Tk_VN3sr_max_nagr = es.Tk_VN3sr_max_nagr;
            base.Td_VN3sr_max_nagr = es.Td_VN3sr_max_nagr;
            base.Tk_VN3sr_max_dut = es.Tk_VN3sr_max_dut;
            base.sr_vr_nagr_VN3 = es.sr_vr_nagr_VN3;
            base.sr_vr_dut_VN3 = es.sr_vr_dut_VN3;
            base.Fdg_VN4sr = es.Fdg_VN4sr;
            base.Tk_VN4sr_max_nagr = es.Tk_VN4sr_max_nagr;
            base.Td_VN4sr_max_nagr = es.Td_VN4sr_max_nagr;
            base.Tk_VN4sr_max_dut = es.Tk_VN4sr_max_dut;
            base.sr_vr_nagr_VN4 = es.sr_vr_nagr_VN4;
            base.sr_vr_dut_VN4 = es.sr_vr_dut_VN4;
            base.Pdg_BVN = es.Pdg_BVN;
            base.Tdg_BVN = es.Tdg_BVN;
            base.Fdg_BVN_plan = es.Fdg_BVN_plan;
            base.vr_dg_BVN_m = es.vr_dg_BVN_m;
            base.vr_dg_BVN_m_98 = es.vr_dg_BVN_m_98;
            base.F_v_vd = es.F_v_vd;
            base.F_v_vd_bk = es.F_v_vd_bk;
            base.F_zal_p = es.F_zal_p;
            base.Ftv = es.Ftv;
            base.Fvg_VN1sr = es.Fvg_VN1sr;
            base.Fvg_VN2sr = es.Fvg_VN2sr;
            base.Fvg_VN3sr = es.Fvg_VN3sr;
            base.Fvg_VN4sr = es.Fvg_VN4sr;
            base.Fhd = es.Fhd;
            base.Pgd = es.Pgd;
            base.Fkg_vyx = es.Fkg_vyx;
            base.Fpar_p = es.Fpar_p;
            base.Pbar = es.Pbar;
            base.Fazot = es.Fazot;
            base.Pkg = es.Pkg;
            base.Fnat_gas_teh = es.Fnat_gas_teh;
            base.FDG_na_svechu = es.FDG_na_svechu;
            base.D_BF_GAS_AVER = es.D_BF_GAS_AVER;
        }



    }
}
