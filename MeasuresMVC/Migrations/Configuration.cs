namespace MeasuresMVC.Migrations
{
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;
	using MeasuresMVC.Models;
	using Microsoft.AspNet.Identity;
	using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<MeasuresMVC.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MeasuresMVC.Models.ApplicationDbContext";
        }

        protected override void Seed(MeasuresMVC.Models.ApplicationDbContext context)
        {
			var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
			var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

			// Create Admin Role
		
			IdentityResult roleResult;

			roleResult = CreateRole(RoleManager, "Admin");
			roleResult = CreateRole(RoleManager, "Store");
			roleResult = CreateRole(RoleManager, "Tech");
			roleResult = CreateRole(RoleManager, "Employee");
		}

		IdentityResult CreateRole(RoleManager<IdentityRole> roleManager, string roleName)
		{
			IdentityResult roleResult = null;

			// Check to see if Role Exists, if not create it
			if (!roleManager.RoleExists(roleName))
			{
				roleResult = roleManager.Create(new IdentityRole(roleName));
			}

			return roleResult;
		}
    }
}
