using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFBF9.DataSet
{
    public class bf9_EnergySutki
    {
        #region Данные
        public DateTime Date { get; set; }
        public double? Rodom_Gaz { get; set; }
        public double? Ronatur_Gaz { get; set; }
        public double? Pb { get; set; }
        public double? Q { get; set; }
        public double? Vixod_poluchistogo { get; set; }
        public double? Dom_Gaz_naBVN { get; set; }
        public double? Pr_Gaz_naPech { get; set; }
        public double? Blow_Cold_m { get; set; }
        public double? Blow_Cold_s { get; set; }
        public double? Rasxod_Pres_air_GU { get; set; }
        public double? Rasxod_Pres_air_LD { get; set; }
        public double? FDG_BVN_24 { get; set; }
        public double? FDG_CLR_24 { get; set; }
        public double? CLRdomgas_T { get; set; }
        public double? CLRdomgas_P { get; set; }
        public double? CLRdomgas_a { get; set; }
        public double? BVNdomgaz_T { get; set; }
        public double? BVNdomgaz_P { get; set; }
        public double? BVNdomgaz_a { get; set; }
        public double? CoolFlow_T { get; set; }
        public double? CoolFlow_P { get; set; }
        public double? CoolFlow_a { get; set; }
        public double? Par1_T { get; set; }
        public double? Par1_P { get; set; }
        public double? Par1_a { get; set; }
        public double? Par2_T { get; set; }
        public double? Par2_P { get; set; }
        public double? Par2_a { get; set; }
        public double? N1_T { get; set; }
        public double? N1_P { get; set; }
        public double? N1_a { get; set; }
        public double? PrGazPech_T { get; set; }
        public double? PrGazPech_P { get; set; }
        public double? PrGazPech_a { get; set; }
        public double? PresAirLD_T { get; set; }
        public double? PresAirLD_P { get; set; }
        public double? PresAirLD_a { get; set; }
        public double? PressAirGL_T { get; set; }
        public double? PressAirGL_P { get; set; }
        public double? PressAirGR_T { get; set; }
        public double? PressAirGR_P { get; set; }
        public double? DP_FPG24 { get; set; }
        public double? DP_FCB24 { get; set; }
        public double? DP_FPRP124 { get; set; }
        public double? DP_FPRP224 { get; set; }
        public double? DP_FN2P124 { get; set; }
        public double? DP_FN2P224 { get; set; }
        public double? DP_FWCP124 { get; set; }
        public double? DP_FWCP224 { get; set; }
        public double? DP_FWCP324 { get; set; }
        public double? SHIHTA_MKSute { get; set; }
        public double? DP_FPGND24 { get; set; }
        public double? DP_FZV24 { get; set; }
        public double? DP_FGTets3sut { get; set; }
        public int? DP_twb { get; set; }
        public double? GL_FVG124 { get; set; }
        public double? GL_FVG224 { get; set; }
        public double? GL_FVWL124 { get; set; }
        public double? GL_FVWL224 { get; set; }
        public double? GL_FVSL124 { get; set; }
        public double? GL_FVSL224 { get; set; }
        public double? GR_FVG124 { get; set; }
        public double? GR_FVG224 { get; set; }
        public double? GR_FVWL124 { get; set; }
        public double? GR_FVWL224 { get; set; }
        public double? GR_FVSL124 { get; set; }
        public double? GR_FVSL224 { get; set; }
        public double? DP_FPRBL24 { get; set; }
        public double? BVN1_SEP_FPV24 { get; set; }
        public double? BVN2_SEP_FPV24 { get; set; }
        public double? BVN3_SEP_FPV24 { get; set; }
        public double? BVN4_SEP_FPV24 { get; set; }
        public double? GL_FCDL { get; set; }
        public double? GR_FCDR { get; set; }
        public double? GL_FCAL { get; set; }
        public double? GRL_FCAR { get; set; }
        public double? DP_PKG24 { get; set; }
        public double? DP_TKG24 { get; set; }
        public double? DP_TPRBL24 { get; set; }
        public double? DP_PPRBL24 { get; set; }
        public double? N2_T { get; set; }
        public double? N2_P { get; set; }
        public double? N2_a { get; set; }
        public double? PG_TimeN { get; set; }
        public double? PG_TimeM { get; set; }
        public double? VKG_TimeN { get; set; }
        public double? VKG_TimeM { get; set; }
        public double? DGBVN_TimeN { get; set; }
        public double? DGBVN_TimeM { get; set; }
        public float? O2_TN { get; set; }
        public float? Gran_Shlak { get; set; }
        public float? O2_TN_P { get; set; }
        public float? O2_TN_T { get; set; }
        public float? O2_TN_a { get; set; }
        public float? DP_PCHPGT3 { get; set; }
        public float? DP_TGD24 { get; set; }
        public float? DP_PGD24 { get; set; }
        public float? GL_TCAPGU { get; set; }
        public float? GR_PCAR { get; set; }
        public float? GL_PCAL { get; set; }
        public float? GUNS_TLetkiAvgSutki { get; set; }
        public float? BVN_TRN1avg { get; set; }
        public float? BVN_TRN2avg { get; set; }
        public float? BVN_TRN3avg { get; set; }
        public float? BVN_TRN4avg { get; set; }
        public float? BVN_TRD1avg { get; set; }
        public float? BVN_TRD2avg { get; set; }
        public float? BVN_TRD3avg { get; set; }
        public float? BVN_TRD4avg { get; set; }
        public float? BVN_TKMaxRN1avg { get; set; }
        public float? BVN_TKMaxRN2avg { get; set; }
        public float? BVN_TKMaxRN3avg { get; set; }
        public float? BVN_TKMaxRN4avg { get; set; }
        public float? BVN_TKMaxRD1avg { get; set; }
        public float? BVN_TKMaxRD2avg { get; set; }
        public float? BVN_TKMaxRD3avg { get; set; }
        public float? BVN_TKMaxRD4avg { get; set; }
        public float? BVN_TDMaxRN1avg { get; set; }
        public float? BVN_TDMaxRN2avg { get; set; }
        public float? BVN_TDMaxRN3avg { get; set; }
        public float? BVN_TDMaxRN4avg { get; set; }
        public float? BVN_FDG1avg { get; set; }
        public float? BVN_FDG2avg { get; set; }
        public float? BVN_FDG3avg { get; set; }
        public float? BVN_FDG4avg { get; set; }
        public float? BVN_FVG1avg { get; set; }
        public float? BVN_FVG2avg { get; set; }
        public float? BVN_FVG3avg { get; set; }
        public float? BVN_FVG4avg { get; set; }
        public float? DP_O2CD124 { get; set; }
        public double? WL_domgaz { get; set; }
        #endregion

    }
}
