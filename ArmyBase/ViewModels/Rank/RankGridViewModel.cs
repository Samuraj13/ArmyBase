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

        public void Delete(RankDTO rank)
        {
            IWindowManager manager = new WindowManager();
            DeleteConfirmationViewModel modify = new DeleteConfirmationViewModel();
            bool? showDialogResult = manager.ShowDialog(modify, null, null);
            if (showDialogResult != null && showDialogResult == true)
            {
                RankService.Delete(rank);
            }
            Reload();
        }

        public void Reload()
        {
            Ranks = RankService.GetAll();
            NotifyOfPropertyChange(() => Ranks);
        }
    }
}
