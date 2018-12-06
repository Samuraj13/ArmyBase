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
                var result = db.Employees.Where(x => x.IsDisabled == false).Select(
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
                                       SpecializationName = x.Specialization != null ? x.Specialization.Name : "",
                                       RankName = x.Rank != null ? x.Rank.Name : "",
                                       TeamName = x.Team != null ? x.Team.Name : "",
                                       BarrackName = x.Barrack != null ? x.Barrack.Name : "",
                                   }).ToList();
                return result;
            }
        }

        public static BindableCollection<EmployeeDTO> GetAllBindableCollection()
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                var result = new BindableCollection<EmployeeDTO>(GetAll());
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

        public static void AddEmployeesToTeam(List<EmployeeDTO> employees, int teamId)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                var clearTeam = db.Employees.Where(x => x.TeamId == teamId).ToList();
                foreach (var employeesInTeam in clearTeam)
                {
                    employeesInTeam.TeamId = null;
                    db.SaveChanges();
                }
                foreach (var employee in employees)
                {

                    var toModify = db.Employees.Where(x => x.Id == employee.Id).FirstOrDefault();

                    toModify.TeamId = teamId;
                    db.SaveChanges();
                }
            }
        }

        public static void AddEmployeesToBarrack(List<EmployeeDTO> employees, int barrackId)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                    var clearBarrack = db.Employees.Where(x => x.BarrackId == barrackId).ToList();
                foreach(var employeeInBarrack in clearBarrack)
                {
                    employeeInBarrack.BarrackId = null;
                    db.SaveChanges();
                }
                foreach (var employee in employees)
                {

                    var toModify = db.Employees.Where(x => x.Id == employee.Id).FirstOrDefault();

                    toModify.BarrackId = barrackId;
                    db.SaveChanges();
                }
            }
        }

        public static void Delete(EmployeeDTO Employee)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                var toDelete = db.Employees.Where(x => x.Id == Employee.Id).FirstOrDefault();
                toDelete.IsDisabled = true;

                db.SaveChanges();
            }
        }

    }
}
