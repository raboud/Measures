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
			System.Console.WriteLine("Test");
			var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

			UserManager.UserValidator = new UserValidator<ApplicationUser>(UserManager) { AllowOnlyAlphanumericUserNames = false };
//			                  new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
			var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

			// Create Admin Role
		
			IdentityResult roleResult;

			roleResult = CreateRole(RoleManager, "Admin");
			roleResult = CreateRole(RoleManager, "Store");
			roleResult = CreateRole(RoleManager, "Tech");
			roleResult = CreateRole(RoleManager, "Employee");

			roleResult = CreateUser(context, UserManager, "store@custom-installs.com", "cfi12345", "Store");
			roleResult = CreateUser(context, UserManager, "employee@custom-installs.com", "cfi12345", "Employee");
			roleResult = CreateUser(context, UserManager, "tech@custom-installs.com", "cfi12345", "Tech");
			roleResult = CreateUser(context, UserManager, "admin@custom-installs.com", "cfi12345", "Admin");
		}

		IdentityResult CreateRole(RoleManager<IdentityRole> manager, string id)
		{
			IdentityResult roleResult = null;

			// Check to see if Role Exists, if not create it
			if (!manager.RoleExists(id))
			{
				roleResult = manager.Create(new IdentityRole(id));
			}

			return roleResult;
		}

		IdentityResult CreateUser(ApplicationDbContext context, UserManager<ApplicationUser> manager, string id, string password, string role)
		{
			IdentityResult roleResult = null;

			// Check to see if Role Exists, if not create it
			ApplicationUser user = (from u in context.Users where u.UserName == id select u).FirstOrDefault();
			//try
			//{
			//	manager.FindByName(id);
			//}
			//catch (Exception)
			//{

			//}

			if (user == null)
			{
				user = new ApplicationUser() { UserName = id, Email = id, FirstName = "Test", LastName = "Test", IsConfirmed = true, Active = true };
				manager.Create(user, password);
				System.Console.WriteLine(string.Format("{0} - {1} - {2}", user.UserName, user.Id, role));
				roleResult = manager.AddToRole(user.Id, role);
			}
			else
			{
				System.Console.WriteLine(string.Format("{0} - {1} - {2}", user.UserName, user.Id, role));
				roleResult = manager.AddToRole(user.Id, role);
			}

			return roleResult;
		}
    }
}
