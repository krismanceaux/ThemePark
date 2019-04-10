namespace ThemePark
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThemePark.SeasonPassHolder")]
    public partial class SeasonPassHolder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SeasonPassHolder()
        {
            DependentPassHolders = new HashSet<DependentPassHolder>();
            SPHLogins = new HashSet<SPHLogin>();
        }

        [Key]
        public long SPH_ID { get; set; }

        [StringLength(30)]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [StringLength(15)]
        [Display(Name = "City")]
        public string CityOfAddress { get; set; }

        [StringLength(15)]
        [Display(Name = "State")]
        public string StateOfAddress { get; set; }

        [StringLength(5)]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [StringLength(15)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(15)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(15)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        public long? TicketNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DependentPassHolder> DependentPassHolders { get; set; }

        public virtual Ticket Ticket { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SPHLogin> SPHLogins { get; set; }
    }
}
