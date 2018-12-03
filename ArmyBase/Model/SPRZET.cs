namespace ArmyBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SPRZET")]
    public partial class SPRZET
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SPRZET()
        {
            SPECJALIZACJA = new HashSet<SPECJALIZACJA>();
        }

        [Column(TypeName = "numeric")]
        public decimal ID { get; set; }

        [Required]
        [StringLength(30)]
        public string NAZWA { get; set; }

        public bool CZYDOSTEPNA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TYPBRONI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ILOSC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SPECJALIZACJA> SPECJALIZACJA { get; set; }

        public virtual TYPBRONI TYPBRONI1 { get; set; }
    }
}
