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
        private TeamTypeDTO teamType;

        public AddTeamTypeViewModel(TeamTypeDTO teamType)
        {
            this.teamType = teamType;
        }

        public string Type { get; set; }

        public void Add()
        {
            TeamTypeService.Add(Type);
            TryClose();
        }

        public void Close()
        {
            TryClose();
        }
    }
}
