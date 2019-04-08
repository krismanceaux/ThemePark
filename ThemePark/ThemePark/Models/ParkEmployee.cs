namespace ThemePark
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThemePark.ParkEmployee")]
    public partial class ParkEmployee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ParkEmployee()
        {
            ADMITTED_BY = new HashSet<ADMITTED_BY>();
            EmployeeLogins = new HashSet<EmployeeLogin>();
            MANAGED_BY = new HashSet<MANAGED_BY>();
            PERFORMED_BY = new HashSet<PERFORMED_BY>();
            SOLD_BY = new HashSet<SOLD_BY>();
            TENDED_BY = new HashSet<TENDED_BY>();
        }

        [Key]
        public long EmployeeID { get; set; }

        [StringLength(15)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(15)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [StringLength(15)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(50)]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [StringLength(20)]
        public string State { get; set; }

        [StringLength(20)]
        public string City { get; set; }

        [StringLength(5)]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [StringLength(12)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(1)]
        public string Sex { get; set; }

        [StringLength(20)]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        public long? DepartmentID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ADMITTED_BY> ADMITTED_BY { get; set; }

        public virtual Department Department { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeLogin> EmployeeLogins { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MANAGED_BY> MANAGED_BY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PERFORMED_BY> PERFORMED_BY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SOLD_BY> SOLD_BY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TENDED_BY> TENDED_BY { get; set; }
    }
}
