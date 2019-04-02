namespace ThemePark
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThemePark.PERMITS")]
    public partial class PERMIT
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long RideID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long TicketNumber { get; set; }

        public DateTime? PTimeStamp { get; set; }

        public virtual Ride Ride { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}
