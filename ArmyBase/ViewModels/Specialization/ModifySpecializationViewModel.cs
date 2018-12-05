using ArmyBase.DTO;

namespace ArmyBase.ViewModels.Specialization
{
    internal class ModifySpecializationViewModel
    {
        private BarrackDTO specialization;

        public ModifySpecializationViewModel(BarrackDTO specialization)
        {
            this.specialization = specialization;
        }
    }
}