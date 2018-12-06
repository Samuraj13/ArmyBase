namespace ArmyBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsDisabledFlag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Barrack", "IsDisabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employee", "IsDisabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Rank", "IsDisabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Permission", "IsDisabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Specialization", "IsDisabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Equipment", "IsDisabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.EquipmentType", "IsDisabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Team", "IsDisabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Mission", "IsDisabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.MissionType", "IsDisabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.TeamType", "IsDisabled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TeamType", "IsDisabled");
            DropColumn("dbo.MissionType", "IsDisabled");
            DropColumn("dbo.Mission", "IsDisabled");
            DropColumn("dbo.Team", "IsDisabled");
            DropColumn("dbo.EquipmentType", "IsDisabled");
            DropColumn("dbo.Equipment", "IsDisabled");
            DropColumn("dbo.Specialization", "IsDisabled");
            DropColumn("dbo.Permission", "IsDisabled");
            DropColumn("dbo.Rank", "IsDisabled");
            DropColumn("dbo.Employee", "IsDisabled");
            DropColumn("dbo.Barrack", "IsDisabled");
        }
    }
}
