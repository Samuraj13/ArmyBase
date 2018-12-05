using ArmyBase.DTO;
using ArmyBase.Service;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBase.ViewModels.Specialization
{
    public class SpecializationGridViewModel : Screen
    {
        public List<SpecializationDTO> Specializations { get; set; } = new List<SpecializationDTO>();
        public SpecializationGridViewModel()
        {
            Reload();
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
        }

        public void LoadAddSpecializationPage()
        {
            IWindowManager manager = new WindowManager();
            AddSpecializationViewModel add = new AddSpecializationViewModel();
            manager.ShowDialog(add, null, null);
            Reload();
        }

        public void Delete(SpecializationDTO specialization)
        {
            IWindowManager manager = new WindowManager();
            DeleteConfirmationViewModel modify = new DeleteConfirmationViewModel();
            bool? showDialogResult = manager.ShowDialog(modify, null, null);
            if (showDialogResult != null && showDialogResult == true)
            {
                SpecializationService.Delete(specialization);
            }
            Reload();
        }

        public void Reload()
        {
            Specializations = SpecializationService.GetAll();
            NotifyOfPropertyChange(() => Specializations);
        }
    }
}
