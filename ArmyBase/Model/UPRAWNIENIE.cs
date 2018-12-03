namespace ArmyBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UPRAWNIENIE")]
    public partial class UPRAWNIENIE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UPRAWNIENIE()
        {
            SPECJALIZACJA = new HashSet<SPECJALIZACJA>();
        }

        [Column(TypeName = "numeric")]
        public decimal ID { get; set; }

        [Required]
        [StringLength(30)]
        public string OPIS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal MINSTOPIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SPECJALIZACJA> SPECJALIZACJA { get; set; }

        public virtual STOPIEN STOPIEN { get; set; }
    }
}
