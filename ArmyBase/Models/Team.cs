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

        [Required(ErrorMessage = ("Name is required"))]
        public string Name { get; set; }

        [ForeignKey("TeamType")]
        [Required(ErrorMessage = ("Team type is required"))]
        public int? TeamTypeId { get; set; }
        
        public TeamType TeamType { get; set; }

        [ForeignKey("Mission")]
        public int? MissionId { get; set; }

        public Mission Mission { get; set; }

        public string Responsibilities { get; set; }
        
        public ICollection<Employee> Employee { get; set; }

        public bool IsDisabled { get; set; } = false;

    }
}
