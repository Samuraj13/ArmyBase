using ArmyBase.DTO;
using ArmyBase.Service;
using ArmyBase.ViewModels.EquipmentType;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBase.ViewModels.Equipment
{
    public class EquipmentGridViewModel : Screen
    {
        public List<EquipmentDTO> Equipments { get; set; } = new List<EquipmentDTO>();
        public EquipmentGridViewModel()
        {
            Reload();
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
        }

        public void LoadEquipmentTypesGrid()
        {
            IWindowManager manager = new WindowManager();
            EquipmentTypeGridViewModel add = new EquipmentTypeGridViewModel();
            manager.ShowDialog(add, null, null);
            Reload();
        }

        public void LoadModifyEquipmentPage(EquipmentDTO equipment)
        {
            IWindowManager manager = new WindowManager();
            AddEquipmentViewModel modify = new AddEquipmentViewModel(equipment);
            manager.ShowDialog(modify, null, null);
            Reload();
        }

        public void Delete(EquipmentDTO equipment)
        {
            IWindowManager manager = new WindowManager();
            DeleteConfirmationViewModel modify = new DeleteConfirmationViewModel();
            bool? showDialogResult = manager.ShowDialog(modify, null, null);
            if (showDialogResult != null && showDialogResult == true)
            {
                EquipmentService.Delete(equipment);
            }
            Reload();
        }

        public void Reload()
        {
            Equipments = EquipmentService.GetAll();
            NotifyOfPropertyChange(() => Equipments);
        }
    }
}