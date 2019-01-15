namespace ArmyBase.DTO
{
    using ArmyBase.DesignPattern.Observer;
    using ArmyBase.Models;
    using ArmyBase.Service;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    
    public class TeamDTO : IMyObserver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? TeamTypeId { get; set; }
        public TeamType TeamType { get; set; }
        public int? MissionId { get; set; }
        public TeamType Mission { get; set; }
        public string Responsibilities { get; set; }
        public ICollection<Employee> Employee { get; set; }

        public bool IsSelected { get; set; }

        public string TeamTypeName { get; set; }
        public string MissionName { get; set; }


        public void ObserverUpdate()
        {
            TeamService.RemoveFromMission(this);
        }
    }
}
