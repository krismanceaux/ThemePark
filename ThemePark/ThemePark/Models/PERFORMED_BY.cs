namespace ThemePark
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThemePark2.PERFORMED_BY")]
    public partial class PERFORMED_BY
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long MaintenanceID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long EmployeeID { get; set; }

        public int? ManHours { get; set; }

        public virtual Maintenance Maintenance { get; set; }

        public virtual ParkEmployee ParkEmployee { get; set; }
    }
}
