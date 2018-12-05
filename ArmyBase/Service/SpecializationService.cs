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
    public class SpecializationService
    {
        public static List<SpecializationDTO> GetAll()
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                var result = db.Specializations.Select(
                                   x => new SpecializationDTO
                                   {
                                       Id = x.Id,
                                       Name = x.Name,
                                       Description = x.Description,
                                   }).ToList();
                return result;
            }
        }
        public static BindableCollection<SpecializationDTO> GetAllBindableCollection()
        {
            var result = new BindableCollection<SpecializationDTO>(GetAll());
            return result;
        }

        public static SpecializationDTO GetById(int id)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                var result = db.Specializations.Where(x => x.Id == id).Select(
                                    x => new SpecializationDTO
                                    {
                                        Id = x.Id,
                                        Name = x.Name,
                                        Description = x.Description,
                                    }).FirstOrDefault();

                return result;
            }
        }

        public static string Add(string name, string description)
        {

            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                string error = null;
                Specialization newSpecialization = new Specialization();
                newSpecialization.Name = name;
                newSpecialization.Description = description;

                var context = new ValidationContext(newSpecialization, null, null);
                var result = new List<ValidationResult>();
                Validator.TryValidateObject(newSpecialization, context, result, true);

                foreach (var x in result)
                {
                    error = error + x.ErrorMessage + "\n";
                }

                if (error == null)
                {
                    db.Specializations.Add(newSpecialization);
                    db.SaveChanges();
                }
                return error;
            }

        }

        public static string Edit(SpecializationDTO Specialization)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                string error = null;

                var toModify = db.Specializations.Where(x => x.Id == Specialization.Id).FirstOrDefault();

                toModify.Name = Specialization.Name;
                toModify.Description = Specialization.Description;

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

        public static void Delete(SpecializationDTO Specialization)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                var toDelete = db.Specializations.Where(x => x.Id == Specialization.Id).FirstOrDefault();

                db.Specializations.Remove(toDelete);
                db.SaveChanges();
            }
        }

    }
}
