namespace ArmyBase.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mission")]
    public class Mission
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ("Name is required"))]
        public string Name { get; set; }

        public string Description { get; set; }

        [ForeignKey("MissionType")]
        [Required(ErrorMessage = ("Mission type is required"))]
        public int? MissionTypeId { get; set; }
        
        public MissionType MissionType { get; set; }

        [Required(ErrorMessage = ("Start time is required"))]
        public DateTime StartTime { get; set; }
        
        public DateTime? EndTime { get; set; }
        
        public ICollection<Team> Team { get; set; }

        public bool IsDisabled { get; set; } = false;
    }
}
