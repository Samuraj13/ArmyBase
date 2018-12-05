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

namespace ArmyBase.ViewModels
{
    public class StartUpViewModel : Conductor<object>
    {
        public StartUpViewModel()
        {
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
