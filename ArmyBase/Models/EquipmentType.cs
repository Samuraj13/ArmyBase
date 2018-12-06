namespace ArmyBase.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EquipmentType")]
    public class EquipmentType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public ICollection<Equipment> Equipment { get; set; }

        public bool IsDisabled { get; set; } = false;
    }
}
