using ArmyBase.DTO;
using ArmyBase.Service;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBase.ViewModels.Barrack
{
    public class AddBarrackViewModel : Screen
    {
        private bool IsEdit { get; set; }

        private BarrackDTO toEdit { get; set; }

        public BindableCollection<EmployeeDTO> Employees { get; set; }

        public List<EmployeeDTO> SelectedEmployees { get; set; }

        public AddBarrackViewModel(BarrackDTO barrack)
        {
            Employees = new BindableCollection<EmployeeDTO>(EmployeeService.GetAll().Where(x => x.BarrackId == null).ToList());
            IsEdit = true;
            this.toEdit = barrack;
            Name = barrack.Name;
            Capacity = barrack.Capacity;
            NotifyOfPropertyChange(() => Name);
            NotifyOfPropertyChange(() => Capacity);
        }

        public AddBarrackViewModel()
        {
            Employees = new BindableCollection<EmployeeDTO>(EmployeeService.GetAll().Where(x => x.BarrackId == null).ToList());
            IsEdit = false;
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public void Add()
        {
            if (!IsEdit)
            {

                SelectedEmployees = Employees.Where(x => x.IsSelected).ToList();
                BarrackService.Add(Name, Capacity);
                EmployeeService.AddEmployeesToBarrack(SelectedEmployees, BarrackService.GetAll().Last().Id);
                TryClose();
            }
            else
            {
                toEdit.Name = Name;
                toEdit.Capacity = Capacity;
                BarrackService.Edit(toEdit);
                TryClose();
            }
        }

        public void Close()
        {
            TryClose();
        }

    }
}
