using ArmyBase.DTO;
using ArmyBase.Service;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBase.ViewModels.EquipmentType
{
    public class EquipmentTypeGridViewModel : Screen
    {
        public List<EquipmentTypeDTO> EquipmentTypes { get; set; } = new List<EquipmentTypeDTO>();
        public EquipmentTypeGridViewModel()
        {
            Reload();
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
        }

        public void LoadAddEquipmentTypePage()
        {
            IWindowManager manager = new WindowManager();
            AddEquipmentTypeViewModel add = new AddEquipmentTypeViewModel();
            manager.ShowDialog(add, null, null);
            Reload();
        }

        public void LoadModifyEquipmentTypePage(EquipmentTypeDTO equipmentType)
        {
            IWindowManager manager = new WindowManager();
            AddEquipmentTypeViewModel modify = new AddEquipmentTypeViewModel(equipmentType);
            manager.ShowDialog(modify, null, null);
            Reload();
        }

        public void Delete(EquipmentTypeDTO equipmentType)
        {
            IWindowManager manager = new WindowManager();
            DeleteConfirmationViewModel modify = new DeleteConfirmationViewModel();
            bool? showDialogResult = manager.ShowDialog(modify, null, null);
            if (showDialogResult != null && showDialogResult == true)
            {
                EquipmentTypeService.Delete(equipmentType);
            }
            Reload();
        }

        public void Reload()
        {
            EquipmentTypes = EquipmentTypeService.GetAll();
            NotifyOfPropertyChange(() => EquipmentTypes);
        }
    }
}
