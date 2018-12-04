namespace ArmyBase.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Barrack")]
    public class Barrack
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage =("Barack's name is required"))]
        public string Name { get; set; }

        [Required]
        public int Capacity { get; set; }
        
        public ICollection<Employee> Employee { get; set; }
    }
}
