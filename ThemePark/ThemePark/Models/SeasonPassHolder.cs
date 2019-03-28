namespace ThemePark
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThemePark2.SeasonPassHolder")]
    public partial class SeasonPassHolder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SeasonPassHolder()
        {
            DependentPassHolders = new HashSet<DependentPassHolder>();
            SPHLogins = new HashSet<SPHLogin>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long SPH_ID { get; set; }

        [StringLength(30)]
        public string StreetAddress { get; set; }

        [StringLength(15)]
        public string CityOfAddress { get; set; }

        [StringLength(15)]
        public string StateOfAddress { get; set; }

        [StringLength(5)]
        public string ZipCode { get; set; }

        [StringLength(15)]
        public string FirstName { get; set; }

        [StringLength(15)]
        public string LastName { get; set; }

        [StringLength(15)]
        public string MiddleName { get; set; }

        public long? TicketNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DependentPassHolder> DependentPassHolders { get; set; }

        public virtual Ticket Ticket { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SPHLogin> SPHLogins { get; set; }
    }
}
