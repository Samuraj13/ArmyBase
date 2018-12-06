namespace ArmyBase.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MissionType")]
    public class MissionType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public ICollection<Mission> Mission { get; set; }

        public bool IsDisabled { get; set; } = false;
    }
}
