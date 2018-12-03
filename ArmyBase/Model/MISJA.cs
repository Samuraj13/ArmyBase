namespace ArmyBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MISJA")]
    public partial class MISJA
    {
        [Column(TypeName = "numeric")]
        public decimal ID { get; set; }

        [Required]
        [StringLength(30)]
        public string NAZWA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TYPMISJI { get; set; }

        [Column(TypeName = "date")]
        public DateTime DATAROZPOCZECIA { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DATAZAKONCZENIA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DRUZYNA { get; set; }

        public virtual DRUZYNA DRUZYNA1 { get; set; }

        public virtual TYPMISJI TYPMISJI1 { get; set; }
    }
}
