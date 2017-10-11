namespace EFTReports.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("treports.GroupEnergy")]
    public partial class GroupEnergy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GroupEnergy()
        {
            ReportFlowEnergyDay_Group = new HashSet<ReportFlowEnergyDay_Group>();
            TypeEnergy = new HashSet<TypeEnergy>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string group_energy_ru { get; set; }

        [Required]
        [StringLength(50)]
        public string group_energy_en { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReportFlowEnergyDay_Group> ReportFlowEnergyDay_Group { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TypeEnergy> TypeEnergy { get; set; }
    }
}
