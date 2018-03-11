namespace HelloWorld2.Migrations
{
    using HelloWorld2.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HelloWorld2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HelloWorld2.Models.ApplicationDbContext context)
        {
            //
            // Create admin role
            if (!context.Roles.Any(r => r.Name == "admin"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                roleManager.Create(new IdentityRole { Name = "admin" });
            }

            //
            // Create epavon@helloworld.com user
            if (!context.Users.Any(u => u.Email == "epavon@helloworld.com"))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = "epavon@helloworld.com", Email = "epavon@helloworld.com", EmailConfirmed = true };
                userManager.Create(user, "Password_96");
                userManager.AddToRole(user.Id, "admin");
            }
        }
    }
}
