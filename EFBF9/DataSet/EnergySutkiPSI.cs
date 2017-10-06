using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFBF9.DataSet
{
    public class bf9_EnergySutkiPSI
    {
        #region Данные
        public int id_es_put { get; set; }
        public DateTime DT { get; set; }
        public float? PG_PUT_F_AVG { get; set; }
        public float? PG_PUT_F_SUT { get; set; }
        public float? PG_PUT_F_SUT_PRIV { get; set; }
        public float? PG_PUT_F_TIME { get; set; }
        public float? PG_PUT_P_AVG { get; set; }
        public float? PG_PUT_T_AVG { get; set; }
        public float? PG_PUT_F_SUT_DANIELI { get; set; }
        public float? PCI_AVG_N2_P { get; set; }
        public float? PCI_AVG_N2_T { get; set; }
        public float? PCI_AVG_N2_F { get; set; }
        public float? PCI_N2_F_SUTKI { get; set; }
        public float? PCI_N2_TIME { get; set; }
        public float? PCI_N2_F_PRIV { get; set; }
        public float? PCI_N2_F_PRIV_SUT_RAZGAR { get; set; }
        public float? PCI_N2_F_PRIV_SUT_DANIELI { get; set; }
        public float? PCI_N2_PRIV_TIME { get; set; }
        public float? PCI_AVG_WATER_P { get; set; }
        public float? PCI_AVG_WATER_F { get; set; }
        public float? PCI_WATER_F_SUT_RAZGAR { get; set; }
        public float? PCI_WATER_F_SUT_DANIELI { get; set; }
        public float? PCI_WATER_TIME { get; set; }
        public float? PCI_AVG_FY { get; set; }
        public float? PCI_FY_SUTKI { get; set; }
        public float? PCI_FY_TIME { get; set; }
        public float? PCI_TKG_D1 { get; set; }
        public float? PCI_TKG_D2 { get; set; }
        public float? PCI_FPG_AVG_M_ON { get; set; }
        public int? PCI_FPG_TIME_M_ON { get; set; }
        public float? PCI_FPG_AVG_M_OFF { get; set; }
        public int? PCI_FPG_TIME_M_OFF { get; set; }
        public float? PCI_FY_SUTKI_2 { get; set; }
        #endregion
    }
}
