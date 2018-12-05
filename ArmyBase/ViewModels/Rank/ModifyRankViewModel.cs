using ArmyBase.DTO;

namespace ArmyBase.ViewModels.Rank
{
    internal class ModifyRankViewModel
    {
        private BarrackDTO barrack;

        public ModifyRankViewModel(BarrackDTO barrack)
        {
            this.barrack = barrack;
        }
    }
}