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
    public class PermissionService
    {
        public static List<PermissionDTO> GetAll()
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                var result = db.Permissions.Where(x => x.IsDisabled == false).Select(
                                   x => new PermissionDTO
                                   {
                                       Id = x.Id,
                                       Name = x.Name,
                                       Description = x.Description,
                                       MinRankId = x.MinRankId,
                                       MinRankName = x.MinRank.Name,
                                   }).ToList();
                return result;
            }
        }
        public static BindableCollection<PermissionDTO> GetAllBindableCollection()
        {
            var result = new BindableCollection<PermissionDTO>(GetAll());
            return result;
        }

        public static PermissionDTO GetById(int id)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                var result = db.Permissions.Where(x => x.Id == id).Select(
                                    x => new PermissionDTO
                                    {
                                        Id = x.Id,
                                        Name = x.Name,
                                        Description = x.Description,
                                        MinRankId = x.MinRankId
                                    }).FirstOrDefault();

                return result;
            }
        }
        
        public static string Add(string name, string description, int minRankId)
        {

            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                string error = null;
                Permission newPermission = new Permission();
                newPermission.Name = name;
                newPermission.Description = description;
                newPermission.MinRankId = minRankId;

                var context = new ValidationContext(newPermission, null, null);
                var result = new List<ValidationResult>();
                Validator.TryValidateObject(newPermission, context, result, true);

                foreach (var x in result)
                {
                    error = error + x.ErrorMessage + "\n";
                }

                if (error == null)
                {
                    db.Permissions.Add(newPermission);
                    db.SaveChanges();
                }
                return error;
            }

        }

        public static string Edit(PermissionDTO Permission)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                string error = null;

                var toModify = db.Permissions.Where(x => x.Id == Permission.Id).FirstOrDefault();

                toModify.Name = Permission.Name;
                toModify.Description = Permission.Description;
                toModify.MinRankId = Permission.MinRankId;

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

        public static void Delete(PermissionDTO Permission)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                var toDelete = db.Permissions.Where(x => x.Id == Permission.Id).FirstOrDefault();
                toDelete.IsDisabled = true;

                db.SaveChanges();
            }
        }

    }
}
