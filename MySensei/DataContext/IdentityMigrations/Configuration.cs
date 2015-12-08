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
            context.Roles.Add(roleAdmin);
            context.Roles.Add(roleUser);
            
            if (!(context.Users.Any(u => u.UserName == "Administrator")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var passwordHash = new PasswordHasher();
                string password = passwordHash.HashPassword("!Admin12");
                var userToInsert = new ApplicationUser { UserName = "Administrator", PasswordHash = password };
                userManager.Create(userToInsert, "Password@123");
                userManager.AddToRole(userToInsert.Id, "Admin");
            }
        }
    }
}
