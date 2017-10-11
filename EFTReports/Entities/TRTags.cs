namespace EFTReports.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("treports.Tags")]
    public partial class TRTags
    {
        public int id { get; set; }

        public int id_dataset { get; set; }

        public int trobj { get; set; }

        [Required]
        [StringLength(50)]
        public string tag { get; set; }

        [StringLength(100)]
        public string description { get; set; }

        public int type_measurement { get; set; }

        public int unit { get; set; }

        public int multiplier { get; set; }

        public virtual TRDataSet TRDataSet { get; set; }

    }
}
