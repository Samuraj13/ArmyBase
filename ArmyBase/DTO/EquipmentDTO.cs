namespace ArmyBase.DTO
{
    using ArmyBase.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    
    public class EquipmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public int EquipmentTypeId { get; set; }
        public EquipmentType EquipmentType { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public ICollection<Specialization> Specialization { get; set; }

        public string EquipmentTypeName { get; set; }
        public string IsAvailableLabel { get; set; }
    }
}
