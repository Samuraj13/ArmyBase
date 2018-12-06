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

        public string ButtonLabel { get; set; }

        public AddEquipmentTypeViewModel()
        {
            IsEdit = false;
            ButtonLabel = "Add";
        }

        public AddEquipmentTypeViewModel(EquipmentTypeDTO equipmentType)
        {
            IsEdit = true;
            ButtonLabel = "Edit";
            this.toEdit = equipmentType;
            Type = equipmentType.Name;
            NotifyOfPropertyChange(() => Type);
        }

        public string Type { get; set; }

        public void Add()
        {
            if (!IsEdit)
            {
                string x = EquipmentTypeService.Add(Type);
                if (x == null)
                {
                    TryClose();
                }
                else
                    Error = x;
            }
            else
            {
                toEdit.Name = Type;
                string x = EquipmentTypeService.Edit(toEdit);
                if (x == null)
                {
                    TryClose();
                }
                else
                    Error = x;
            }
        }

        public void Close()
        {
            TryClose();
        }

        private string error;

        public string Error
        {
            get { return error; }
            set
            {
                error = value;
                NotifyOfPropertyChange(() => Error);
            }
        }
    }
}
