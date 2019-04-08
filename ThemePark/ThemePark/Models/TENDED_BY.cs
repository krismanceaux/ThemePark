namespace ThemePark
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThemePark.TENDED_BY")]
    public partial class TENDED_BY
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long RideID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long EmployeeID { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateTended { get; set; }

        public virtual ParkEmployee ParkEmployee { get; set; }

        public virtual Ride Ride { get; set; }
    }
}
