namespace MySensei.DataContext.IdentityMigrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MySensei.DataContext.IdentityDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContext\IdentityMigrations";
        }

        protected override void Seed(MySensei.DataContext.IdentityDb context)
        {
            IdentityRole roleAdmin = new IdentityRole("Admin");
            IdentityRole roleUser = new IdentityRole("User");
            context.Roles.AddOrUpdate(x => x.Name, roleAdmin);
            context.Roles.AddOrUpdate(x => x.Name, roleUser);

            if (!(context.Users.Any(u => u.UserName == "Administrator")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "Administrator" };
                userManager.Create(userToInsert, "!Admin12");
                userManager.AddToRole(userToInsert.Id, "Admin");
                var msdb = new MySenseiDb();
                msdb.Users.Add(new Entities.User()
                {
                    AspNetUserId = userToInsert.Id,
                    Fullname = "Admin",
                    UserName = userToInsert.UserName
                });
                msdb.SaveChanges();
            }

        }
    }
}
