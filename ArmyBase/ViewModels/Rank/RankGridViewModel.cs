using ArmyBase.DTO;
using ArmyBase.Service;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBase.ViewModels.Rank
{
    public class RankGridViewModel : Screen
    {
        public List<RankDTO> Ranks { get; set; } = new List<RankDTO>();
        public RankGridViewModel()
        {
            Reload();
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
        }

        public void LoadAddRankPage()
        {
            IWindowManager manager = new WindowManager();
            AddRankViewModel add = new AddRankViewModel();
            manager.ShowDialog(add, null, null);
            Reload();
        }

        public void LoadModifyRankPage(BarrackDTO rank)
        {
            IWindowManager manager = new WindowManager();
            ModifyRankViewModel modify = new ModifyRankViewModel(rank);
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
            Ranks = RankService.GetAll();
            NotifyOfPropertyChange(() => Ranks);
        }
    }
}
