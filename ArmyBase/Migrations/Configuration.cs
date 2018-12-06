using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBase.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ArmyBase.Models.ArmyBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(ArmyBase.Models.ArmyBaseContext db)
        {

        }
    }
}
