namespace ThemePark
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThemePark2.EmployeeLogin")]
    public partial class EmployeeLogin
    {
        [Key]
        [StringLength(40)]
        public string LoginEmail { get; set; }

        [StringLength(20)]
        public string Pswd { get; set; }

        public long? EmployeeID { get; set; }

        public virtual ParkEmployee ParkEmployee { get; set; }
    }
}
