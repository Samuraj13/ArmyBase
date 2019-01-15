using ArmyBase.DesignPattern.Observer;
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

        private MissionDTO newMission { get; set; }

        public BindableCollection<MissionTypeDTO> MissionTypes { get; set; }

        public MissionTypeDTO SelectedMissionType { get; set; }

        public BindableCollection<TeamDTO> AvailableTeams { get; set; }

        public BindableCollection<TeamDTO> ActualTeams { get; set; }

        public List<TeamDTO> SelectedTeams { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? ActualType { get; set; }

        public string ButtonLabel { get; set; }

        public AddMissionViewModel()
        {
            IsEdit = false;
            ButtonLabel = "Add";
            MissionTypes = MissionTypeService.GetAllBindableCollection();
            AvailableTeams = new BindableCollection<TeamDTO>(TeamService.GetAll().Where(x => x.MissionId == null).ToList());
            ActualTeams = new BindableCollection<TeamDTO>();
            StartTime = DateTime.Now;
            newMission = new MissionDTO();
            NotifyOfPropertyChange(() => StartTime);
        }

        public AddMissionViewModel(MissionDTO mission)
        {
            IsEdit = true;
            ButtonLabel = "Edit";
            MissionTypes = MissionTypeService.GetAllBindableCollection();
            AvailableTeams = new BindableCollection<TeamDTO>(TeamService.GetAll().Where(x => x.MissionId == null).ToList());
            ActualTeams = new BindableCollection<TeamDTO>(TeamService.GetAll().Where(x => x.MissionId == mission.Id).ToList());

            int i = 0;
            while (ActualType == null)
            {
                if (MissionTypes[i].Id == mission.MissionTypeId)
                {
                    ActualType = i;
                    break;
                }
                else
                {
                    i++;
                }
            }

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
                newMission.Name = Name;
                newMission.Description = Description;
                newMission.StartTime = StartTime;
                newMission.EndTime = EndTime;
                newMission.MissionTypeId = SelectedMissionType?.Id;
                SelectedTeams = ActualTeams.ToList();
                string x = MissionService.Add(newMission);
                if (x == null)
                {
                    MissionService.SetObserversToMission(newMission.Observers, MissionService.GetAll().Last().Id);
                    TryClose();
                }
                else
                    Error = x;

            }
            else
            {
                toEdit.Name = Name;
                toEdit.Description = Description;
                toEdit.StartTime = StartTime;
                toEdit.EndTime = EndTime;
                toEdit.MissionTypeId = SelectedMissionType?.Id;
                SelectedTeams = ActualTeams.ToList();
                string x = MissionService.Edit(toEdit);
                if (x == null)
                {
                    MissionService.SetObserversToMission(toEdit.Observers, toEdit.Id);
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
            if (!IsEdit)
            {
                newMission.AddObserver(AvailableTeams.Where(x => x.IsSelected).ToList<IMyObserver>());
            }
            else
            {
                toEdit.AddObserver(AvailableTeams.Where(x => x.IsSelected).ToList<IMyObserver>());
            }
            ActualTeams.AddRange(AvailableTeams.Where(x => x.IsSelected).ToList());
            AvailableTeams.RemoveRange(ActualTeams);
            NotifyOfPropertyChange(() => AvailableTeams);
            NotifyOfPropertyChange(() => ActualTeams);

        }

        public void ClickBack()
        {
            if (!IsEdit)
            {
                foreach(var item in ActualTeams.Where(x => x.IsSelected).ToList<IMyObserver>())
                {
                    newMission.RemoveObserver(item);
                }
            }
            else
            {
                foreach (var item in ActualTeams.Where(x => x.IsSelected).ToList<IMyObserver>())
                {
                    toEdit.RemoveObserver(item);
                }
            }
            AvailableTeams.AddRange(ActualTeams.Where(x => x.IsSelected).ToList());
            ActualTeams.RemoveRange(AvailableTeams);
            NotifyOfPropertyChange(() => AvailableTeams);
            NotifyOfPropertyChange(() => ActualTeams);

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
