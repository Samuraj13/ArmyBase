using ArmyBase.DTO;

namespace ArmyBase.ViewModels.Employee
{
    internal class ModifyEmployeeViewModel
    {
        private EmployeeDTO employee;

        public ModifyEmployeeViewModel(EmployeeDTO employee)
        {
            this.employee = employee;
        }
    }
}