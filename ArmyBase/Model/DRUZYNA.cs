namespace ArmyBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DRUZYNA")]
    public partial class DRUZYNA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DRUZYNA()
        {
            MISJA = new HashSet<MISJA>();
            PRACOWNIK1 = new HashSet<PRACOWNIK>();
        }

        [Column(TypeName = "numeric")]
        public decimal ID { get; set; }

        [Column("DRUZYNA")]
        [Required]
        [StringLength(30)]
        public string DRUZYNA1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal DOWODCA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TYP { get; set; }

        [StringLength(30)]
        public string OBOWIAZKI { get; set; }

        public virtual PRACOWNIK PRACOWNIK { get; set; }

        public virtual TYPDRUZYNY TYPDRUZYNY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MISJA> MISJA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRACOWNIK> PRACOWNIK1 { get; set; }
    }
}
