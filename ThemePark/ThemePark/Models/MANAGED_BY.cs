namespace ThemePark
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThemePark.MANAGED_BY")]
    public partial class MANAGED_BY
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long EmployeeID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long DepartmentID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        public virtual Department Department { get; set; }

        public virtual ParkEmployee ParkEmployee { get; set; }
    }
}
