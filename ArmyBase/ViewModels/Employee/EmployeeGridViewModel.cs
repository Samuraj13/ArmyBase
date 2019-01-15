using ArmyBase.DTO;
using ArmyBase.Service;
using ArmyBase.ViewModels.Equipment;
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

        public void LoadModifyEmployeePage(EmployeeDTO employee)
        {
            IWindowManager manager = new WindowManager();
            AddEmployeeViewModel modify = new AddEmployeeViewModel(employee);
            manager.ShowDialog(modify, null, null);
            Reload();
        }

        public void Delete(EmployeeDTO employee)
        {
            IWindowManager manager = new WindowManager();
            DeleteConfirmationViewModel modify = new DeleteConfirmationViewModel();
            bool? showDialogResult = manager.ShowDialog(modify, null, null);
            if (showDialogResult != null && showDialogResult == true)
            {
                EmployeeService.Delete(employee);
            }
            Reload();
        }

        public void Reload()
        {
            Employees = EmployeeService.GetAll();
            NotifyOfPropertyChange(() => Employees);
        }
    }
}

