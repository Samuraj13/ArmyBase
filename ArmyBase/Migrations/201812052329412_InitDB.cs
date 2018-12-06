namespace ArmyBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Barrack",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Capacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NationalId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        IsBarrackManager = c.Boolean(nullable: false),
                        IsTeamLeader = c.Boolean(nullable: false),
                        Salary = c.Double(nullable: false),
                        SpecializationId = c.Int(),
                        DateOfEmployment = c.DateTime(nullable: false),
                        RankId = c.Int(),
                        TeamId = c.Int(),
                        BarrackId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Barrack", t => t.BarrackId)
                .ForeignKey("dbo.Rank", t => t.RankId)
                .ForeignKey("dbo.Specialization", t => t.SpecializationId)
                .ForeignKey("dbo.Team", t => t.TeamId)
                .Index(t => t.SpecializationId)
                .Index(t => t.RankId)
                .Index(t => t.TeamId)
                .Index(t => t.BarrackId);
            
            CreateTable(
                "dbo.Rank",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        MinExperience = c.Int(nullable: false),
                        CanLead = c.Boolean(nullable: false),
                        Bonus = c.Int(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Permission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        MinRankId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rank", t => t.MinRankId, cascadeDelete: true)
                .Index(t => t.MinRankId);
            
            CreateTable(
                "dbo.Specialization",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Equipment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        EquipmentTypeId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EquipmentType", t => t.EquipmentTypeId, cascadeDelete: true)
                .Index(t => t.EquipmentTypeId);
            
            CreateTable(
                "dbo.EquipmentType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        TeamTypeId = c.Int(nullable: false),
                        MissionId = c.Int(nullable: false),
                        Responsibilities = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Mission", t => t.MissionId, cascadeDelete: true)
                .ForeignKey("dbo.TeamType", t => t.TeamTypeId, cascadeDelete: true)
                .Index(t => t.TeamTypeId)
                .Index(t => t.MissionId);
            
            CreateTable(
                "dbo.Mission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        MissionTypeId = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MissionType", t => t.MissionTypeId, cascadeDelete: true)
                .Index(t => t.MissionTypeId);
            
            CreateTable(
                "dbo.MissionType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeamType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EquipmentSpecializations",
                c => new
                    {
                        Equipment_Id = c.Int(nullable: false),
                        Specialization_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Equipment_Id, t.Specialization_Id })
                .ForeignKey("dbo.Equipment", t => t.Equipment_Id, cascadeDelete: true)
                .ForeignKey("dbo.Specialization", t => t.Specialization_Id, cascadeDelete: true)
                .Index(t => t.Equipment_Id)
                .Index(t => t.Specialization_Id);
            
            CreateTable(
                "dbo.SpecializationPermissions",
                c => new
                    {
                        Specialization_Id = c.Int(nullable: false),
                        Permission_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Specialization_Id, t.Permission_Id })
                .ForeignKey("dbo.Specialization", t => t.Specialization_Id, cascadeDelete: true)
                .ForeignKey("dbo.Permission", t => t.Permission_Id, cascadeDelete: true)
                .Index(t => t.Specialization_Id)
                .Index(t => t.Permission_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "TeamId", "dbo.Team");
            DropForeignKey("dbo.Team", "TeamTypeId", "dbo.TeamType");
            DropForeignKey("dbo.Team", "MissionId", "dbo.Mission");
            DropForeignKey("dbo.Mission", "MissionTypeId", "dbo.MissionType");
            DropForeignKey("dbo.Employee", "SpecializationId", "dbo.Specialization");
            DropForeignKey("dbo.Employee", "RankId", "dbo.Rank");
            DropForeignKey("dbo.SpecializationPermissions", "Permission_Id", "dbo.Permission");
            DropForeignKey("dbo.SpecializationPermissions", "Specialization_Id", "dbo.Specialization");
            DropForeignKey("dbo.EquipmentSpecializations", "Specialization_Id", "dbo.Specialization");
            DropForeignKey("dbo.EquipmentSpecializations", "Equipment_Id", "dbo.Equipment");
            DropForeignKey("dbo.Equipment", "EquipmentTypeId", "dbo.EquipmentType");
            DropForeignKey("dbo.Permission", "MinRankId", "dbo.Rank");
            DropForeignKey("dbo.Employee", "BarrackId", "dbo.Barrack");
            DropIndex("dbo.SpecializationPermissions", new[] { "Permission_Id" });
            DropIndex("dbo.SpecializationPermissions", new[] { "Specialization_Id" });
            DropIndex("dbo.EquipmentSpecializations", new[] { "Specialization_Id" });
            DropIndex("dbo.EquipmentSpecializations", new[] { "Equipment_Id" });
            DropIndex("dbo.Mission", new[] { "MissionTypeId" });
            DropIndex("dbo.Team", new[] { "MissionId" });
            DropIndex("dbo.Team", new[] { "TeamTypeId" });
            DropIndex("dbo.Equipment", new[] { "EquipmentTypeId" });
            DropIndex("dbo.Permission", new[] { "MinRankId" });
            DropIndex("dbo.Employee", new[] { "BarrackId" });
            DropIndex("dbo.Employee", new[] { "TeamId" });
            DropIndex("dbo.Employee", new[] { "RankId" });
            DropIndex("dbo.Employee", new[] { "SpecializationId" });
            DropTable("dbo.SpecializationPermissions");
            DropTable("dbo.EquipmentSpecializations");
            DropTable("dbo.TeamType");
            DropTable("dbo.MissionType");
            DropTable("dbo.Mission");
            DropTable("dbo.Team");
            DropTable("dbo.EquipmentType");
            DropTable("dbo.Equipment");
            DropTable("dbo.Specialization");
            DropTable("dbo.Permission");
            DropTable("dbo.Rank");
            DropTable("dbo.Employee");
            DropTable("dbo.Barrack");
        }
    }
}
