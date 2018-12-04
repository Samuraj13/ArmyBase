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
    public class MissionTypeService
    {
        public static List<MissionTypeDTO> GetAll()
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                var result = db.MissionTypes.Select(
                                   x => new MissionTypeDTO
                                   {
                                       Id = x.Id,
                                       Name = x.Name,
                                   }).ToList();
                return result;
            }
        }
        public static BindableCollection<MissionTypeDTO> GetAllBindableCollection()
        {
            var result = new BindableCollection<MissionTypeDTO>(GetAll());
            return result;
        }

        public static MissionTypeDTO GetById(int id)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                var result = db.MissionTypes.Where(x => x.Id == id).Select(
                                    x => new MissionTypeDTO
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
                MissionType newMissionType = new MissionType();
                newMissionType.Name = name;

                var context = new ValidationContext(newMissionType, null, null);
                var result = new List<ValidationResult>();
                Validator.TryValidateObject(newMissionType, context, result, true);

                foreach (var x in result)
                {
                    error = error + x.ErrorMessage + "\n";
                }

                if (error == null)
                {
                    db.MissionTypes.Add(newMissionType);
                    db.SaveChanges();
                }
                return error;
            }

        }

        public static string Edit(MissionTypeDTO MissionType)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                string error = null;

                var toModify = db.MissionTypes.Where(x => x.Id == MissionType.Id).FirstOrDefault();

                toModify.Name = MissionType.Name;

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
