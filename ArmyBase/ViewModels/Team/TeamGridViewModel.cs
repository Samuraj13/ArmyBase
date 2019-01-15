using ArmyBase.DTO;
using ArmyBase.Service;
using ArmyBase.ViewModels.TeamType;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ArmyBase.ViewModels.Team
{
    public class TeamGridViewModel : Screen
    {
        public List<TeamDTO> Teams { get; set; } = new List<TeamDTO>();
        public TeamGridViewModel()
        {
            Reload();
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
        }

        public void LoadModifyTeamPage(TeamDTO team)
        {
            IWindowManager manager = new WindowManager();
            AddTeamViewModel add = new AddTeamViewModel(team);
            manager.ShowDialog(add, null, null);
            Reload();
        }

        public void LoadTeamTypesGrid()
        {
            IWindowManager manager = new WindowManager();
            TeamTypeGridViewModel add = new TeamTypeGridViewModel();
            manager.ShowDialog(add, null, null);
            Reload();
        }

        public void Delete(TeamDTO team)
        {
            IWindowManager manager = new WindowManager();
            DeleteConfirmationViewModel modify = new DeleteConfirmationViewModel();
            bool? showDialogResult = manager.ShowDialog(modify, null, null);
            if (showDialogResult != null && showDialogResult == true)
            {
                TeamService.Delete(team);
            }
            Reload();
        }

        public void Reload()
        {
            Teams = TeamService.GetAll();
            NotifyOfPropertyChange(() => Teams);
        }
    }
}
