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
        public BindableCollection<EquipmentTypeDTO> EquipmentTypes { get; set; }

        public EquipmentTypeDTO SelectedEquipmentType { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public bool IsAvailable { get; set; }

        public string Description { get; set; }

        public AddEquipmentViewModel()
        {
            EquipmentTypes = EquipmentTypeService.GetAllBindableCollection();
        }

        public void Add()
        {
            EquipmentService.Add(Name,SelectedEquipmentType.Id,Quantity,Description,IsAvailable);
            TryClose();
        }

        public void Close()
        {
            TryClose();
        }
    }
}
