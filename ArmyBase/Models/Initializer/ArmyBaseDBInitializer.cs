using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyBase.Models;

namespace ArmyBase.Models.Initializer
{
    public class ArmyBaseDBInitializer
    {
        public static void Seed(ArmyBaseContext db)
        {
            IList<Barrack> Barracks = new List<Barrack>();
            Barracks.Add(new Barrack() { Id = 1, Name = "Alfa", Capacity = 100 });
            Barracks.Add(new Barrack() { Id = 2, Name = "Beta", Capacity = 200});
            Barracks.Add(new Barrack() { Id = 3, Name = "Gamma", Capacity = 150});
            Barracks.Add(new Barrack() { Id = 4, Name = "Delta", Capacity = 300});

            foreach (var item in Barracks)
                db.Barracks.Add(item);


            IList<Employee> Employees = new List<Employee>();
            Employees.Add(new Employee() { Id = 1, NationalId = 3, FirstName = "Carl", LastName = "Gustav", IsBarrackManager = false, IsTeamLeader = false, Salary = 2022.22, SpecializationId = 1, DateOfEmployment = DateTime.Now, RankId = 1, TeamId = 2, BarrackId = 1 });
            Employees.Add(new Employee() { Id = 2, NationalId = 1, FirstName = "Tonny", LastName = "Peperoni", IsBarrackManager = false, IsTeamLeader = false, Salary = 2890.50, SpecializationId = 2, DateOfEmployment = DateTime.Now, RankId = 3, TeamId = 1, BarrackId = 3 });
            Employees.Add(new Employee() { Id = 3, NationalId = 10, FirstName = "Miroslav", LastName = "Klose", IsBarrackManager = false, IsTeamLeader = false, Salary = 1950.99, SpecializationId = 3, DateOfEmployment = DateTime.Now, RankId = 2, TeamId = 1, BarrackId = 2 });
            Employees.Add(new Employee() { Id = 4, NationalId = 2, FirstName = "Jon ", LastName = "Doe", IsBarrackManager = false, IsTeamLeader = false, Salary = 5000.00, SpecializationId = 1, DateOfEmployment = DateTime.Now, RankId = 1, TeamId = 2, BarrackId = 4 });
            Employees.Add(new Employee() { Id = 5, NationalId = 7, FirstName = "Jack", LastName = "Sparrow", IsBarrackManager = false, IsTeamLeader = false, Salary = 3500.50, SpecializationId = 2, DateOfEmployment = DateTime.Now, RankId = 3, TeamId = 1, BarrackId = 4 });

            foreach (var item in Employees)
                db.Employees.Add(item);


            IList<Equipment> Equipments = new List<Equipment>();
            Equipments.Add(new Equipment() { Id = 1, Name = "Grenade", IsAvailable = true, EquipmentTypeId = 1, Quantity = 1111, Description = "It is a grenade" });
            Equipments.Add(new Equipment() { Id = 2, Name = "Machine gun", IsAvailable = true, EquipmentTypeId = 2, Quantity = 1234, Description = "It is a fast weapon" });
            Equipments.Add(new Equipment() { Id = 3, Name = "AK-47", IsAvailable = false, EquipmentTypeId = 3, Quantity = 0, Description = "It is an AK!" });
            Equipments.Add(new Equipment() { Id = 4, Name = "Smoke Grenade", IsAvailable = true, EquipmentTypeId = 4, Quantity = 100, Description = "It makes smoke" });
            Equipments.Add(new Equipment() { Id = 5, Name = "Knife", IsAvailable = false, EquipmentTypeId = 5, Quantity = 0, Description = "It can hurt" });

            foreach (var item in Equipments)
                db.Equipments.Add(item);


            IList<EquipmentType> EquipmentTypes = new List<EquipmentType>();
            EquipmentTypes.Add(new EquipmentType() { Id = 1, Name = "Grenade" });
            EquipmentTypes.Add(new EquipmentType() { Id = 2, Name = "Machine gun" });
            EquipmentTypes.Add(new EquipmentType() { Id = 3, Name = "AK-47" });
            EquipmentTypes.Add(new EquipmentType() { Id = 4, Name = "Smoke Grenade" });
            EquipmentTypes.Add(new EquipmentType() { Id = 5, Name = "Knife" });

            foreach (var item in EquipmentTypes)
                db.EquipmentTypes.Add(item);


            IList<Mission> Missions = new List<Mission>();
            Missions.Add(new Mission() { Id = 1, Name = "Mission one", Description = "We go to Maroko", MissionTypeId = 1, StartTime = DateTime.Now, EndTime = DateTime.Now });
            Missions.Add(new Mission() { Id = 2, Name = "Mission two", Description = "We go to India", MissionTypeId = 2, StartTime = DateTime.Now, EndTime = DateTime.Now });

            foreach (var item in Missions)
                db.Missions.Add(item);


            IList<MissionType> MissionTypes = new List<MissionType>();
            MissionTypes.Add(new MissionType() { Id = 1, Name = "MissionOne" });
            MissionTypes.Add(new MissionType() { Id = 2, Name = "MissionTwo" });

            foreach (var item in MissionTypes)
                db.MissionTypes.Add(item);


            IList<Permission> Permissions = new List<Permission>();
            Permissions.Add(new Permission() { Id = 1, Name = "Permission for knife", Description = "You can use knife", MinRankId = 1 });
            Permissions.Add(new Permission() { Id = 2, Name = "Permission for AK-47", Description = "You can shoot with AK", MinRankId = 2 });
            Permissions.Add(new Permission() { Id = 3, Name = "Permission for grenades", Description = "You can throw grenades", MinRankId = 3 });

            foreach (var item in Permissions)
                db.Permissions.Add(item);


            IList<Rank> Ranks = new List<Rank>();
            Ranks.Add(new Rank() { Id = 1, Name = "First rank", Description = "It is first rank", MinExperience = 0, CanLead = false, Bonus = 0 });
            Ranks.Add(new Rank() { Id = 2, Name = "Second rank", Description = "It is second rank", MinExperience = 1, CanLead = false, Bonus = 50 });
            Ranks.Add(new Rank() { Id = 3, Name = "Third rank", Description = "It is third rank", MinExperience = 2, CanLead = false, Bonus = 150 });

            foreach (var item in Ranks)
                db.Ranks.Add(item);


            IList<Specialization> Specializations = new List<Specialization>();
            Specializations.Add(new Specialization() { Id = 1, Name = "Sniper", Description = "He is a good killer." });
            Specializations.Add(new Specialization() { Id = 2, Name = "Scout", Description = "He tracking enemys." });
            Specializations.Add(new Specialization() { Id = 3, Name = "Sapper", Description = "He is a bomb specialist." });

            foreach (var item in Specializations)
                db.Specializations.Add(item);


            IList<Team> Teams = new List<Team>();
            Teams.Add(new Team() { Id = 1, Name = "Medics", TeamTypeId = 1, Responsibilities = "The are responsibility for soliders health.", MissionId = 1 });
            Teams.Add(new Team() { Id = 2, Name = "Instructors", TeamTypeId = 2, Responsibilities = "The are responsibility training.", MissionId = 2 });

            foreach (var item in Teams)
                db.Teams.Add(item);


            IList<TeamType> TeamTypes = new List<TeamType>();
            TeamTypes.Add(new TeamType() { Id = 1, Name = "Treating" });
            TeamTypes.Add(new TeamType() { Id = 2, Name = "Training" });

            foreach (var item in TeamTypes)
                db.TeamTypes.Add(item);

            db.SaveChanges();

        }
    }
}
