namespace ArmyBase.DTO
{
    using ArmyBase.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    
    public class TeamTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Team> Team { get; set; }
    }
}
