using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MeasuresMVC.Models
{
	[MetadataType(typeof(Tech.MetaData))]
	public partial class Tech
	{
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
			public string EmailAddress;

			[Display(Name = "Address", Prompt = "Enter Customer Address", Description = "Address Line 1")]
			[StringLength(50)]
			[Required]
			public string Address;

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

			[DataType(DataType.PostalCode)]
			[Display(Name = "Zip Code", Prompt = "Enter Zip Code", Description = "Zip Code")]
			[StringLength(5)]
			[Required]
			public string ZipCode;

			[DataType(DataType.PhoneNumber, ErrorMessage = "Home phone number not valid")]
			[Display(Name = "Home Number", Prompt = "Enter Home Phone Number", Description = "Customer Home Phone")]
			[StringLength(10)]
			public string HomeNumber;

			[DataType(DataType.PhoneNumber, ErrorMessage = "Mobile phone number not valid")]
			[Display(Name = "Mobile Number", Prompt = "Enter Mobile Phone Number", Description = "Customer Mobile Phone")]
			[StringLength(10)]
			public string MobileNumber;
		}
	}
}