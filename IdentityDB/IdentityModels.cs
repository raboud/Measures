using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RandREng.Types;

namespace RandREng.IdentityDBEntity
{
	// You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
	public class ApplicationUser : IdentityUser
	{
		public string Email { get; set; }
		public string ConfirmationToken { get; set; }
		public bool IsConfirmed { get; set; }
		public string ResetPasswordToken { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public bool Active { get; set; }

		public ApplicationUser()
		{
			this.Active = false;
			this.ConfirmationToken = CreateToken();
			this.IsConfirmed = false;
		}

		static private string CreateToken()
		{
			return ShortGuid.NewGuid();
		}

	}

	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
			: this("DefaultConnection")
		{
		}
		public ApplicationDbContext(string conn)
			: base(conn)
		{
		}

		public UserManager<ApplicationUser> GetUserManager()
		{
			UserManager<ApplicationUser> manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this));
			manager.UserValidator = new UserValidator<ApplicationUser>(manager) { AllowOnlyAlphanumericUserNames = false };
			return manager;
		}

		public RoleManager<IdentityRole> GetRoleManager()
		{
			return 	new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(this));
		}

		public static IdentityResult SCreateUser(ApplicationUser user, string password, string role)
		{
			ApplicationDbContext context = new ApplicationDbContext();
			return context.CreateUser(user, password, role);
		}
		public IdentityResult CreateUser(ApplicationUser user, string password, string role)
		{
			IdentityResult result = null;

			var UserManager = this.GetUserManager();

			// Check to see if Role Exists, if not create it
			ApplicationUser user2 = UserManager.FindByName(user.UserName);

			if (user2 == null)
			{
				UserManager.Create(user, password);
				user2 = user;
			}
			else
			{
				result = new IdentityResult(new string[] {"Already Existis"});
			}

			if (!string.IsNullOrEmpty(role))
			{
				var RoleManager = this.GetRoleManager();
				if (!RoleManager.RoleExists(role))
				{
					result = RoleManager.Create(new IdentityRole(role));
				}
				result = UserManager.AddToRole(user2.Id, role);
			}

			return result;
		}
	
	}
}