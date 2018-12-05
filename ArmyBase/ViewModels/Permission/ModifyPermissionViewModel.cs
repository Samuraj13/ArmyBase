using ArmyBase.DTO;

namespace ArmyBase.ViewModels.Permission
{
    internal class ModifyPermissionViewModel
    {
        private BarrackDTO barrack;

        public ModifyPermissionViewModel(BarrackDTO barrack)
        {
            this.barrack = barrack;
        }
    }
}