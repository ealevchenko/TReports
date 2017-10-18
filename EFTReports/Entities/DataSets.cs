namespace EFTReports.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("treports.DataSets")]
    public partial class DataSets
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DataSets()
        {
            DataSetParameters = new HashSet<DataSetParameters>();
        }

        public int id { get; set; }

        public int trobj { get; set; }

        public int id_connection { get; set; }

        public int type { get; set; }

        [StringLength(100)]
        public string description { get; set; }

        [StringLength(50)]
        public string linked { get; set; }

        [Required]
        [StringLength(250)]
        public string dataset { get; set; }

        public virtual Connections Connections { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DataSetParameters> DataSetParameters { get; set; }
    }
}
