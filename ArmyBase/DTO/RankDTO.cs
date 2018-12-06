namespace ArmyBase.DTO
{
    using ArmyBase.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    
    public class RankDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinExperience { get; set; }
        public bool CanLead { get; set; }
        public int? Bonus { get; set; }
        public string Description { get; set; }

        public ICollection<Employee> Employee { get; set; }
        
        public ICollection<Permission> Permission { get; set; }

        public string CanLeadLabel { get; set; }
    }
}
