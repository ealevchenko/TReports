namespace EFTReports.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("treports.TypeEnergy")]
    public partial class TypeEnergy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TypeEnergy()
        {
            REnergyDay = new HashSet<REnergyDay>();
        }

        public int id { get; set; }

        public int id_group { get; set; }

        [Required]
        [StringLength(100)]
        public string type_energy_ru { get; set; }

        [Required]
        [StringLength(100)]
        public string type_energy_en { get; set; }

        public virtual GroupEnergy GroupEnergy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REnergyDay> REnergyDay { get; set; }
    }
}
