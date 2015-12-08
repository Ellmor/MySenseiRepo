namespace MySensei.DataContext.MySenseiMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStoredProcedure : DbMigration
    {
        public override void Up()
        {
            Sql(Properties.Resources.CreateStoredProcedure);
        }
        
        public override void Down()
        {
            Sql(Properties.Resources.DropStoredProcedure);
        }
    }
}
