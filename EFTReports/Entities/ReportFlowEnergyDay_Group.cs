namespace EFTReports.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("treports.ReportFlowEnergyDay_Group")]
    public partial class ReportFlowEnergyDay_Group
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReportFlowEnergyDay_Group()
        {
            ReportFlowEnergyDay_Type = new HashSet<ReportFlowEnergyDay_Type>();
        }

        public int id { get; set; }

        public int id_group { get; set; }

        public int position { get; set; }

        public virtual GroupEnergy GroupEnergy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReportFlowEnergyDay_Type> ReportFlowEnergyDay_Type { get; set; }
    }
}
