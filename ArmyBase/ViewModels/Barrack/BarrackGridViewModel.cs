using ArmyBase.DTO;
using ArmyBase.Service;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBase.ViewModels.Barrack
{
    public class BarrackGridViewModel : Screen
    {
        public List<BarrackDTO> Barracks { get; set; } = new List<BarrackDTO>();
        public BarrackGridViewModel()
        {
            Reload();
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
        }

        public void LoadAddBarrackPage()
        {
            IWindowManager manager = new WindowManager();
            AddBarrackViewModel add = new AddBarrackViewModel();
            manager.ShowDialog(add, null, null);
            Reload();
        }

        public void LoadModifyBarrackPage(BarrackDTO barrack)
        {
            IWindowManager manager = new WindowManager();
            AddBarrackViewModel modify = new AddBarrackViewModel(barrack);
            manager.ShowDialog(modify, null, null);
            Reload();
        }

        public void Delete(BarrackDTO barrack)
        {
            IWindowManager manager = new WindowManager();
            DeleteConfirmationViewModel modify = new DeleteConfirmationViewModel();
            bool? showDialogResult = manager.ShowDialog(modify, null, null);
            if (showDialogResult != null && showDialogResult == true)
            {
                BarrackService.Delete(barrack);
            }
            Reload();
        }

        public void Reload()
        {
            Barracks = BarrackService.GetAll();
            NotifyOfPropertyChange(() => Barracks);
        }
    }
}