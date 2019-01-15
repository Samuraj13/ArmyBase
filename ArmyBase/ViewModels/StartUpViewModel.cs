using ArmyBase.DesignPattern.Command;
using ArmyBase.DesignPattern.Singleton;
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
using System.Windows.Controls;

namespace ArmyBase.ViewModels
{
    public interface IMyCommand
    {
        void Execute();
    }
   

    public class StartUpViewModel : Conductor<object>
    {
        private readonly ArmyBaseContext context = new ArmyBaseContext();
        private BarrackCommand barrackCommand { get; set; }
        private TeamCommand teamCommand { get; set; }
        private SpecializationCommand specializationCommand { get; set; }
        private RankCommand rankCommand { get; set; }
        private PermissionCommand permissionCommand { get; set; }
        private MissionCommand missionCommand { get; set; }
        private EquipmentCommand equipmentCommand { get; set; }
        private EmployeeCommand employeeCommand { get; set; }

        private IMyCommand mode;

        public void SetCreateMode(IMyCommand command)
        {
            mode = command;
        }

        public void Open()
        {
            mode.Execute();
        }

        private CreateButton _createButton;
        public CreateButton CreateButton
        {
            get { return _createButton; }
            set
            {
                _createButton = value;
            }
        }

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
            
            CreateButton = CreateButton.Initialize();
            barrackCommand = new BarrackCommand(CreateButton);
            teamCommand = new TeamCommand(CreateButton);
            specializationCommand = new SpecializationCommand(CreateButton);
            rankCommand = new RankCommand(CreateButton);
            permissionCommand = new PermissionCommand(CreateButton);
            missionCommand = new MissionCommand(CreateButton);
            equipmentCommand = new EquipmentCommand(CreateButton);
            employeeCommand = new EmployeeCommand(CreateButton);
            LoadBarrackPage();

        }

            //Loading pages methods
        public void LoadBarrackPage()
        {
            ActiveItem = new BarrackGridViewModel();
            this.SetCreateMode(barrackCommand);
        }

        public void LoadEmployeePage()
        {
            ActiveItem = new EmployeeGridViewModel();
            this.SetCreateMode(employeeCommand);
        }

        public void LoadEquipmentPage()
        {
            ActiveItem = new EquipmentGridViewModel();
            this.SetCreateMode(equipmentCommand);
        }

        public void LoadMissionPage()
        {
            ActiveItem = new MissionGridViewModel();
            this.SetCreateMode(missionCommand);
        }

        public void LoadPermissionPage()
        {
            ActiveItem = new PermissionGridViewModel();
            this.SetCreateMode(permissionCommand);
        }

        public void LoadRankPage()
        {
            ActiveItem = new RankGridViewModel();
            this.SetCreateMode(rankCommand);
        }

        public void LoadSpecializationPage()
        {
            ActiveItem = new SpecializationGridViewModel();
            this.SetCreateMode(specializationCommand);
        }

        public void LoadTeamPage()
        {
            ActiveItem = new TeamGridViewModel();
            this.SetCreateMode(teamCommand);
        }

    }
}
