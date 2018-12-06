namespace ArmyBase.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rank")]
    public class Rank
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public int MinExperience { get; set; }

        public bool CanLead { get; set; }
        
        public int? Bonus { get; set; }

        public string Description { get; set; }

        public ICollection<Employee> Employee { get; set; }
        
        public ICollection<Permission> Permission { get; set; }

        public bool IsDisabled { get; set; } = false;
    }
}
