namespace MySensei.DataContext.MySenseiMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fullname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Fullname", c => c.String(maxLength: 100));
            AlterColumn("dbo.Users", "AspNetUserId", c => c.String());
            DropColumn("dbo.Users", "FirstName");
            DropColumn("dbo.Users", "LastName");
            DropColumn("dbo.Users", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Email", c => c.String(maxLength: 100));
            AddColumn("dbo.Users", "LastName", c => c.String(maxLength: 100));
            AddColumn("dbo.Users", "FirstName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Users", "AspNetUserId", c => c.Int());
            DropColumn("dbo.Users", "Fullname");
        }
    }
}
