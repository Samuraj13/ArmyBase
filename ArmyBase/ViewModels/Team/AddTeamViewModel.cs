using ArmyBase.DTO;
using ArmyBase.Service;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBase.ViewModels.Team
{
    public class AddTeamViewModel : Screen
    {
        public BindableCollection<TeamTypeDTO> TeamTypes { get; set; }

        public EquipmentTypeDTO SelectedTeamType { get; set; }

        public string Name { get; set; }

        public string Responsibilities { get; set; }

        public AddTeamViewModel()
        {
            TeamTypes = TeamTypeService.GetAllBindableCollection();
        }

        public void Add()
        {
            TeamService.Add(Name, SelectedTeamType.Id, Responsibilities);
            TryClose();
        }

        public void Close()
        {
            TryClose();
        }
    }
}
