using ArmyBase.DTO;

namespace ArmyBase.ViewModels.Equipment
{
    internal class ModifyEquipmentViewModel
    {
        private EquipmentDTO equipment;

        public ModifyEquipmentViewModel(EquipmentDTO equipment)
        {
            this.equipment = equipment;
        }
    }
}