namespace EFTReports.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("treports.FactoryProviders")]
    public partial class FactoryProviders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FactoryProviders()
        {
            Connections = new HashSet<Connections>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string provider { get; set; }

        [StringLength(100)]
        public string descriptipn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Connections> Connections { get; set; }
    }
}
