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
			// Create Admin Role
		
			IdentityResult roleResult;

			roleResult = ApplicationDbContext.SCreateUser(new ApplicationUser() { UserName = "store@custom-installs.com" }, "cfi12345", "Store");
			roleResult = ApplicationDbContext.SCreateUser(new ApplicationUser() { UserName = "employee@custom-installs.com" }, "cfi12345", "Employee");
			roleResult = ApplicationDbContext.SCreateUser(new ApplicationUser() { UserName = "tech@custom-installs.com"}, "cfi12345", "Tech");
			roleResult = ApplicationDbContext.SCreateUser(new ApplicationUser() { UserName = "admin@custom-installs.com" }, "cfi12345", "Admin");
		}
    }
}
