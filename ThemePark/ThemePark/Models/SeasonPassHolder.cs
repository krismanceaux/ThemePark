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

        [Display(Name = "Street Address")]
        [StringLength(30)]
        public string StreetAddress { get; set; }

        [Display(Name = "City")]
        [StringLength(15)]
        public string CityOfAddress { get; set; }

        [Display(Name = "State")]
        [StringLength(15)]
        public string StateOfAddress { get; set; }

        [Display(Name = "Zip Code")]
        [StringLength(5)]
        public string ZipCode { get; set; }

        [Display(Name = "First Name")]
        [StringLength(15)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(15)]
        public string LastName { get; set; }


        [Display(Name = "Middle Name")]
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
