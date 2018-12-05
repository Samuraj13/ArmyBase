using ArmyBase.DTO;

namespace ArmyBase.ViewModels.Team
{
    internal class ModifyTeamViewModel
    {
        private BarrackDTO team;

        public ModifyTeamViewModel(BarrackDTO team)
        {
            this.team = team;
        }
    }
}