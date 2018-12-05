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
    public class TeamTypeGridViewModel : Screen
    {
        public List<TeamTypeDTO> TeamTypes { get; set; } = new List<TeamTypeDTO>();
        public TeamTypeGridViewModel()
        {
            Reload();
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
        }

        public void LoadAddTeamTypePage()
        {
            IWindowManager manager = new WindowManager();
            AddTeamTypeViewModel add = new AddTeamTypeViewModel();
            manager.ShowDialog(add, null, null);
            Reload();
        }

        public void LoadModifyTeamTypePage(TeamTypeDTO teamType)
        {
            IWindowManager manager = new WindowManager();
            AddTeamTypeViewModel modify = new AddTeamTypeViewModel(teamType);
            manager.ShowDialog(modify, null, null);
            Reload();
        }

        public void Delete(TeamTypeDTO teamType)
        {
            IWindowManager manager = new WindowManager();
            DeleteConfirmationViewModel modify = new DeleteConfirmationViewModel();
            bool? showDialogResult = manager.ShowDialog(modify, null, null);
            if (showDialogResult != null && showDialogResult == true)
            {
                TeamTypeService.Delete(teamType);
            }
            Reload();
        }

        public void Reload()
        {
            TeamTypes = TeamTypeService.GetAll();
            NotifyOfPropertyChange(() => TeamTypes);
        }
    }
}
