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
    public class AddEquipmentTypeViewModel : Screen
    {
        private bool IsEdit { get; set; }

        private EquipmentTypeDTO toEdit { get; set; }

        private EquipmentTypeDTO equipmentType;

        public AddEquipmentTypeViewModel()
        {
            IsEdit = false;
        }

        public AddEquipmentTypeViewModel(EquipmentTypeDTO equipmentType)
        {
            IsEdit = true;
            this.toEdit = equipmentType;
            Type = equipmentType.Name;
            NotifyOfPropertyChange(() => Type);
        }

        public string Type { get; set; }

        public void Add()
        {
            if (!IsEdit)
            {
                EquipmentTypeService.Add(Type);
                TryClose();
            }
            else
            {
                toEdit.Name = Type;
                EquipmentTypeService.Edit(toEdit);
                TryClose();
            }
        }

        public void Close()
        {
            TryClose();
        }
    }
}
