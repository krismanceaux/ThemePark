namespace ThemePark
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThemePark2.Concession")]
    public partial class Concession
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Concession()
        {
            SOLD_BY = new HashSet<SOLD_BY>();
        }

        [Key]
        [StringLength(15)]
        public string ItemName { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal? ItemPrice { get; set; }

        [StringLength(50)]
        public string ItemDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SOLD_BY> SOLD_BY { get; set; }
    }
}
