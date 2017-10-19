namespace EFTReports.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("treports.Access")]
    public partial class Access
    {
        public int id { get; set; }

        [StringLength(100)]
        public string description { get; set; }

        [Required]
        [StringLength(100)]
        public string action { get; set; }

        [Required]
        [StringLength(100)]
        public string controller { get; set; }

        public string users { get; set; }

        public string roles { get; set; }
    }
}
