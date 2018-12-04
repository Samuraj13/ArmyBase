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
        public BindableCollection<RankDTO> Ranks { get; set; }

        public RankDTO SelectedRacnk { get; set; }

        public BindableCollection<SpecializationDTO> Specializations { get; set; }

        public SpecializationDTO SelectedSpecialization { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int NationalId { get; set; }

        public double Salary { get; set; }

        public DateTime HireDate { get; set; }

        public string Error { get; set; }

        public AddEmployeeViewModel()
        {
            Ranks = RankService.GetAllBindableCollection();
            Specializations = SpecializationService.GetAllBindableCollection();
            HireDate = DateTime.Now;
            NotifyOfPropertyChange(() => HireDate);
        }

        public void Add()
        {
            Error = EmployeeService.Add(NationalId, FirstName, LastName, Salary, SelectedSpecialization?.Id, HireDate, SelectedRacnk?.Id);
            NotifyOfPropertyChange(() => Error);
            TryClose();
        }

        public void Close()
        {
            TryClose();
        }
    }
}
