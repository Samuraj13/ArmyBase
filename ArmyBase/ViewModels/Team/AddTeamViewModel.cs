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
        private TeamDTO toEdit { get; set; }

        private bool IsEdit { get; set; }

        public BindableCollection<TeamTypeDTO> TeamTypes { get; set; }

        public TeamTypeDTO SelectedTeamType { get; set; }

        public BindableCollection<EmployeeDTO> AvailableEmployees { get; set; }

        public BindableCollection<EmployeeDTO> ActualEmployees { get; set; }

        public List<EmployeeDTO> SelectedEmployees { get; set; }

        public string Name { get; set; }

        public string Responsibilities { get; set; }

        public int? ActualType { get; set; }

        public string ButtonLabel { get; set; }

        public AddTeamViewModel()
        {
            IsEdit = false;
            ButtonLabel = "Add";
            TeamTypes = TeamTypeService.GetAllBindableCollection();
            AvailableEmployees = new BindableCollection<EmployeeDTO>(EmployeeService.GetAll().Where(x => x.TeamId == null && x.IsSelected == false).ToList());
            ActualEmployees = new BindableCollection<EmployeeDTO>();
        }

        public AddTeamViewModel(TeamDTO team)
        {
            IsEdit = true;
            ButtonLabel = "Edit";
            TeamTypes = TeamTypeService.GetAllBindableCollection();
            AvailableEmployees = new BindableCollection<EmployeeDTO>(EmployeeService.GetAll().Where(x => x.TeamId == null).ToList());
            ActualEmployees = new BindableCollection<EmployeeDTO>(EmployeeService.GetAll().Where(x => x.TeamId == team.Id).ToList());
            int i = 0;
            while (ActualType == null)
            {
                if (TeamTypes[i].Id == team.TeamTypeId)
                {
                    ActualType = i;
                    break;
                }
                else
                {
                    i++;
                }
            }

            this.toEdit = team;
            Name = toEdit.Name;
            Responsibilities = toEdit.Responsibilities;

        }

        public void Add()
        {
            if (!IsEdit)
            {
                SelectedEmployees = ActualEmployees.ToList();
                string x = TeamService.Add(Name, SelectedTeamType?.Id, Responsibilities);
                if (x == null)
                {
                    EmployeeService.AddEmployeesToTeam(SelectedEmployees, TeamService.GetAll().Last().Id);
                    TryClose();
                }
                else
                    Error = x;
            }
            else
            {
                SelectedEmployees = ActualEmployees.ToList();
                toEdit.Name = Name;
                toEdit.Responsibilities = Responsibilities;
                toEdit.TeamTypeId = SelectedTeamType.Id;
                string x = TeamService.Edit(toEdit);
                if (x == null)
                {
                    EmployeeService.AddEmployeesToTeam(SelectedEmployees, toEdit.Id);
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

        public void Click()
        {
            ActualEmployees.AddRange(AvailableEmployees.Where(x => x.IsSelected).ToList());
            AvailableEmployees.RemoveRange(ActualEmployees);
            NotifyOfPropertyChange(() => AvailableEmployees);
            NotifyOfPropertyChange(() => ActualEmployees);

        }

        public void ClickBack()
        {

            AvailableEmployees.AddRange(ActualEmployees.Where(x => x.IsSelected).ToList());
            ActualEmployees.RemoveRange(AvailableEmployees);
            NotifyOfPropertyChange(() => AvailableEmployees);
            NotifyOfPropertyChange(() => ActualEmployees);

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
