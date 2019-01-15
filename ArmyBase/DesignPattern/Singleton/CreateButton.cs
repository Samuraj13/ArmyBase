using ArmyBase.ViewModels.Barrack;
using ArmyBase.ViewModels.Employee;
using ArmyBase.ViewModels.Equipment;
using ArmyBase.ViewModels.Mission;
using ArmyBase.ViewModels.Permission;
using ArmyBase.ViewModels.Rank;
using ArmyBase.ViewModels.Specialization;
using ArmyBase.ViewModels.Team;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBase.DesignPattern.Singleton
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
}
