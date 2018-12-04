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
    public class RankService
    {
        public static List<RankDTO> GetAll()
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                var result = db.Ranks.Select(
                                   x => new RankDTO
                                   {
                                       Id = x.Id,
                                       Name = x.Name,
                                       Description = x.Description,
                                       MinExperience = x.MinExperience,
                                       CanLead = x.CanLead,
                                       Bonus = x.Bonus,
                                   }).ToList();
                return result;
            }
        }
        public static BindableCollection<RankDTO> GetAllBindableCollection()
        {
            var result = new BindableCollection<RankDTO>(GetAll());
            return result;
        }

        public static RankDTO GetById(int id)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                var result = db.Ranks.Where(x => x.Id == id).Select(
                                    x => new RankDTO
                                    {
                                        Id = x.Id,
                                        Name = x.Name,
                                        Description = x.Description,
                                        MinExperience = x.MinExperience,
                                        CanLead = x.CanLead,
                                        Bonus = x.Bonus,
                                    }).FirstOrDefault();

                return result;
            }
        }

        public static string Add(string name, string description, int? bonus, bool canLead, int minExperience)
        {

            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                string error = null;
                Rank newRank = new Rank();
                newRank.Name = name;
                newRank.Description = description;
                newRank.MinExperience = minExperience;
                newRank.CanLead = canLead;
                newRank.Bonus = bonus;

                var context = new ValidationContext(newRank, null, null);
                var result = new List<ValidationResult>();
                Validator.TryValidateObject(newRank, context, result, true);

                foreach (var x in result)
                {
                    error = error + x.ErrorMessage + "\n";
                }

                if (error == null)
                {
                    db.Ranks.Add(newRank);
                    db.SaveChanges();
                }
                return error;
            }

        }

        public static string Edit(RankDTO Rank)
        {
            using (ArmyBaseContext db = new ArmyBaseContext())
            {
                string error = null;

                var toModify = db.Ranks.Where(x => x.Id == Rank.Id).FirstOrDefault();

                toModify.Name = Rank.Name;
                toModify.Description = Rank.Description;
                toModify.MinExperience = Rank.MinExperience;
                toModify.CanLead = Rank.CanLead;
                toModify.Bonus = Rank.Bonus;

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
