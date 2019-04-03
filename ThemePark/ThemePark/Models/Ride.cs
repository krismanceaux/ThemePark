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
            ParkEmployees = new HashSet<ParkEmployee>();
        }

        public long RideID { get; set; }

        [Display(Name ="Ride")]
        [StringLength(20)]
        public string RideName { get; set; }

        [StringLength(200)]
        public string RideDiscription { get; set; }

        [StringLength(20)]
        public string RideLocation { get; set; }

        public int? RideCapacity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Maintenance> Maintenances { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PERMIT> PERMITS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ParkEmployee> ParkEmployees { get; set; }
    }
}
