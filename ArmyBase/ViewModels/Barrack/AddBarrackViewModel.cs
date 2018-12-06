using ArmyBase.DTO;
using ArmyBase.Service;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ArmyBase.ViewModels.Barrack
{
    public class AddBarrackViewModel : Screen
    {
        private bool IsEdit { get; set; }

        private BarrackDTO toEdit { get; set; }

        public BindableCollection<EmployeeDTO> AvailableEmployees { get; set; }

        public BindableCollection<EmployeeDTO> ActualEmployees { get; set; }

        public List<EmployeeDTO> SelectedEmployees { get; set; }

        public string ButtonLabel { get; set; }

        public AddBarrackViewModel(BarrackDTO barrack)
        {
            AvailableEmployees = new BindableCollection<EmployeeDTO>(EmployeeService.GetAll().Where(x => x.BarrackId == null).ToList());
            ActualEmployees = new BindableCollection<EmployeeDTO>(EmployeeService.GetAll().Where(x => x.BarrackId == barrack.Id).ToList());
            IsEdit = true;
            ButtonLabel = "Edit";

            this.toEdit = barrack;
            Name = barrack.Name;
            Capacity = barrack.Capacity;
            NotifyOfPropertyChange(() => Name);
            NotifyOfPropertyChange(() => Capacity);
        }

        public AddBarrackViewModel()
        {
            AvailableEmployees = new BindableCollection<EmployeeDTO>(EmployeeService.GetAll().Where(x => x.BarrackId == null && x.IsSelected == false).ToList());
            ActualEmployees = new BindableCollection<EmployeeDTO>();
            IsEdit = false;
            ButtonLabel = "Add";
        }

        public string Name { get; set; }

        public void Click()
        {
                ActualEmployees.AddRange(AvailableEmployees.Where(x=>x.IsSelected).ToList());
            AvailableEmployees.RemoveRange(ActualEmployees);
                NotifyOfPropertyChange(() => AvailableEmployees);
                NotifyOfPropertyChange(() => ActualEmployees);

        }

        public void ClickBack()
        {

            AvailableEmployees.AddRange(ActualEmployees.Where(x => x.IsSelected).ToList());
            ActualEmployees.RemoveRange(AvailableEmployees);
            NotifyOfPropertyChange(() => AvailableEmployees);
            NotifyOfPropertyChange(() => ActualEmployees);

        }

        public int Capacity { get; set; }

        public void Add()
        {
            if (!IsEdit)
            {
                SelectedEmployees = ActualEmployees.ToList();
                string x = BarrackService.Add(Name, Capacity);
                if (x == null)
                {
                    EmployeeService.AddEmployeesToBarrack(SelectedEmployees, BarrackService.GetAll().Last().Id);
                    TryClose();
                }
                else
                    Error = x;
            }
            else
            {
                toEdit.Name = Name;
                toEdit.Capacity = Capacity;
                SelectedEmployees = ActualEmployees.ToList();
                string x = BarrackService.Edit(toEdit);
                if (x == null)
                {
                    EmployeeService.AddEmployeesToBarrack(SelectedEmployees, toEdit.Id);
                    TryClose();
                }
                else
                    Error = x;
            }
        }

        public void Close()
        {
            TryClose();
        }

        private string error;

        public string Error
        {
            get { return error; }
            set
            {
                error = value;
                NotifyOfPropertyChange(() => Error);
            }
        }

    }
}
