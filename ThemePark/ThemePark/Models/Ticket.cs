namespace ThemePark
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThemePark.Ticket")]
    public partial class Ticket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ticket()
        {
            ADMITTED_BY = new HashSet<ADMITTED_BY>();
            DependentPassHolders = new HashSet<DependentPassHolder>();
            PERMITS = new HashSet<PERMIT>();
            SeasonPassHolders = new HashSet<SeasonPassHolder>();
        }

        [Key]
        public long TicketNumber { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal? Price { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfPurchase { get; set; }

        public byte? TicketCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ADMITTED_BY> ADMITTED_BY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DependentPassHolder> DependentPassHolders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PERMIT> PERMITS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SeasonPassHolder> SeasonPassHolders { get; set; }

        public virtual TicketCode TicketCode1 { get; set; }
    }
}
