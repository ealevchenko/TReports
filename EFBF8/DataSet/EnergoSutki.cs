using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFBF8.DataSet
{
    public class bf8_EnergySutki
    {
        #region Данные
        public string DT { get; set; }
        public float? Phd { get; set; }
        public float? Thd { get; set; }
        public float? Tgd { get; set; }
        public float? Tkg_vyx { get; set; }
        public float? Pkg_vyx { get; set; }
        public float? O2_dut { get; set; }
        public float? Fhd_plan { get; set; }
        public float? Fkg_vyx_plan { get; set; }
        public float? Ppg { get; set; }
        public float? Tpg { get; set; }
        public float? Fpg_plan { get; set; }
        public float? Fpg { get; set; }
        public float? klr_kg { get; set; }
        public float? Fskr_l { get; set; }
        public float? Fskr_p { get; set; }
        public float? Fdr_gr { get; set; }
        public float? Fvent_l { get; set; }
        public float? Fvent_p { get; set; }
        public int? P_hod_h { get; set; }
        public int? P_hod_m { get; set; }
        public int? P_hod_s { get; set; }
        public int? t_hod_h { get; set; }
        public int? t_hod_m { get; set; }
        public int? t_hod_s { get; set; }
        public int? ost_h { get; set; }
        public int? ost_m { get; set; }
        public int? ost_s { get; set; }
        public float? vr_p_hod_m { get; set; }
        public float? vr_pg_m { get; set; }
        public float? vr_pg_m_98 { get; set; }
        public float? Fsj_tn { get; set; }
        public float? Fsj_RDU { get; set; }
        public float? F_O2_tn { get; set; }
        public float? Fpar_pech { get; set; }
        public float? Fdg_VN1 { get; set; }
        public float? T_kup_VN1 { get; set; }
        public float? Tdym_VN1 { get; set; }
        public float? nagr_h_VN1 { get; set; }
        public int? nagr_m_VN1 { get; set; }
        public int? dut_h_VN1 { get; set; }
        public int? dut_m_VN1 { get; set; }
        public int? ot_h_VN1 { get; set; }
        public int? ot_m_VN1 { get; set; }
        public float? Fdg_VN2 { get; set; }
        public float? T_kup_VN2 { get; set; }
        public float? Tdym_VN2 { get; set; }
        public int? nagr_h_VN2 { get; set; }
        public int? nagr_m_VN2 { get; set; }
        public int? dut_h_VN2 { get; set; }
        public int? dut_m_VN2 { get; set; }
        public int? ot_h_VN2 { get; set; }
        public int? ot_m_VN2 { get; set; }
        public float? Fdg_VN3 { get; set; }
        public float? T_kup_VN3 { get; set; }
        public float? Tdym_VN3 { get; set; }
        public int? nagr_h_VN3 { get; set; }
        public int? nagr_m_VN3 { get; set; }
        public int? dut_h_VN3 { get; set; }
        public int? dut_m_VN3 { get; set; }
        public int? ot_h_VN3 { get; set; }
        public int? ot_m_VN3 { get; set; }
        public float? Fdg_VN4 { get; set; }
        public float? T_kup_VN4 { get; set; }
        public float? Tdym_VN4 { get; set; }
        public int? nagr_h_VN4 { get; set; }
        public int? nagr_m_VN4 { get; set; }
        public int? dut_h_VN4 { get; set; }
        public int? dut_m_VN4 { get; set; }
        public int? ot_h_VN4 { get; set; }
        public int? ot_m_VN4 { get; set; }
        public float? Fpar_mk { get; set; }
        public float? Fpar_uvl { get; set; }
        public float? Fazot_pech { get; set; }
        public float? Fdg_BVN { get; set; }
        public float? Fvozg_VN1 { get; set; }
        public float? Fvozg_VN2 { get; set; }
        public float? Fvozg_VN3 { get; set; }
        public float? Fvozg_VN4 { get; set; }
        public float? Ppar_all { get; set; }
        public float? Tpar_all { get; set; }
        public float? Fpar_all_plan { get; set; }
        public float? Psj_tn { get; set; }
        public float? Tsj_tn { get; set; }
        public float? Fsj_tn_plan { get; set; }
        public float? Psj_RDU { get; set; }
        public float? Tsj_RDU { get; set; }
        public float? Fsj_RDU_plan { get; set; }
        public float? Pazot_pech { get; set; }
        public float? Tazot_pech { get; set; }
        public float? Fazot_pech_plan { get; set; }
        public float? P_O2_tn { get; set; }
        public float? T_O2_tn { get; set; }
        public float? F_O2_tn_plan { get; set; }
        public float? Fdg_VN1sr { get; set; }
        public float? Tk_VN1sr_max_nagr { get; set; }
        public float? Td_VN1sr_max_nagr { get; set; }
        public float? Tk_VN1sr_max_dut { get; set; }
        public float? sr_vr_nagr_VN1 { get; set; }
        public float? sr_vr_dut_VN1 { get; set; }
        public float? Fdg_VN2sr { get; set; }
        public float? Tk_VN2sr_max_nagr { get; set; }
        public float? Td_VN2sr_max_nagr { get; set; }
        public float? Tk_VN2sr_max_dut { get; set; }
        public float? sr_vr_nagr_VN2 { get; set; }
        public float? sr_vr_dut_VN2 { get; set; }
        public float? Fdg_VN3sr { get; set; }
        public float? Tk_VN3sr_max_nagr { get; set; }
        public float? Td_VN3sr_max_nagr { get; set; }
        public float? Tk_VN3sr_max_dut { get; set; }
        public float? sr_vr_nagr_VN3 { get; set; }
        public float? sr_vr_dut_VN3 { get; set; }
        public float? Fdg_VN4sr { get; set; }
        public float? Tk_VN4sr_max_nagr { get; set; }
        public float? Td_VN4sr_max_nagr { get; set; }
        public float? Tk_VN4sr_max_dut { get; set; }
        public float? sr_vr_nagr_VN4 { get; set; }
        public float? sr_vr_dut_VN4 { get; set; }
        public float? Pdg_BVN { get; set; }
        public float? Tdg_BVN { get; set; }
        public float? Fdg_BVN_plan { get; set; }
        public float? vr_dg_BVN_m { get; set; }
        public float? vr_dg_BVN_m_98 { get; set; }
        public float? F_v_vd { get; set; }
        public float? F_v_vd_bk { get; set; }
        public float? F_zal_p { get; set; }
        public float? Ftv { get; set; }
        public float? Fvg_VN1sr { get; set; }
        public float? Fvg_VN2sr { get; set; }
        public float? Fvg_VN3sr { get; set; }
        public float? Fvg_VN4sr { get; set; }
        public float? Fhd { get; set; }
        public float? Pgd { get; set; }
        public float? Fkg_vyx { get; set; }
        public float? Fpar_p { get; set; }
        public float? Pbar { get; set; }
        public float? Fazot { get; set; }
        public float? Pkg { get; set; }
        public float? Fnat_gas_teh { get; set; }
        public float? FDG_na_svechu { get; set; }
        public float? D_BF_GAS_AVER { get; set; }
        #endregion

    }
}
