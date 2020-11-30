namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenderRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProfileModels", "ProfileGender", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProfileModels", "ProfileGender", c => c.String());
        }
    }
}
