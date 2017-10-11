using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTReports.Entities
{
    public class ReportEnergyDay
    {
        public int group { get; set; }
        public int type { get; set; }
        public int id { get; set; }
        public int id_type { get; set; }
        public int trobj { get; set; }
        public string name_energy_ru { get; set; }
        public string name_energy_en { get; set; }
        public int position { get; set; }
        public int? flow { get; set; }
        public int? avg_temp { get; set; }
        public int? avg_pressure { get; set; }
        public int? planimetric { get; set; }
        public int? pr_flow { get; set; }
        public int? time_norm { get; set; }
        public int? time_max { get; set; }
    }
}
