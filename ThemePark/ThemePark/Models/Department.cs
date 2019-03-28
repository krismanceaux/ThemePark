namespace ThemePark
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThemePark2.Department")]
    public partial class Department
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Department()
        {
            MANAGED_BY = new HashSet<MANAGED_BY>();
            ParkEmployees = new HashSet<ParkEmployee>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long DepartmentID { get; set; }

        [StringLength(50)]
        public string DName { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MANAGED_BY> MANAGED_BY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ParkEmployee> ParkEmployees { get; set; }
    }
}
