namespace ArmyBase.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Permission")]
    public class Permission
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ("Name is required"))]
        public string Name { get; set; }

        public string Description { get; set; }

        [ForeignKey("MinRank")]
        [Required(ErrorMessage = ("Minimum rank is required"))]
        public int? MinRankId { get; set; }

        public Rank MinRank { get; set; }
        
        public ICollection<Specialization> Specialization { get; set; }

        public bool IsDisabled { get; set; } = false;

    }
}
