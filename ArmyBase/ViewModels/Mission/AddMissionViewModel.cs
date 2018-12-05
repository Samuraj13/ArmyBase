using ArmyBase.DTO;
using ArmyBase.Service;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBase.ViewModels.Mission
{
    public class AddMissionViewModel : Screen
    {
        public BindableCollection<MissionTypeDTO> MissionTypes { get; set; }

        public MissionTypeDTO SelectedMissionType { get; set; }

        public BindableCollection<TeamDTO> Teams { get; set; }

        public List<TeamDTO> SelectedTeams { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndDate { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public AddMissionViewModel()
        {
            MissionTypes = MissionTypeService.GetAllBindableCollection();
            Teams = new BindableCollection<TeamDTO>(TeamService.GetAll().Where(x => x.MissionId == null).ToList());
        }

        public void Add()
        {
            SelectedTeams = Teams.Where(x => x.IsSelected).ToList();
            MissionService.Add(Name, Description, SelectedMissionType.Id, StartTime, EndDate);
            TeamService.AddTeamsToMission(SelectedTeams, MissionService.GetAll().Last().Id);
            TryClose();
        }

        public void Close()
        {
            TryClose();
        }
    }
}
