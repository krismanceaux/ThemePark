namespace ThemePark
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThemePark.Maintenance")]
    public partial class Maintenance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Maintenance()
        {
            PERFORMED_BY = new HashSet<PERFORMED_BY>();
        }

        [Display(Name ="Maintenance ID")]
        public long MaintenanceID { get; set; }


        [Display(Name = "Description")]
        [StringLength(200)]
        public string MaintDescription { get; set; }

        [Display(Name = "Corrective Action")]
        [StringLength(100)]
        public string CorrectiveAction { get; set; }

        [Display(Name = "Date Added")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public DateTime? DateAdded { get; set; }


        [Display(Name = "Date Fixed")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public DateTime? DateFixed { get; set; }

        public int? MaintCode { get; set; }

        public long? RideID { get; set; }

        public virtual MaintCode MaintCode1 { get; set; }

        public virtual Ride Ride { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PERFORMED_BY> PERFORMED_BY { get; set; }
    }
}
