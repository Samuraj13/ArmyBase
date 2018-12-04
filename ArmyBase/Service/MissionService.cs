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
    public class MissionService
    {
        public static List<MissionDTO> GetAll()
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                var result = db.Missions.Select(
                                   x => new MissionDTO
                                   {
                                       Id = x.Id,
                                       Name = x.Name,
                                       Description = x.Description,
                                       MissionTypeId = x.MissionTypeId,
                                       StartTime = x.StartTime,
                                       EndTime = x.EndTime,
                                   }).ToList();
                return result;
            }
        }
        public static BindableCollection<MissionDTO> GetAllBindableCollection()
        {
            var result = new BindableCollection<MissionDTO>(GetAll());
            return result;
        }

        public static MissionDTO GetById(int id)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                var result = db.Missions.Where(x => x.Id == id).Select(
                                    x => new MissionDTO
                                    {
                                        Id = x.Id,
                                        Name = x.Name,
                                        Description = x.Description,
                                        MissionTypeId = x.MissionTypeId,
                                        StartTime = x.StartTime,
                                        EndTime = x.EndTime,
                                    }).FirstOrDefault();

                return result;
            }
        }

        public static string Add(string name, string description, int missionTypeId, DateTime startTime, DateTime? endTime)
        {

            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                string error = null;
                Mission newMission = new Mission();
                newMission.Name = name;
                newMission.Description = description;
                newMission.MissionTypeId = missionTypeId;
                newMission.StartTime = startTime;
                newMission.EndTime = endTime;

                var context = new ValidationContext(newMission, null, null);
                var result = new List<ValidationResult>();
                Validator.TryValidateObject(newMission, context, result, true);

                foreach (var x in result)
                {
                    error = error + x.ErrorMessage + "\n";
                }

                if (error == null)
                {
                    db.Missions.Add(newMission);
                    db.SaveChanges();
                }
                return error;
            }

        }

        public static string Edit(MissionDTO Mission)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                string error = null;

                var toModify = db.Missions.Where(x => x.Id == Mission.Id).FirstOrDefault();

                toModify.Name = Mission.Name;
                toModify.Description = Mission.Description;
                toModify.MissionTypeId = Mission.MissionTypeId;
                toModify.StartTime = Mission.StartTime;
                toModify.EndTime = Mission.EndTime;

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
