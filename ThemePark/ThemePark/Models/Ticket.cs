namespace ThemePark
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThemePark2.Ticket")]
    public partial class Ticket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ticket()
        {
            ADMIMTTED_BY = new HashSet<ADMIMTTED_BY>();
            PERMITS = new HashSet<PERMIT>();
            SeasonPassHolders = new HashSet<SeasonPassHolder>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long TicketNumber { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal? Price { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfPurchase { get; set; }

        public byte? TicketCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ADMIMTTED_BY> ADMIMTTED_BY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PERMIT> PERMITS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SeasonPassHolder> SeasonPassHolders { get; set; }

        public virtual TicketCode TicketCode1 { get; set; }
    }
}
