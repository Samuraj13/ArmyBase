namespace ArmyBase.DTO
{
    using ArmyBase.DesignPattern.Observer;
    using ArmyBase.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class MissionDTO : ISubject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? MissionTypeId { get; set; }
        public MissionType MissionType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public ICollection<Team> Team { get; set; }

        public string MissionTypeName { get; set; }

        public List<IMyObserver> Observers { get; set; }

        public void AddObserver(List<IMyObserver> o)
        {
            Observers.AddRange(o);
        }

        public void RemoveObserver(IMyObserver o)
        {
            var index = Observers.IndexOf(Observers.Where(x => (x as TeamDTO).Id == (o as TeamDTO).Id).FirstOrDefault());
            Observers.RemoveAt(index);
        }
        public void InformObservers()
        {
            foreach (var item in Observers)
            {
                item.ObserverUpdate();
            }
        }
        
        public MissionDTO()
        {
            Observers = new List<IMyObserver>();
        }
    }
}
