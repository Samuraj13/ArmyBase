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

        public void LoadAddMissionPage()
        {
            IWindowManager manager = new WindowManager();
            AddMissionViewModel add = new AddMissionViewModel();
            manager.ShowDialog(add, null, null);
            Reload();
        }

        public void LoadModifyMissionPage(BarrackDTO mission)
        {
            IWindowManager manager = new WindowManager();
            ModifyMissionViewModel modify = new ModifyMissionViewModel(mission);
            manager.ShowDialog(modify, null, null);
            Reload();
        }//trzeba zrobic ModifyBarrackViewModel

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
            Missions = MissionService.GetAll();
            NotifyOfPropertyChange(() => Missions);
        }
    }
}
