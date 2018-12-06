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
    public class StartUpViewModel : Conductor<object>
    {
        private readonly ArmyBaseContext context = new ArmyBaseContext();

        public StartUpViewModel()
        {
        }

        protected override void OnViewLoaded(object view)
        {
            if (!context.Database.Exists())
            {
                IWindowManager manager = new WindowManager();
                DBInitializationViewModel dbInitializingView = new DBInitializationViewModel(context);
                manager.ShowDialog(dbInitializingView, null, null);
            }

            ActiveItem = new BarrackGridViewModel();

        }

            //Loading pages methods
            public void LoadBarrackPage()
        {
            ActiveItem = new BarrackGridViewModel();
        }

        public void LoadEmployeePage()
        {
            ActiveItem = new EmployeeGridViewModel();
        }

        public void LoadEquipmentPage()
        {
            ActiveItem = new EquipmentGridViewModel();
        }

        public void LoadMissionPage()
        {
            ActiveItem = new MissionGridViewModel();
        }

        public void LoadPermissionPage()
        {
            ActiveItem = new PermissionGridViewModel();
        }

        public void LoadRankPage()
        {
            ActiveItem = new RankGridViewModel();
        }

        public void LoadSpecializationPage()
        {
            ActiveItem = new SpecializationGridViewModel();
        }

        public void LoadTeamPage()
        {
            ActiveItem = new TeamGridViewModel();
        }

    }
}
