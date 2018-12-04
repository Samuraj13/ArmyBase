using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBase.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ArmyBase.Model.ArmyBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ArmyBase.Model.ArmyBaseContext db)
        {

        }
    }
}
