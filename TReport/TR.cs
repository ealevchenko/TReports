using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TReport
{

    public enum trObj : int
    {
        add = 100,
        ac1 = 110, ac1_am1 = 111, ac1_am2 = 112, ac1_am3 = 113, ac1_am4 = 114, ac1_am5 = 115, ac1_am6 = 116,
        ac2 = 120, ac2_am1 = 121, ac2_am2 = 122, ac2_am3 = 123, ac2_am4 = 124, ac2_am5 = 125, ac2_am6 = 126,
        ac3 = 130,
        dc1 = 140, dc1_dp8 = 141, dc1_dp7 = 142, dc1_dp6 = 143,
        dc2 = 150, dc2_dp9 = 151, dc2_dp9_pci = 152,
        sd = 200,
        kc = 260, kc_k1 = 261, kc_k2 = 262, kc_k3 = 263, kc_k4 = 264, kc_k5 = 265, kc_k6 = 266,
        rd = 300,
        srs1 = 310, srs1_lms250_3_em = 311,
        srs2 = 320, srs2_lms250_4_em = 321
    }

    public class TR
    {
        protected trObj trObj;
        public TR(trObj trObj)
        {
            this.trObj = trObj;
        }
    }
}
