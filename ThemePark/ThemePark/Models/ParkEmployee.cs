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

        [Display(Name = "First Name")]
        [StringLength(15)]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [StringLength(15)]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(15)]
        public string LastName { get; set; }

        [Display(Name = "Street Address")]
        [StringLength(50)]
        public string StreetAddress { get; set; }

        [StringLength(20)]
        public string State { get; set; }

        [StringLength(20)]
        public string City { get; set; }

        [Display(Name = "Zip Code")]
        [StringLength(5)]
        public string ZipCode { get; set; }

        [Display(Name = "Phone Number")]
        [StringLength(12)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Date of Birth")]
        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(1)]
        public string Sex { get; set; }

        [Display(Name = "Job Title")]
        [StringLength(20)]
        public string JobTitle { get; set; }

        [Display(Name = "Department")]
        public long? DepartmentID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ADMITTED_BY> ADMITTED_BY { get; set; }

        [Display(Name = "Department")]
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
