namespace EFTReports.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("treports.DataSetParameters")]
    public partial class DataSetParameters
    {
        public int id { get; set; }

        public int id_dataset { get; set; }

        [StringLength(100)]
        public string description { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public int type { get; set; }

        [Required]
        [StringLength(250)]
        public string type_where { get; set; }

        public virtual DataSets DataSets { get; set; }
    }
}
