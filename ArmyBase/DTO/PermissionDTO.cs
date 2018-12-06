namespace ArmyBase.DTO
{
    using ArmyBase.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    
    public class PermissionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MinRankId { get; set; }
        public Rank MinRank { get; set; }
        public ICollection<Specialization> Specialization { get; set; }

        public string MinRankName { get; set; }
    }
}
