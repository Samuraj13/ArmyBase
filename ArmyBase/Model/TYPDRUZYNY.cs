namespace ArmyBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TYPDRUZYNY")]
    public partial class TYPDRUZYNY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TYPDRUZYNY()
        {
            DRUZYNA = new HashSet<DRUZYNA>();
        }

        [Column(TypeName = "numeric")]
        public decimal ID { get; set; }

        [Required]
        [StringLength(30)]
        public string TYP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DRUZYNA> DRUZYNA { get; set; }
    }
}
