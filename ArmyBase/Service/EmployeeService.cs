using ArmyBase.DTO;
using ArmyBase.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBase.Service
{
    public class EmployeeService
    {
        public static List<EmployeeDTO> GetAll()
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                var result = db.Employees.Select(
                                   x => new EmployeeDTO
                                   {
                                       Id = x.Id,
                                       NationalId = x.NationalId,
                                       FirstName = x.FirstName,
                                       LastName = x.LastName,
                                       IsBarrackManager = x.IsBarrackManager,
                                       IsTeamLeader = x.IsTeamLeader,
                                       Salary = x.Salary,
                                       SpecializationId = x.SpecializationId,
                                       DateOfEmployment = x.DateOfEmployment,
                                       RankId = x.RankId,
                                       TeamId = x.TeamId,
                                       BarrackId = x.BarrackId,
                                   }).ToList();
                return result;
            }
        }
        public static BindableCollection<EmployeeDTO> GetAllBindableCollection()
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                var result = new BindableCollection<EmployeeDTO>(db.Employees.Select(
                                   x => new EmployeeDTO
                                   {
                                       Id = x.Id,
                                       NationalId = x.NationalId,
                                       FirstName = x.FirstName,
                                       LastName = x.LastName,
                                       IsBarrackManager = x.IsBarrackManager,
                                       IsTeamLeader = x.IsTeamLeader,
                                       Salary = x.Salary,
                                       SpecializationId = x.SpecializationId,
                                       DateOfEmployment = x.DateOfEmployment,
                                       RankId = x.RankId,
                                       TeamId = x.TeamId,
                                       BarrackId = x.BarrackId,
                                   }).ToList());
                return result;
            }
        }

        public static EmployeeDTO GetById(int id)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                var result = db.Employees.Where(x => x.Id == id).Select(
                                    x => new EmployeeDTO
                                    {
                                        Id = x.Id,
                                        NationalId = x.NationalId,
                                        FirstName = x.FirstName,
                                        LastName = x.LastName,
                                        IsBarrackManager = x.IsBarrackManager,
                                        IsTeamLeader = x.IsTeamLeader,
                                        Salary = x.Salary,
                                        SpecializationId = x.SpecializationId,
                                        DateOfEmployment = x.DateOfEmployment,
                                        RankId = x.RankId,
                                        TeamId = x.TeamId,
                                        BarrackId = x.BarrackId,
                                    }).FirstOrDefault();

                return result;
            }
        }

        public static string Add(int nationalId, string firstName, string lastName, double salary, int? specializationId, DateTime dateOfEmployment, int? rankId, int? teamId = null, int? barrackId = null)
        {

            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                string error = null;
                Employee newEmployee = new Employee();
                newEmployee.NationalId = nationalId;
                newEmployee.FirstName = firstName;
                newEmployee.LastName = lastName;
                newEmployee.Salary = salary;
                newEmployee.SpecializationId = specializationId;
                newEmployee.DateOfEmployment = dateOfEmployment;
                newEmployee.RankId = rankId;
                newEmployee.TeamId = teamId;
                newEmployee.BarrackId = barrackId;

                var context = new ValidationContext(newEmployee, null, null);
                var result = new List<ValidationResult>();
                Validator.TryValidateObject(newEmployee, context, result, true);

                foreach (var x in result)
                {
                    error = error + x.ErrorMessage + "\n";
                }
                
                if (error == null)
                {
                    db.Employees.Add(newEmployee);
                    db.SaveChanges();
                }
                return error;
            }

        }

        public static string Edit(EmployeeDTO employee)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                string error = null;

                var toModify = db.Employees.Where(x => x.Id == employee.Id).FirstOrDefault();

                toModify.NationalId = employee.NationalId;
                toModify.FirstName = employee.FirstName;
                toModify.LastName = employee.LastName;
                toModify.Salary = employee.Salary;
                toModify.SpecializationId = employee.SpecializationId;
                toModify.DateOfEmployment = employee.DateOfEmployment;
                toModify.RankId = employee.RankId;
                toModify.TeamId = employee.TeamId;
                toModify.BarrackId = employee.BarrackId;

                var context = new ValidationContext(toModify, null, null);
                var result = new List<ValidationResult>();
                Validator.TryValidateObject(toModify, context, result, true);

                foreach (var x in result)
                {
                    error = error + x.ErrorMessage + "\n";
                }

                if (error == null)
                {
                    db.SaveChanges();
                }
                return error;
            }
        }
    }
}
