using ArmyBase.DTO;
using ArmyBase.Service;
using ArmyBase.ViewModels.MissionType;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBase.ViewModels.Mission
{
    public class MissionGridViewModel : Screen
    {
        public List<MissionDTO> Missions { get; set; } = new List<MissionDTO>();
        public MissionGridViewModel()
        {
            Reload();
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
        }

        public void LoadMissionTypesGrid()
        {
            IWindowManager manager = new WindowManager();
            MissionTypeGridViewModel add = new MissionTypeGridViewModel();
            manager.ShowDialog(add, null, null);
            Reload();
        }

        public void LoadAddMissionPage()
        {
            IWindowManager manager = new WindowManager();
            AddMissionViewModel add = new AddMissionViewModel();
            manager.ShowDialog(add, null, null);
            Reload();
        }

        public void LoadModifyMissionPage(MissionDTO mission)
        {
            IWindowManager manager = new WindowManager();
            AddMissionViewModel modify = new AddMissionViewModel(mission);
            manager.ShowDialog(modify, null, null);
            Reload();
        }

        public void Delete(MissionDTO mission)
        {
            IWindowManager manager = new WindowManager();
            DeleteConfirmationViewModel modify = new DeleteConfirmationViewModel();
            bool? showDialogResult = manager.ShowDialog(modify, null, null);
            if (showDialogResult != null && showDialogResult == true)
            {
                MissionService.Delete(mission);
            }
            Reload();
        }

        public void Reload()
        {
            Missions = MissionService.GetAll();
            NotifyOfPropertyChange(() => Missions);
        }
    }
}
