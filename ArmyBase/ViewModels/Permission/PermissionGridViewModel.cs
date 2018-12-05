using ArmyBase.DTO;
using ArmyBase.Service;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ArmyBase.ViewModels.Permission
{
    public class PermissionGridViewModel : Screen
    {
        public List<PermissionDTO> Permissions { get; set; } = new List<PermissionDTO>();
        public PermissionGridViewModel()
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
            AddPermissionViewModel add = new AddPermissionViewModel();
            manager.ShowDialog(add, null, null);
            Reload();
        }

        public void LoadModifyBarrackPage(BarrackDTO permission)
        {
            IWindowManager manager = new WindowManager();
            ModifyPermissionViewModel modify = new ModifyPermissionViewModel(permission);
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
            Permissions = PermissionService.GetAll();
            NotifyOfPropertyChange(() => Permissions);
        }
    }
}
