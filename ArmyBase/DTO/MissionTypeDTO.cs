namespace ArmyBase.DTO
{
    using ArmyBase.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    
    public class MissionTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Mission> Mission { get; set; }
    }
}
