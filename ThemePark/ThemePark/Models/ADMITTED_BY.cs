namespace ThemePark
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThemePark.ADMITTED_BY")]
    public partial class ADMITTED_BY
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long TicketID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long EmployeeID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AdmissionsDate { get; set; }

        public virtual ParkEmployee ParkEmployee { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}
