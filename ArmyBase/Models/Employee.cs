namespace ArmyBase.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int NationalId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public bool IsBarrackManager { get; set; }

        public bool IsTeamLeader { get; set; }

        public double Salary { get; set; }

        [ForeignKey("Specialization")]
        public int? SpecializationId { get; set; }

        public Specialization Specialization { get; set; }

        [Required]
        public DateTime DateOfEmployment { get; set; }

        [ForeignKey("Rank")]
        public int? RankId { get; set; }

        public Rank Rank { get; set; }

        [ForeignKey("Team")]
        public int? TeamId { get; set; }

        public Team Team { get; set; }

        [ForeignKey("Barrack")]
        public int? BarrackId { get; set; }

        public Barrack Barrack { get; set; }
    }
}
