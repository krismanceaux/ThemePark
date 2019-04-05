namespace ThemePark
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using ThemePark.DAL;

    [Table("ThemePark.Maintenance")]
    public partial class Maintenance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Maintenance()
        {
            PERFORMED_BY = new HashSet<PERFORMED_BY>();
        }
        [Display(Name = "Maintenance ID")]
        public long MaintenanceID { get; set; }

        [Display(Name = "Discrepancy")]
        [StringLength(200)]
        public string MaintDescription { get; set; }

        [Display(Name = "Corrective Action")]
        [StringLength(100)]
        public string CorrectiveAction { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Discovered")]
        [Column(TypeName = "date")]
        public DateTime? DateAdded { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Corrected")]
        [Column(TypeName = "date")]
        public DateTime? DateFixed { get; set; }

        [Display(Name ="Type of Maintenance")]
        public int? MaintCode { get; set; }

        //Removed SupervisorID

        [Display(Name ="Ride")]
        public long? RideID { get; set; }

        public virtual MaintCode MaintCode1 { get; set; }

        public virtual Ride Ride { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PERFORMED_BY> PERFORMED_BY { get; set; }
    }
}
