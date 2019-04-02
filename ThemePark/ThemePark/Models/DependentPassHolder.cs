namespace ThemePark
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThemePark.DependentPassHolder")]
    public partial class DependentPassHolder
    {
        [Key]
        public long DepID { get; set; }

        [StringLength(15)]
        public string FirstName { get; set; }

        [StringLength(15)]
        public string LastName { get; set; }

        [StringLength(15)]
        public string MiddleName { get; set; }

        public long? TicketNumber { get; set; }

        public long? SPH_ID { get; set; }

        public virtual SeasonPassHolder SeasonPassHolder { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}
