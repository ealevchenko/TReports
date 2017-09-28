using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFBF9.DataSet
{
    public class UnloadMaterialSmena
    {
        public string Type { get; set; }
        public string Material { get; set; }
        public double? Shift1 { get; set; }
        public double? Shift2 { get; set; }
        public double? Shift3 { get; set; }
        public double? day { get; set; }
        public double? Month { get; set; }
        public DateTime? DateShift1 { get; set; }
        public DateTime? DateShift2 { get; set; }
        public DateTime? DateShift3 { get; set; }
        public DateTime? DateDay { get; set; }
        public DateTime? DateMonth { get; set; }
    }
}
