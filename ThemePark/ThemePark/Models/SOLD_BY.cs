namespace ThemePark
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThemePark.SOLD_BY")]
    public partial class SOLD_BY
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(15)]
        public string ItemName { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long EmployeeID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateSold { get; set; }

        public virtual Concession Concession { get; set; }

        public virtual ParkEmployee ParkEmployee { get; set; }
    }
}
