using ArmyBase.DTO;
using ArmyBase.Service;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBase.ViewModels.Employee
{
    public class EmployeeGridViewModel : Screen
    {
        public List<EmployeeDTO> Employees { get; set; } = new List<EmployeeDTO>();
        public EmployeeGridViewModel()
        {
            Reload();
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
        }

        public void LoadAddEmployeePage()
        {
            IWindowManager manager = new WindowManager();
            AddEmployeeViewModel add = new AddEmployeeViewModel();
            manager.ShowDialog(add, null, null);
            Reload();
        }

        //public void LoadModifyEmployeePage(EmployeeDTO employee)
        //{
        //    IWindowManager manager = new WindowManager();
        //    ModifyEmployeeViewModel modify = new ModifyEmployeeViewModel(employee);
        //    manager.ShowDialog(modify, null, null);
        //    Reload();
        //}//trzeba zrobic ModifyBarrackViewModel

        /*
         * u nas chyb nie bedzie detali zadnych
         * 
         * public void LoadDetailsBarrackPage(BarrackDTO barrack)
        {

            IWindowManager manager = new WindowManager();
            BarrackDetailsViewModel details = new BarrackDetailsViewModel(barrack);
            manager.ShowDialog(details, null, null);
            Reload();
        }*/

        public void Reload()
        {
            Employees = EmployeeService.GetAll();
            NotifyOfPropertyChange(() => Employees);
        }
    }
}

