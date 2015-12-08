namespace MySensei.DataContext.MySenseiMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageDB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Picture", c => c.Binary());
            AlterColumn("dbo.Users", "ProfilePicture", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "ProfilePicture", c => c.String(maxLength: 255));
            AlterColumn("dbo.Courses", "Picture", c => c.String(maxLength: 255));
        }
    }
}
