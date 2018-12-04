using ArmyBase.ViewModels.Employee;
using ArmyBase.ViewModels.Equipment;
using ArmyBase.ViewModels.Rank;
using ArmyBase.ViewModels.Team;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ArmyBase
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            //HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();
            Initialize();

        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<AddEmployeeViewModel>();

        }
    }
}
