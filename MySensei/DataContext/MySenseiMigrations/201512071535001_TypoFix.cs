namespace MySensei.DataContext.MySenseiMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TypoFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Title", c => c.String(maxLength: 255));
            DropColumn("dbo.Courses", "Titlte");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Titlte", c => c.String(maxLength: 255));
            DropColumn("dbo.Courses", "Title");
        }
    }
}
