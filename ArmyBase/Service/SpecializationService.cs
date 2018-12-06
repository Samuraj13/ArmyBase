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
                var result = db.Specializations.Where(x => x.IsDisabled == false).Select(
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

        public static string Add(string name, string description, List<EquipmentDTO> equipment, List<PermissionDTO> permissions)
        {

            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                string error = null;
                Specialization newSpecialization = new Specialization();
                newSpecialization.Name = name;
                newSpecialization.Description = description;
                var assignEquipments = new List<Equipment>();
                foreach(var e in equipment)
                {
                    var result1 = db.Equipments.Where(x => x.Id == e.Id).FirstOrDefault();
                    assignEquipments.Add(result1);
                }
                var assignPermissions = new List<Permission>();
                foreach (var p in permissions)
                {
                    var result1 = db.Permissions.Where(x => x.Id == p.Id).FirstOrDefault();
                    assignPermissions.Add(result1);
                }
                newSpecialization.Equipment = assignEquipments;
                newSpecialization.Permission = assignPermissions;

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

        public static string Edit(SpecializationDTO Specialization, List<EquipmentDTO> equipment, List<PermissionDTO> permissions)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                string error = null;

                var toModify = db.Specializations.Include("Permission").Include("Equipment").Where(x => x.Id == Specialization.Id).FirstOrDefault();

                toModify.Name = Specialization.Name;
                toModify.Description = Specialization.Description;

                var assignEquipments = new List<Equipment>();
                foreach (var e in equipment)
                {
                    var result1 = db.Equipments.Where(x => x.Id == e.Id).FirstOrDefault();
                    assignEquipments.Add(result1);
                }
                var assignPermissions = new List<Permission>();
                foreach (var p in permissions)
                {
                    var result1 = db.Permissions.Where(x => x.Id == p.Id).FirstOrDefault();
                    assignPermissions.Add(result1);
                }
                toModify.Permission = assignPermissions;
                toModify.Equipment = assignEquipments;

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
                toDelete.IsDisabled = true;

                db.SaveChanges();
            }
        }

    }
}
