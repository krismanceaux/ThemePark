namespace ThemePark
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThemePark.MaintCode")]
    public partial class MaintCode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MaintCode()
        {
            Maintenances = new HashSet<Maintenance>();
        }

        [Key]
        [Column("MaintCode")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte MaintCode1 { get; set; }

        [StringLength(20)]
        public string MaintType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Maintenance> Maintenances { get; set; }
    }
}
