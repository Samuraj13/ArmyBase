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

        public void LoadAddPermissionPage()
        {
            IWindowManager manager = new WindowManager();
            AddPermissionViewModel add = new AddPermissionViewModel();
            manager.ShowDialog(add, null, null);
            Reload();
        }

        public void Delete(PermissionDTO permission)
        {
            IWindowManager manager = new WindowManager();
            DeleteConfirmationViewModel modify = new DeleteConfirmationViewModel();
            bool? showDialogResult = manager.ShowDialog(modify, null, null);
            if (showDialogResult != null && showDialogResult == true)
            {
                PermissionService.Delete(permission);
            }
            Reload();
        }

        public void Reload()
        {
            Permissions = PermissionService.GetAll();
            NotifyOfPropertyChange(() => Permissions);
        }
    }
}
