using ArmyBase.DTO;
using ArmyBase.Service;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBase.ViewModels.MissionType
{
    public class MissionTypeGridViewModel : Screen
    {
        public List<MissionTypeDTO> MissionTypes { get; set; } = new List<MissionTypeDTO>();
        public MissionTypeGridViewModel()
        {
            Reload();
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
        }

        public void LoadAddMissionTypePage()
        {
            IWindowManager manager = new WindowManager();
            AddMissionTypeViewModel add = new AddMissionTypeViewModel();
            manager.ShowDialog(add, null, null);
            Reload();
        }

        public void LoadModifyMissionTypePage(MissionTypeDTO missionType)
        {
            IWindowManager manager = new WindowManager();
            AddMissionTypeViewModel modify = new AddMissionTypeViewModel(missionType);
            manager.ShowDialog(modify, null, null);
            Reload();
        }

        public void Delete(MissionTypeDTO missionType)
        {
            IWindowManager manager = new WindowManager();
            DeleteConfirmationViewModel modify = new DeleteConfirmationViewModel();
            bool? showDialogResult = manager.ShowDialog(modify, null, null);
            if (showDialogResult != null && showDialogResult == true)
            {
                MissionTypeService.Delete(missionType);
            }
            Reload();
        }

        public void Reload()
        {
            MissionTypes = MissionTypeService.GetAll();
            NotifyOfPropertyChange(() => MissionTypes);
        }
    }
}
