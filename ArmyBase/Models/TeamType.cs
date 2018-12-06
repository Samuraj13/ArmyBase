namespace ArmyBase.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TeamType")]
    public class TeamType
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ("Name is required"))]
        public string Name { get; set; }
        
        public ICollection<Team> Team { get; set; }

        public bool IsDisabled { get; set; } = false;
    }
}
