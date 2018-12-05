namespace ArmyBase.DTO
{
    using ArmyBase.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    
    public class TeamDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeamTypeId { get; set; }
        public TeamType TeamType { get; set; }
        public int? MissionId { get; set; }
        public TeamType Mission { get; set; }
        public string Responsibilities { get; set; }
        public ICollection<Employee> Employee { get; set; }

        public bool IsSelected { get; set; }
    }
}
