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

        public TeamTypeDTO SelectedTeamType { get; set; }

        public BindableCollection<EmployeeDTO> Employees { get; set; }

        public List<EmployeeDTO> SelectedEmployees { get; set; }
        
        public string Name { get; set; }

        public string Responsibilities { get; set; }

        public AddTeamViewModel()
        {
            TeamTypes = TeamTypeService.GetAllBindableCollection();
            Employees = new BindableCollection<EmployeeDTO>(EmployeeService.GetAll().Where(x => x.TeamId == null).ToList());
        }

        public void Add()
        {
            SelectedEmployees = Employees.Where(x => x.IsSelected).ToList();
            TeamService.Add(Name, SelectedTeamType.Id, Responsibilities);
            EmployeeService.AddEmployeesToTeam(SelectedEmployees, TeamService.GetAll().Last().Id);
            TryClose();
        }

        public void Close()
        {
            TryClose();
        }
    }
}
