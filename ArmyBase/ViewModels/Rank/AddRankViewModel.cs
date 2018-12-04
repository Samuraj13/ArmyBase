using ArmyBase.Service;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBase.ViewModels.Rank
{
    public class AddRankViewModel : Screen
    {
        public string Name { get; set; }
        
        public string Description { get; set; }

        public int? Bonus { get; set; }

        public bool CanLead { get; set; }

        public int MinExperience { get; set; }

        public AddRankViewModel()
        {

        }

        public void Add()
        {
            RankService.Add(Name, Description, Bonus, CanLead, MinExperience);
            TryClose();
        }

        public void Close()
        {
            TryClose();
        }
    }
}
