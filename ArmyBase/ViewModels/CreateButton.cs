using ArmyBase.Models;
using ArmyBase.Models.Initializer;
using ArmyBase.ViewModels.Barrack;
using ArmyBase.ViewModels.Employee;
using ArmyBase.ViewModels.Equipment;
using ArmyBase.ViewModels.EquipmentType;
using ArmyBase.ViewModels.Mission;
using ArmyBase.ViewModels.MissionType;
using ArmyBase.ViewModels.Permission;
using ArmyBase.ViewModels.Rank;
using ArmyBase.ViewModels.Specialization;
using ArmyBase.ViewModels.Team;
using ArmyBase.ViewModels.TeamType;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBase.ViewModels
{
    public class CreateButton
    {

        private static CreateButton instance = null;

        private CreateButton()
        {
        }

        public static CreateButton Initialize()
        {
            if (instance == null)
            {
                instance = new CreateButton();
                return instance;
            }
            Console.WriteLine("Button is created!");
            return instance;
        }

        public void LoadAddBarrackPage()
        {
            IWindowManager manager = new WindowManager();
            AddBarrackViewModel add = new AddBarrackViewModel();
            manager.ShowDialog(add, null, null);
        }

        public void LoadAddTeamPage()
        {
            IWindowManager manager = new WindowManager();
            AddTeamViewModel add = new AddTeamViewModel();
            manager.ShowDialog(add, null, null);
        }

        public void LoadAddSpecializationPage()
        {
            IWindowManager manager = new WindowManager();
            AddSpecializationViewModel add = new AddSpecializationViewModel();
            manager.ShowDialog(add, null, null);
        }

        public void LoadAddRankPage()
        {
            IWindowManager manager = new WindowManager();
            AddRankViewModel add = new AddRankViewModel();
            manager.ShowDialog(add, null, null);
        }

        public void LoadAddPermissionPage()
        {
            IWindowManager manager = new WindowManager();
            AddPermissionViewModel add = new AddPermissionViewModel();
            manager.ShowDialog(add, null, null);
        }

        public void LoadAddMissionPage()
        {
            IWindowManager manager = new WindowManager();
            AddMissionViewModel add = new AddMissionViewModel();
            manager.ShowDialog(add, null, null);
        }

        public void LoadAddEquipmentPage()
        {
            IWindowManager manager = new WindowManager();
            AddEquipmentViewModel add = new AddEquipmentViewModel();
            manager.ShowDialog(add, null, null);
        }

        public void LoadAddEmployeePage()
        {
            IWindowManager manager = new WindowManager();
            AddEmployeeViewModel add = new AddEmployeeViewModel();
            manager.ShowDialog(add, null, null);
        }


    }

    public class BarrackCommand : ICommand
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

    public class TeamCommand : ICommand
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

    public class SpecializationCommand : ICommand
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

    public class RankCommand : ICommand
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

    public class PermissionCommand : ICommand
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

    public class MissionCommand : ICommand
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

    public class EquipmentCommand : ICommand
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

    public class EmployeeCommand : ICommand
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
