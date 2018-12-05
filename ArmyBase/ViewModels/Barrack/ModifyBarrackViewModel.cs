using ArmyBase.DTO;

namespace ArmyBase.ViewModels.Barrack
{
    internal class ModifyBarrackViewModel
    {
        private BarrackDTO barrack;

        public ModifyBarrackViewModel(BarrackDTO barrack)
        {
            this.barrack = barrack;
        }
    }
}