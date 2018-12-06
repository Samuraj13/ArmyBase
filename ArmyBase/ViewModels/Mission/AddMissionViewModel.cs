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
        private bool IsEdit { get; set; }

        private MissionDTO toEdit { get; set; }

        public BindableCollection<MissionTypeDTO> MissionTypes { get; set; }

        public MissionTypeDTO SelectedMissionType { get; set; }

        public BindableCollection<TeamDTO> Teams { get; set; }

        public List<TeamDTO> SelectedTeams { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public AddMissionViewModel()
        {
            IsEdit = false;
        }

        public AddMissionViewModel(MissionDTO mission)
        {
            IsEdit = true;
            this.toEdit = mission;
            Name = mission.Name;
            Description = mission.Description;
            StartTime = mission.StartTime;
            EndTime = mission.EndTime;
            NotifyOfPropertyChange(() => Name);
            NotifyOfPropertyChange(() => Description);
            NotifyOfPropertyChange(() => StartTime);
            NotifyOfPropertyChange(() => EndTime);
        }

        public void Add()
        {
            if (!IsEdit)
            {
                SelectedTeams = Teams.Where(x => x.IsSelected).ToList();
                MissionService.Add(Name, Description, SelectedMissionType.Id, StartTime, EndTime); TryClose();
                TeamService.AddTeamsToMission(SelectedTeams, MissionService.GetAll().Last().Id);

            }
            else
            {
                toEdit.Name = Name;
                toEdit.Description = Description;
                toEdit.StartTime = StartTime;
                toEdit.EndTime = EndTime;
                MissionService.Edit(toEdit);
                TryClose();
            }
           
            TryClose();
        }

        public void Close()
        {
            TryClose();
        }
    }
}
