namespace EFTReports.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("treports.ReportForms")]
    public partial class ReportForms
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string report { get; set; }

        [StringLength(100)]
        public string description { get; set; }

        [Column(TypeName = "xml")]
        public string xml_form { get; set; }
    }
}
