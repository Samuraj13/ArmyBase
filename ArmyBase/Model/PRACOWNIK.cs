namespace ArmyBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRACOWNIK")]
    public partial class PRACOWNIK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRACOWNIK()
        {
            BARAK1 = new HashSet<BARAK>();
            DRUZYNA1 = new HashSet<DRUZYNA>();
        }

        [Column(TypeName = "numeric")]
        public decimal ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PESEL { get; set; }

        [Required]
        [StringLength(30)]
        public string IMIE { get; set; }

        [Required]
        [StringLength(30)]
        public string NAZWISKO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ZAROBKI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SPECJALIZACJA { get; set; }

        [Column(TypeName = "date")]
        public DateTime DATAZATRUDNIENIA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal STOPIEN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DRUZYNA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? BARAK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BARAK> BARAK1 { get; set; }

        public virtual BARAK BARAK2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DRUZYNA> DRUZYNA1 { get; set; }

        public virtual DRUZYNA DRUZYNA2 { get; set; }

        public virtual SPECJALIZACJA SPECJALIZACJA1 { get; set; }

        public virtual STOPIEN STOPIEN1 { get; set; }
    }
}
