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
        private EquipmentTypeDTO equipmentType;

        public AddEquipmentTypeViewModel()
        {
        }

        public AddEquipmentTypeViewModel(EquipmentTypeDTO equipmentType)
        {
            this.equipmentType = equipmentType;
        }

        public string Type { get; set; }

        public void Add()
        {
            EquipmentTypeService.Add(Type);
            TryClose();
        }

        public void Close()
        {
            TryClose();
        }
    }
}
