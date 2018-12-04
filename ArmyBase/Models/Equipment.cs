namespace ArmyBase.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Equipment")]
    public class Equipment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsAvailable { get; set; }
        
        [ForeignKey("EquipmentType")]
        public int EquipmentTypeId { get; set; }
        
        public EquipmentType EquipmentType { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        [ForeignKey("Id")]
        public ICollection<Specialization> Specialization { get; set; }

    }
}
