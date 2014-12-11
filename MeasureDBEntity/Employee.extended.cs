using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using RandREng.Types;

namespace RandREng.MeasureDBEntity
{
	[MetadataType(typeof(Employee.MetaData))]
	public partial class Employee
	{
		public string FirstName
		{
			get { return this.AspNetUser.FirstName; }
			set { this.AspNetUser.FirstName = value; }
		}
		public string LastName
		{
			get { return this.AspNetUser.LastName; ; }
			set { this.AspNetUser.LastName = value; }
		}
		public string Name
		{
			get { return this.AspNetUser.Name; }
		}

		public class MetaData
		{
			[Display(Name = "First Name", Prompt = "Enter First Name", Description = "First Name")]
			[StringLength(20)]
			[Required]
			public string FirstName;

			[Display(Name = "Last Name", Prompt = "Enter Last Name", Description = "Last Name")]
			[StringLength(20)]
			[Required]
			public string LastName;

			[DataType(DataType.EmailAddress)]
			[Display(Name = "Email Address", Prompt = "Enter Customer Email Address", Description = "Email")]
			[Required]
			public string Email;

			[Display(Name = "Address", Prompt = "Enter Customer Address", Description = "Address Line 1")]
			[StringLength(50)]
			[Required]
			public string Address1;

			[Display(Name = "Address Additional", Prompt = "Enter Customer Address", Description = "Address Line 2")]
			[StringLength(50)]
			public string Address2;

			[Display(Name = "City", Prompt = "Enter City", Description = "City")]
			[StringLength(30)]
			[Required]
			public string City;

			[Display(Name = "State", Prompt = "Enter State", Description = "State")]
			[StringLength(2)]
			[Required]
			public string State;

			[Display(Name = "Zip Code", Prompt = "Enter Zip Code", Description = "Zip Code")]
			[PostalPlus4]
			[Required]
			public string Zip;

			[Display(Name = "Home Number", Prompt = "Enter Home Phone Number", Description = "Customer Home Phone")]
			[PhoneNumber10]
			public string PhoneNumber1;

			[Display(Name = "Mobile Number", Prompt = "Enter Mobile Phone Number", Description = "Customer Mobile Phone")]
			[PhoneNumber10]
			public string PhoneNumber2;
		}
	}
}