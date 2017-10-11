namespace EFTReports.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("treports.ReportFlowEnergyDay_Item")]
    public partial class ReportFlowEnergyDay_Item
    {
        public int id { get; set; }

        public int id_report_type { get; set; }

        public int trobj { get; set; }

        [Required]
        [StringLength(100)]
        public string name_energy_ru { get; set; }

        [Required]
        [StringLength(100)]
        public string name_energy_en { get; set; }

        public int position { get; set; }

        public int? flow { get; set; }

        public int? avg_temp { get; set; }

        public int? avg_pressure { get; set; }

        public int? planimetric { get; set; }

        public int? pr_flow { get; set; }

        public int? time_norm { get; set; }

        public int? time_max { get; set; }

        public virtual ReportFlowEnergyDay_Type ReportFlowEnergyDay_Type { get; set; }
    }
}
