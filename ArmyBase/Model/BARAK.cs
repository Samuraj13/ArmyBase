namespace ArmyBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BARAK")]
    public partial class BARAK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BARAK()
        {
            PRACOWNIK1 = new HashSet<PRACOWNIK>();
        }

        [Column(TypeName = "numeric")]
        public decimal ID { get; set; }

        [Required]
        [StringLength(30)]
        public string NAZWA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal POJEMNOSC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ZARZADCA { get; set; }

        public virtual PRACOWNIK PRACOWNIK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRACOWNIK> PRACOWNIK1 { get; set; }
    }
}
