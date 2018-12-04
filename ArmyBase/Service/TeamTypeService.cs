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
    public class TeamTypeService
    {
        public static List<TeamTypeDTO> GetAll()
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                var result = db.TeamTypes.Select(
                                   x => new TeamTypeDTO
                                   {
                                       Id = x.Id,
                                       Name = x.Name,
                                   }).ToList();
                return result;
            }
        }
        public static BindableCollection<TeamTypeDTO> GetAllBindableCollection()
        {
            var result = new BindableCollection<TeamTypeDTO>(GetAll());
            return result;
        }

        public static TeamTypeDTO GetById(int id)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                var result = db.TeamTypes.Where(x => x.Id == id).Select(
                                    x => new TeamTypeDTO
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
                TeamType newTeamType = new TeamType();
                newTeamType.Name = name;

                var context = new ValidationContext(newTeamType, null, null);
                var result = new List<ValidationResult>();
                Validator.TryValidateObject(newTeamType, context, result, true);

                foreach (var x in result)
                {
                    error = error + x.ErrorMessage + "\n";
                }

                if (error == null)
                {
                    db.TeamTypes.Add(newTeamType);
                    db.SaveChanges();
                }
                return error;
            }

        }

        public static string Edit(TeamTypeDTO TeamType)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                string error = null;

                var toModify = db.TeamTypes.Where(x => x.Id == TeamType.Id).FirstOrDefault();

                toModify.Name = TeamType.Name;

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
