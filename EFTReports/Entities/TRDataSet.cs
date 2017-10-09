namespace EFTReports.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("treports.DataSet")]
    public partial class TRDataSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRDataSet()
        {
            TRTags = new HashSet<TRTags>();
        }

        public int id { get; set; }

        public int trobj { get; set; }

        [Column("dataset")]
        [Required]
        [StringLength(50)]
        public string dataset1 { get; set; }

        [StringLength(100)]
        public string description { get; set; }

        public string script { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRTags> TRTags { get; set; }
    }
}
