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
    public class EquipmentTypeService
    {
        public static List<EquipmentTypeDTO> GetAll()
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                var result = db.EquipmentTypes.Select(
                                   x => new EquipmentTypeDTO
                                   {
                                       Id = x.Id,
                                       Name = x.Name,
                                   }).ToList();
                return result;
            }
        }
        public static BindableCollection<EquipmentTypeDTO> GetAllBindableCollection()
        {
            var result = new BindableCollection<EquipmentTypeDTO>(GetAll());
            return result;
        }

        public static EquipmentTypeDTO GetById(int id)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                var result = db.EquipmentTypes.Where(x => x.Id == id).Select(
                                    x => new EquipmentTypeDTO
                                    {
                                        Id = x.Id,
                                        Name = x.Name,
                                    }).FirstOrDefault();

                return result;
            }
        }

        public static string Add(string name)
        {

            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                string error = null;
                EquipmentType newEquipmentType = new EquipmentType();
                newEquipmentType.Name = name;

                var context = new ValidationContext(newEquipmentType, null, null);
                var result = new List<ValidationResult>();
                Validator.TryValidateObject(newEquipmentType, context, result, true);

                foreach (var x in result)
                {
                    error = error + x.ErrorMessage + "\n";
                }

                if (error == null)
                {
                    db.EquipmentTypes.Add(newEquipmentType);
                    db.SaveChanges();
                }
                return error;
            }

        }

        public static string Edit(EquipmentTypeDTO EquipmentType)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                string error = null;

                var toModify = db.EquipmentTypes.Where(x => x.Id == EquipmentType.Id).FirstOrDefault();

                toModify.Name = EquipmentType.Name;

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
