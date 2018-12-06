using ArmyBase.DTO;
using ArmyBase.Service;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBase.ViewModels.Equipment
{
    public class AddEquipmentViewModel : Screen
    {
        private bool IsEdit { get; set; }

        private EquipmentDTO toEdit { get; set; }

        public BindableCollection<EquipmentTypeDTO> EquipmentTypes { get; set; }

        public EquipmentTypeDTO SelectedEquipmentType { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public bool IsAvailable { get; set; }

        public string Description { get; set; }

        public int? ActualType { get; set; }

        public AddEquipmentViewModel(EquipmentDTO equipment)
        {
            EquipmentTypes = EquipmentTypeService.GetAllBindableCollection();
            IsEdit = true;

            int i = 0;
            while (ActualType == null)
            {
                if(EquipmentTypes[i].Id == equipment.EquipmentTypeId)
                {
                    ActualType = i;
                    break;
                }
                else
                {
                    i++;
                }
            }

            this.toEdit = equipment;
            Name = equipment.Name;
            Quantity = equipment.Quantity;
            IsAvailable = equipment.IsAvailable;
            Description = equipment.Description;
            SelectedEquipmentType = EquipmentTypeService.GetById(equipment.EquipmentTypeId);
            NotifyOfPropertyChange(() => Name);
            NotifyOfPropertyChange(() => Quantity);
            NotifyOfPropertyChange(() => IsAvailable);
            NotifyOfPropertyChange(() => Description);
            NotifyOfPropertyChange(() => EquipmentTypes);
            NotifyOfPropertyChange(() => SelectedEquipmentType);
        }

        public AddEquipmentViewModel()
        {
            IsEdit = false;
            EquipmentTypes = EquipmentTypeService.GetAllBindableCollection();
        }

        public void Add()
        {
            if (!IsEdit)
            {
                EquipmentService.Add(Name, SelectedEquipmentType.Id, Quantity, Description, IsAvailable);
                TryClose();
            }
            else
            {
                toEdit.Name = Name;
                toEdit.Quantity = Quantity;
                toEdit.Description = Description;
                toEdit.IsAvailable = IsAvailable;
                toEdit.EquipmentTypeId = SelectedEquipmentType.Id;
                EquipmentService.Edit(toEdit);
                TryClose();
            }
        }

        public void Close()
        {
            TryClose();
        }
    }
}
