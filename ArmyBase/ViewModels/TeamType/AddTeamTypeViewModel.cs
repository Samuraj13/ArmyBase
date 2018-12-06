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

        public AddTeamTypeViewModel()
        {
            IsEdit = false;
        }

        public AddTeamTypeViewModel(TeamTypeDTO teamType)
        {
            IsEdit = true;
            this.toEdit = teamType;
            Type = teamType.Name;
            NotifyOfPropertyChange(() => Type);
        }

        public string Type { get; set; }

        public void Add()
        {
            if (!IsEdit)
            {
                TeamTypeService.Add(Type);
                TryClose();
            }
            else
            {
                toEdit.Name = Type;
                TeamTypeService.Edit(toEdit);
                TryClose();
            }
        }

        public void Close()
        {
            TryClose();
        }
    }
}
