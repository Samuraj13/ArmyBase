using ArmyBase.DTO;
using ArmyBase.Model;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBase.Service
{
    public class BarrackService
    {
        public static List<BarrackDTO> GetAll()
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                var result = db.Barracks.Select(
                                   x => new BarrackDTO
                                   {
                                       Id = x.Id,
                                       Capacity = x.Capacity,
                                       Name = x.Name
                                   }).ToList();
                return result;
            }
        }
        public static BindableCollection<BarrackDTO> GetAllBindableCollection()
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                var result = new BindableCollection<BarrackDTO>(db.Barracks.Select(
                                   x => new BarrackDTO
                                   {
                                       Id = x.Id,
                                       Capacity = x.Capacity,
                                       Name = x.Name
                                   }).ToList());
                return result;
            }
        }

        public static BarrackDTO GetById(int id)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                var result = db.Barracks.Where(x => x.Id == id).Select(
                                    x => new BarrackDTO
                                    {
                                        Id = x.Id,
                                        Capacity = x.Capacity,
                                        Name = x.Name
                                    }).FirstOrDefault();

                return result;
            }
        }

        public static string Add(string name, int capacity)
        {

            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                string error = null;
                Barrack newBarrack = new Barrack();
                newBarrack.Name = name;
                newBarrack.Capacity = capacity;
                


                var context = new ValidationContext(newBarrack, null, null);
                var result = new List<ValidationResult>();
                Validator.TryValidateObject(newBarrack, context, result, true);

                foreach (var x in result)
                {
                    error = error + x.ErrorMessage + "\n";
                }




                if (error == null)
                {
                    db.Barracks.Add(newBarrack);
                    db.SaveChanges();
                }
                return error;
            }

        }

        public static string Edit(BarrackDTO Barrack)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                string error = null;

                var toModify = db.Barracks.Where(x => x.Id == Barrack.Id).FirstOrDefault();

                toModify.Name = Barrack.Name;
                toModify.Capacity = Barrack.Capacity;

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
        public static List<EmployeeDTO> GetEmplyeeListByBarrackId(int id)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                var result = db.Employees.Where(x => x.BarrackId == id).Select(
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

    }


}

