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

        private DateTime _dateOfEmployment;

        public DateTime DateOfEmployment
        {
            get
            {
                return _dateOfEmployment;
            }
            set
            {
                if (IsEdit && _dateOfEmployment == new DateTime(1,1,1))
                {
                    _dateOfEmployment = toEdit.DateOfEmployment;
                }
                else
                {
                    _dateOfEmployment = value;
                }
                NotifyOfPropertyChange(() => DateOfEmployment);
            }
        }

        

        public double Salary { get; set; }

        public int? ActualRank { get; set; }

        public int? ActualSpecialization { get; set; }

        public string ButtonLabel { get; set; }



        public AddEmployeeViewModel(EmployeeDTO employee)
        {
            IsEdit = true;
            ButtonLabel = "Edit";
            Ranks = RankService.GetAllBindableCollection();
            Specializations = SpecializationService.GetAllBindableCollection();
            int i = 0;
            if (employee.RankId != null)
            {
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
            }

            if (employee.SpecializationId != null)
            {
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
            }

            this.toEdit = employee;
            NationalId = employee.NationalId;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
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
            ButtonLabel = "Add";
            Ranks = RankService.GetAllBindableCollection();
            Specializations = SpecializationService.GetAllBindableCollection();
            DateOfEmployment = DateTime.Now;
            NotifyOfPropertyChange(() => DateOfEmployment);
        }

        public void Add()
        {
            if (!IsEdit)
            {
                string x = EmployeeService.Add(NationalId, FirstName, LastName, Salary, SelectedSpecialization?.Id, DateOfEmployment, SelectedRank?.Id);
                if (x == null)
                    TryClose();
                else
                    Error = x;
            }
            else
            {
                toEdit.NationalId = NationalId;
                toEdit.FirstName = FirstName;
                toEdit.LastName = LastName;
                toEdit.Salary = Salary;
                toEdit.DateOfEmployment = DateOfEmployment;
                toEdit.SpecializationId = SelectedSpecialization.Id;
                toEdit.RankId = SelectedRank.Id;
                string x = EmployeeService.Edit(toEdit);
                if (x == null)
                {
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
