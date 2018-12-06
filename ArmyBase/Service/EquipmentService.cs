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
    public class EquipmentService
    {
        public static List<EquipmentDTO> GetAll()
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                var result = db.Equipments.Where(x => x.IsDisabled == false).Select(
                                   x => new EquipmentDTO
                                   {
                                       Id = x.Id,
                                       Name = x.Name,
                                       IsAvailable = x.IsAvailable,
                                       EquipmentTypeId = x.EquipmentTypeId,
                                       Quantity = x.Quantity,
                                       Description = x.Description,
                                       EquipmentTypeName = x.EquipmentType != null ? x.EquipmentType.Name : "",
                                       IsAvailableLabel = x.IsAvailable ? "Yes" : "No",
                                   }).ToList();
                return result;
            }
        }
        public static BindableCollection<EquipmentDTO> GetAllBindableCollection()
        {
            var result = new BindableCollection<EquipmentDTO>(GetAll());
            return result;
        }

        public static EquipmentDTO GetById(int id)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                var result = db.Equipments.Where(x => x.Id == id).Select(
                                    x => new EquipmentDTO
                                    {
                                        Id = x.Id,
                                        Name = x.Name,
                                        IsAvailable = x.IsAvailable,
                                        EquipmentTypeId = x.EquipmentTypeId,
                                        Quantity = x.Quantity,
                                        Description = x.Description,
                                    }).FirstOrDefault();

                return result;
            }
        }

        public static string Add(string name, int equipmentTypeId, int quantity, string description, bool isAvailable)
        {

            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                string error = null;
                Equipment newEquipment = new Equipment();
                newEquipment.Name = name;
                newEquipment.EquipmentTypeId = equipmentTypeId;
                newEquipment.Quantity = quantity;
                newEquipment.Description = description;
                newEquipment.IsAvailable = isAvailable;

                var context = new ValidationContext(newEquipment, null, null);
                var result = new List<ValidationResult>();
                Validator.TryValidateObject(newEquipment, context, result, true);

                foreach (var x in result)
                {
                    error = error + x.ErrorMessage + "\n";
                }

                if (error == null)
                {
                    db.Equipments.Add(newEquipment);
                    db.SaveChanges();
                }
                return error;
            }

        }

        public static string Edit(EquipmentDTO Equipment)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                string error = null;

                var toModify = db.Equipments.Where(x => x.Id == Equipment.Id).FirstOrDefault();

                toModify.Name = Equipment.Name;
                toModify.EquipmentTypeId = Equipment.EquipmentTypeId;
                toModify.Quantity = Equipment.Quantity;
                toModify.Description = Equipment.Description;
                toModify.IsAvailable = Equipment.IsAvailable;

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

        public static void Delete(EquipmentDTO Equipment)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                var toDelete = db.Equipments.Where(x => x.Id == Equipment.Id).FirstOrDefault();
                toDelete.IsDisabled = true;

                db.SaveChanges();
            }
        }

    }
}
