namespace ArmyBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Specialization")]
    public class Specialization
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }

        [ForeignKey("Specialization")]
        public ICollection<Equipment> Equipment { get; set; }

        [ForeignKey("Specialization")]
        public ICollection<Permission> Permission { get; set; }

        [ForeignKey("Specialization")]
        public ICollection<Employee> Employee { get; set; }
    }
}
