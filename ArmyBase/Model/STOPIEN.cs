namespace ArmyBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("STOPIEN")]
    public partial class STOPIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STOPIEN()
        {
            PRACOWNIK = new HashSet<PRACOWNIK>();
            UPRAWNIENIE = new HashSet<UPRAWNIENIE>();
        }

        [Column(TypeName = "numeric")]
        public decimal ID { get; set; }

        [Column("STOPIEN")]
        [Required]
        [StringLength(30)]
        public string STOPIEN1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal MINSTAZ { get; set; }

        public bool CZYMOZEDOWODZIC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DODATEK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRACOWNIK> PRACOWNIK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UPRAWNIENIE> UPRAWNIENIE { get; set; }
    }
}
