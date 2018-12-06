using ArmyBase.DTO;
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
        private RankDTO toEdit { get; set; }

        private bool IsEdit { get; set; }
        public string Name { get; set; }
        
        public string Description { get; set; }

        public int? Bonus { get; set; }

        public bool CanLead { get; set; }

        public int MinExperience { get; set; }

        public string ButtonLabel { get; set; }

        public AddRankViewModel()
        {
            IsEdit = false;
            ButtonLabel = "Add";
        }

        public AddRankViewModel(RankDTO rank)
        {
            IsEdit = true;
            ButtonLabel = "Edit";

            this.toEdit = rank;
            Name = toEdit.Name;
            Description = toEdit.Description;
            Bonus = toEdit.Bonus;
            CanLead = toEdit.CanLead;
            MinExperience = toEdit.MinExperience;
        }

        public void Add()
        {
            if (!IsEdit)
            {
                string x = RankService.Add(Name, Description, Bonus, CanLead, MinExperience);
                if (x == null)
                {
                    TryClose();
                }
                else
                    Error = x;
            }
            else
            {
                toEdit.Name = Name;
                toEdit.Description = Description;
                toEdit.Bonus = Bonus;
                toEdit.CanLead = CanLead;
                toEdit.MinExperience = MinExperience;

                string x = RankService.Edit(toEdit);
                if (x == null)
                {
                    TryClose();
                }
                else
                    Error = x;
            }
        }

        public void Close()
        {
            TryClose();
        }

        private string error;

        public string Error
        {
            get { return error; }
            set
            {
                error = value;
                NotifyOfPropertyChange(() => Error);
            }
        }
    }
}
