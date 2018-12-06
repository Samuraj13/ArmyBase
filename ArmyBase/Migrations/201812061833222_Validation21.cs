namespace ArmyBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Validation21 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Permission", "MinRankId", "dbo.Rank");
            DropIndex("dbo.Permission", new[] { "MinRankId" });
            AlterColumn("dbo.Permission", "MinRankId", c => c.Int(nullable: false));
            CreateIndex("dbo.Permission", "MinRankId");
            AddForeignKey("dbo.Permission", "MinRankId", "dbo.Rank", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Permission", "MinRankId", "dbo.Rank");
            DropIndex("dbo.Permission", new[] { "MinRankId" });
            AlterColumn("dbo.Permission", "MinRankId", c => c.Int());
            CreateIndex("dbo.Permission", "MinRankId");
            AddForeignKey("dbo.Permission", "MinRankId", "dbo.Rank", "Id");
        }
    }
}
