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

        public void LoadAddTeamPage()
        {
            IWindowManager manager = new WindowManager();
            AddTeamViewModel add = new AddTeamViewModel();
            manager.ShowDialog(add, null, null);
            Reload();
        }

        //public void LoadModifyTeamPage(BarrackDTO team)
        //{
        //    IWindowManager manager = new WindowManager();
        //    ModifyTeamViewModel modify = new ModifyTeamViewModel(team);
        //    manager.ShowDialog(modify, null, null);
        //    Reload();
        //}//trzeba zrobic ModifyBarrackViewModel

        /*
         * u nas chyb nie bedzie detali zadnych
         * 
         * public void LoadDetailsBarrackPage(BarrackDTO barrack)
        {

            IWindowManager manager = new WindowManager();
            BarrackDetailsViewModel details = new BarrackDetailsViewModel(barrack);
            manager.ShowDialog(details, null, null);
            Reload();
        }*/

        public void Reload()
        {
            Teams = TeamService.GetAll();
            NotifyOfPropertyChange(() => Teams);
        }
    }
}
