namespace ArmyBase.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Team")]
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("TeamType")]
        [Required]
        public int TeamTypeId { get; set; }
        
        public TeamType TeamType { get; set; }

        public string Responsibilities { get; set; }
        
        public ICollection<Employee> Employee { get; set; }

    }
}
