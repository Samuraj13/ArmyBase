using ArmyBase.DesignPattern.Observer;
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
                var result = db.Missions.Where(x => x.IsDisabled == false).Select(
                                   x => new MissionDTO
                                   {
                                       Id = x.Id,
                                       Name = x.Name,
                                       Description = x.Description,
                                       MissionTypeId = x.MissionTypeId,
                                       StartTime = x.StartTime,
                                       EndTime = x.EndTime,
                                       MissionTypeName = x.MissionType != null ? x.MissionType.Name : ""
                                   }).ToList();
                foreach(var item in result)
                {
                    item.Observers = GetAllObservers(item.Id);
                }
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

        public static string Add(MissionDTO newMissionDTO)
        {

            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                string error = null;
                Mission newMission = new Mission();
                newMission.Name = newMissionDTO.Name;
                newMission.Description = newMissionDTO.Description;
                newMission.MissionTypeId = newMissionDTO.MissionTypeId;
                newMission.StartTime = newMissionDTO.StartTime;
                newMission.EndTime = newMissionDTO.EndTime;

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

        public static void Delete(MissionDTO Mission)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                var toDelete = db.Missions.Where(x => x.Id == Mission.Id).FirstOrDefault();
                toDelete.IsDisabled = true;

                db.SaveChanges();
            }
        }

        public static List<IMyObserver> GetAllObservers(int missionId)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                var observers = TeamService.GetAll().Where(x => x.MissionId == missionId).ToList<IMyObserver>();

                return observers;
            }

        }

        public static void SetObserversToMission(List<IMyObserver> teams, int missionId)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {

                var clearMission = db.Teams.Where(x => x.MissionId == missionId).ToList();
                foreach (var teamsInMission in clearMission)
                {
                    teamsInMission.MissionId = null;
                    db.SaveChanges();
                }
                foreach (TeamDTO team in teams)
                {

                    var toModify = db.Teams.Where(x => x.Id == team.Id).FirstOrDefault();

                    toModify.MissionId = missionId;
                    db.SaveChanges();
                }
            }
        }
    }
}
