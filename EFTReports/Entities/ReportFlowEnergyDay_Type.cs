namespace EFTReports.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("treports.ReportFlowEnergyDay_Type")]
    public partial class ReportFlowEnergyDay_Type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReportFlowEnergyDay_Type()
        {
            ReportFlowEnergyDay_Item = new HashSet<ReportFlowEnergyDay_Item>();
        }

        public int id { get; set; }

        public int id_type { get; set; }

        public int id_report_group { get; set; }

        public int position { get; set; }

        public virtual ReportFlowEnergyDay_Group ReportFlowEnergyDay_Group { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReportFlowEnergyDay_Item> ReportFlowEnergyDay_Item { get; set; }

        public virtual TypeEnergy TypeEnergy { get; set; }
    }
}
