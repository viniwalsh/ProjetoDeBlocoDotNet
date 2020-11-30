namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfileBackgroundPictureAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProfileModels", "ProfileBackgroundPicture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProfileModels", "ProfileBackgroundPicture");
        }
    }
}
