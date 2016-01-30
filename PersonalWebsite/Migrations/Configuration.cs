using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Blog.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Blog.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Blog.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            
            if (!context.Roles.Any(r => r.Name == "Admin"))// OR use this: (roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" }); 
            }
            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                roleManager.Create(new IdentityRole { Name = "Moderator" });
            }

            var uStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(uStore);
            
            if (userManager.FindByEmail("a.schechter@outlook.com") == null)
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "a.schechter@outlook.com",
                    Email = "a.schechter@outlook.com",
                    FirstName = "Alex",
                    LastName = "Schechter"
                }, "Password - 1");
            }

            var userId = userManager.FindByEmail("a.schechter@outlook.com").Id;
            if (!userManager.IsInRole(userId, "Admin"))
            {
                userManager.AddToRole(userId, "Admin");
            };

            if (userManager.FindByEmail("bdavis@coderfoundry.com") == null)
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "bdavis@coderfoundry.com",
                    Email = "bdavis@coderfoundry.com",
                    FirstName = "Bobby",
                    LastName = "Davis"
                }, "Password - 1");
            }

            userId = userManager.FindByEmail("bdavis@coderfoundry.com").Id;
            if (!userManager.IsInRole(userId, "Moderator"))
            {
                userManager.AddToRole(userId, "Moderator");
            };

            if (userManager.FindByEmail("ajensen@coderfoundry.com") == null)
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "ajensen@coderfoundry.com",
                    Email = "ajensen@coderfoundry.com",
                    FirstName = "Andrew",
                    LastName = "Jensen"
                }, "Password - 1");
            }

            userId = userManager.FindByEmail("ajensen@coderfoundry.com").Id;
            if (!userManager.IsInRole(userId, "Moderator"))
            {
                userManager.AddToRole(userId, "Moderator");
            };

            if (userManager.FindByEmail("rmanglani@coderfoundry.com") == null)
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "rmanglani@coderfoundry.com",
                    Email = "rmanglani@coderfoundry.com",
                    FirstName = "Ria",
                    LastName = "Manglani"
                }, "Password - 1");
            }

            userId = userManager.FindByEmail("rmanglani@coderfoundry.com").Id;
            if (!userManager.IsInRole(userId, "Moderator"))
            {
                userManager.AddToRole(userId, "Moderator");
            };


            if (userManager.FindByEmail("tjones@coderfoundry.com") == null)
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "tjones@coderfoundry.com",
                    Email = "tjones@coderfoundry.com",
                    FirstName = "TJ",
                    LastName = "Jones"
                }, "Password - 1");
            }

            userId = userManager.FindByEmail("tjones@coderfoundry.com").Id;
            if (!userManager.IsInRole(userId, "Moderator"))
            {
                userManager.AddToRole(userId, "Moderator");
            };

        }
    }
}