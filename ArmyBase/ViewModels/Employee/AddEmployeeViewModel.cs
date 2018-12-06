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
    public class AddEmployeeViewModel : Screen
    {
        private bool IsEdit { get; set; }

        private EmployeeDTO toEdit { get; set; }

        public BindableCollection<RankDTO> Ranks { get; set; }

        public BindableCollection<SpecializationDTO> Specializations { get; set; }

        public RankDTO SelectedRank { get; set; }

        public SpecializationDTO SelectedSpecialization { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int NationalId { get; set; }

        public DateTime DateOfEmployment { get; set; }

        

        public double Salary { get; set; }

        public int? ActualRank { get; set; }

        public int? ActualSpecialization { get; set; }

        

        public AddEmployeeViewModel(EmployeeDTO employee)
        {
            Ranks = RankService.GetAllBindableCollection();
            Specializations = SpecializationService.GetAllBindableCollection();
            int i = 0;
            while (ActualRank == null)
            {
                if (Ranks[i].Id == employee.RankId)
                {
                    ActualRank = i;
                    break;
                }
                else
                {
                    i++;
                }
            }

            int j = 0;
            while (ActualSpecialization == null)
            {
                if (Specializations[j].Id == employee.SpecializationId)
                {
                    ActualSpecialization = j;
                    break;
                }
                else
                {
                    j++;
                }
            }

            this.toEdit = employee;
            NationalId = employee.NationalId;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            //SelectedRank = EmployeeService.GetById(employee.RankId);
            Salary = employee.Salary;
            DateOfEmployment = employee.DateOfEmployment;
            NotifyOfPropertyChange(() => NationalId);
            NotifyOfPropertyChange(() => FirstName);
            NotifyOfPropertyChange(() => LastName);
            NotifyOfPropertyChange(() => Salary);
            NotifyOfPropertyChange(() => DateOfEmployment);
        }

        public AddEmployeeViewModel()
        {
            IsEdit = false;
        }

        public void Add()
        {
            if (!IsEdit)
            {
                EmployeeService.Add(NationalId, FirstName, LastName, Salary, SelectedSpecialization?.Id, DateOfEmployment, SelectedRank?.Id);
                TryClose();
            }
            else
            {
                toEdit.NationalId = NationalId;
                toEdit.FirstName = FirstName;
                toEdit.LastName = LastName;
                toEdit.Salary = Salary;
                toEdit.DateOfEmployment = DateOfEmployment;
                TryClose();
            }
        }

        public void Close()
        {
            TryClose();
        }
    }
}
