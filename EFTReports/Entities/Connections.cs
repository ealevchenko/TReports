namespace EFTReports.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("treports.Connections")]
    public partial class Connections
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Connections()
        {
            DataSets = new HashSet<DataSets>();
        }

        public int id { get; set; }

        public int trobj { get; set; }

        public int id_provider { get; set; }

        [StringLength(100)]
        public string description { get; set; }

        [Required]
        [StringLength(250)]
        public string connection { get; set; }

        public virtual FactoryProviders FactoryProviders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DataSets> DataSets { get; set; }
    }
}
