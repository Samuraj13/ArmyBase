using ArmyBase.DTO;
using ArmyBase.Service;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBase.ViewModels.TeamType
{
    public class AddTeamTypeViewModel : Screen
    {
        private bool IsEdit { get; set; }

        private TeamTypeDTO toEdit { get; set; }

        private TeamTypeDTO teamType;

        public string ButtonLabel { get; set; }

        public AddTeamTypeViewModel()
        {
            IsEdit = false;
            ButtonLabel = "Add";
        }

        public AddTeamTypeViewModel(TeamTypeDTO teamType)
        {
            IsEdit = true;
            ButtonLabel = "Edit";
            this.toEdit = teamType;
            Type = teamType.Name;
            NotifyOfPropertyChange(() => Type);
        }

        public string Type { get; set; }

        public void Add()
        {
            if (!IsEdit)
            {
                string x = TeamTypeService.Add(Type);
                if (x == null)
                {
                    TryClose();
                }
                else
                    Error = x;
            }
            else
            {
                toEdit.Name = Type;
                string x =TeamTypeService.Edit(toEdit);
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
