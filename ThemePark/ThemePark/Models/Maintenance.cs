namespace ThemePark
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThemePark2.Maintenance")]
    public partial class Maintenance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Maintenance()
        {
            PERFORMED_BY = new HashSet<PERFORMED_BY>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long MaintenanceID { get; set; }

        [StringLength(200)]
        public string MaintDescription { get; set; }

        [StringLength(100)]
        public string CorrectiveAction { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateAdded { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateFixed { get; set; }

        public byte? MaintCode { get; set; }

        public long? SupervisorID { get; set; }

        public long? RideID { get; set; }

        public virtual MaintCode MaintCode1 { get; set; }

        public virtual Ride Ride { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PERFORMED_BY> PERFORMED_BY { get; set; }
    }
}
