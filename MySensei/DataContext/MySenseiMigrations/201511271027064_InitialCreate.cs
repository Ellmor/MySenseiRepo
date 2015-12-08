namespace MySensei.DataContext.MySenseiMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        Titlte = c.String(maxLength: 255),
                        Description = c.String(maxLength: 255),
                        Location = c.String(maxLength: 255),
                        Picture = c.Binary(),
                        Price = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.CourseID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        FirstName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100),
                        Phone = c.String(maxLength: 50),
                        ProfilePicture = c.Binary(),
                        Description = c.String(maxLength: 255),
                        AspNetUserId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        Text = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.OfferedCourses",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.CourseId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Participation",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.CourseId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.CourseTag",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseId, t.TagId })
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.TagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseTag", "TagId", "dbo.Tags");
            DropForeignKey("dbo.CourseTag", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Participation", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Participation", "UserId", "dbo.Users");
            DropForeignKey("dbo.OfferedCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.OfferedCourses", "UserId", "dbo.Users");
            DropIndex("dbo.CourseTag", new[] { "TagId" });
            DropIndex("dbo.CourseTag", new[] { "CourseId" });
            DropIndex("dbo.Participation", new[] { "CourseId" });
            DropIndex("dbo.Participation", new[] { "UserId" });
            DropIndex("dbo.OfferedCourses", new[] { "CourseId" });
            DropIndex("dbo.OfferedCourses", new[] { "UserId" });
            DropTable("dbo.CourseTag");
            DropTable("dbo.Participation");
            DropTable("dbo.OfferedCourses");
            DropTable("dbo.Tags");
            DropTable("dbo.Users");
            DropTable("dbo.Courses");
        }
    }
}
