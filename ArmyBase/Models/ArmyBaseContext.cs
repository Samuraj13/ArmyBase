namespace ArmyBase.Models
{
    using ArmyBase.Models.Initializer;
    using ArmyBase.ViewModels;
    using Caliburn.Micro;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    public class ArmyBaseContext : DbContext
    {
        // Your context has been configured to use a 'Model2' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ArmyBase.Models.Model2' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model2' 
        // connection string in the application configuration file.
        public ArmyBaseContext()
            : base("name=ArmyBaseContext")
        {
            if (!Database.Exists())
            {
                    IWindowManager manager = new WindowManager();
                    DBInitializationViewModel dbInitializingView = new DBInitializationViewModel(this);
                    manager.ShowDialog(dbInitializingView, null, null);
            }
            Database.SetInitializer(new ArmyBaseDBInitializer());
        }

        // Add a DbSet for each entity type that you want to include in your Models. For more information 
        // on configuring and using a Code First Models, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public DbSet<Barrack> Barracks { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<MissionType> MissionTypes { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamType> TeamTypes { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}