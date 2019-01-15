using ArmyBase.DesignPattern.Singleton;
using ArmyBase.ViewModels;

namespace ArmyBase.DesignPattern.Command
{
    public class BarrackCommand : IMyCommand
    {
        private CreateButton button;  //obiekt wykonujacy
        public BarrackCommand(CreateButton button)
        {
            this.button = button;
        }

        public void Execute()
        {
            button.LoadAddBarrackPage();
        }
    }

    public class TeamCommand : IMyCommand
    {
        private CreateButton button;  //obiekt wykonujacy
        public TeamCommand(CreateButton button)
        {
            this.button = button;
        }

        public void Execute()
        {
            button.LoadAddTeamPage();
        }
    }

    public class SpecializationCommand : IMyCommand
    {
        private CreateButton button;  //obiekt wykonujacy
        public SpecializationCommand(CreateButton button)
        {
            this.button = button;
        }

        public void Execute()
        {
            button.LoadAddSpecializationPage();
        }
    }

    public class RankCommand : IMyCommand
    {
        private CreateButton button;  //obiekt wykonujacy
        public RankCommand(CreateButton button)
        {
            this.button = button;
        }

        public void Execute()
        {
            button.LoadAddRankPage();
        }
    }

    public class PermissionCommand : IMyCommand
    {
        private CreateButton button;  //obiekt wykonujacy
        public PermissionCommand(CreateButton button)
        {
            this.button = button;
        }

        public void Execute()
        {
            button.LoadAddPermissionPage();
        }
    }

    public class MissionCommand : IMyCommand
    {
        private CreateButton button;  //obiekt wykonujacy
        public MissionCommand(CreateButton button)
        {
            this.button = button;
        }

        public void Execute()
        {
            button.LoadAddMissionPage();
        }
    }

    public class EquipmentCommand : IMyCommand
    {
        private CreateButton button;  //obiekt wykonujacy
        public EquipmentCommand(CreateButton button)
        {
            this.button = button;
        }

        public void Execute()
        {
            button.LoadAddEquipmentPage();
        }
    }

    public class EmployeeCommand : IMyCommand
    {
        private CreateButton button;  //obiekt wykonujacy
        public EmployeeCommand(CreateButton button)
        {
            this.button = button;
        }

        public void Execute()
        {
            button.LoadAddEmployeePage();
        }
    }
}
