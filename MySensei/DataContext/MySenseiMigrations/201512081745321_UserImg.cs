namespace MySensei.DataContext.MySenseiMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserImg : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "ProfilePicture", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "ProfilePicture", c => c.String(maxLength: 255));
        }
    }
}
