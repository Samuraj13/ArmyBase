namespace ArmyBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Validation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Team", "MissionId", "dbo.Mission");
            DropIndex("dbo.Team", new[] { "MissionId" });
            AlterColumn("dbo.Team", "MissionId", c => c.Int());
            CreateIndex("dbo.Team", "MissionId");
            AddForeignKey("dbo.Team", "MissionId", "dbo.Mission", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Team", "MissionId", "dbo.Mission");
            DropIndex("dbo.Team", new[] { "MissionId" });
            AlterColumn("dbo.Team", "MissionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Team", "MissionId");
            AddForeignKey("dbo.Team", "MissionId", "dbo.Mission", "Id", cascadeDelete: true);
        }
    }
}
