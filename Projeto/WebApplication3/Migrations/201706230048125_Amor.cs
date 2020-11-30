namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Amor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProfileModels", "ProfileModel_ProfileId", "dbo.ProfileModels");
            DropIndex("dbo.ProfileModels", new[] { "ProfileModel_ProfileId" });
            CreateTable(
                "dbo.ProfileModelProfileModels",
                c => new
                    {
                        ProfileModel_ProfileId = c.Guid(nullable: false),
                        ProfileModel_ProfileId1 = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProfileModel_ProfileId, t.ProfileModel_ProfileId1 })
                .ForeignKey("dbo.ProfileModels", t => t.ProfileModel_ProfileId)
                .ForeignKey("dbo.ProfileModels", t => t.ProfileModel_ProfileId1)
                .Index(t => t.ProfileModel_ProfileId)
                .Index(t => t.ProfileModel_ProfileId1);
            
            DropColumn("dbo.ProfileModels", "ProfileModel_ProfileId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProfileModels", "ProfileModel_ProfileId", c => c.Guid());
            DropForeignKey("dbo.ProfileModelProfileModels", "ProfileModel_ProfileId1", "dbo.ProfileModels");
            DropForeignKey("dbo.ProfileModelProfileModels", "ProfileModel_ProfileId", "dbo.ProfileModels");
            DropIndex("dbo.ProfileModelProfileModels", new[] { "ProfileModel_ProfileId1" });
            DropIndex("dbo.ProfileModelProfileModels", new[] { "ProfileModel_ProfileId" });
            DropTable("dbo.ProfileModelProfileModels");
            CreateIndex("dbo.ProfileModels", "ProfileModel_ProfileId");
            AddForeignKey("dbo.ProfileModels", "ProfileModel_ProfileId", "dbo.ProfileModels", "ProfileId");
        }
    }
}
