namespace ThemePark
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThemePark.Ride")]
    public partial class Ride
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ride()
        {
            Maintenances = new HashSet<Maintenance>();
            PERMITS = new HashSet<PERMIT>();
            TENDED_BY = new HashSet<TENDED_BY>();
        }

        public long RideID { get; set; }

        [StringLength(20)]
        public string RideName { get; set; }

        [StringLength(200)]
        public string RideDiscription { get; set; }

        [StringLength(20)]
        public string RideLocation { get; set; }

        public int? RideCapacity { get; set; }

        [Display(Name = "Ride Status")]
        public int? RideStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Maintenance> Maintenances { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PERMIT> PERMITS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TENDED_BY> TENDED_BY { get; set; }

        public virtual RideStatus RideStatus1 { get; set; }
    }
}
