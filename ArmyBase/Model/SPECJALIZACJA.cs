namespace ArmyBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SPECJALIZACJA")]
    public partial class SPECJALIZACJA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SPECJALIZACJA()
        {
            PRACOWNIK = new HashSet<PRACOWNIK>();
        }

        [Column(TypeName = "numeric")]
        public decimal ID { get; set; }

        [Column("SPECJALIZACJA")]
        [Required]
        [StringLength(30)]
        public string SPECJALIZACJA1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? BRON { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UPRAWNIENIE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRACOWNIK> PRACOWNIK { get; set; }

        public virtual SPRZET SPRZET { get; set; }

        public virtual UPRAWNIENIE UPRAWNIENIE1 { get; set; }
    }
}
