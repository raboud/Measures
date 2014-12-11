using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MeasuresMVC.Models
{
	[MetadataType(typeof(Customer.MetaData))]
	public partial class Customer
	{
		public class MetaData
		{
            [Display(Name = "First Name*", Prompt = "Enter First Name", Description = "Customer First Name")]
            [StringLength(20)]
            [Required]
            public string FirstName;

			[Display(Name = "Last Name*", Prompt = "Enter Last Name", Description="Customer Last Name")]
			[StringLength(20)]
            [Required]
			public string LastName;

			[DataType(DataType.EmailAddress)]
            [Display(Name = "Email Address*", Prompt = "Enter Customer Email Address", Description = "Customer Email")]
            [Required]
			public string EmailAddress;

            [Display(Name = "Address*", Prompt = "Enter Customer Address", Description = "Customer Address Line 1")]
            [StringLength(50)]
            [Required]
            public string Address;

            [Display(Name = "Address Additional", Prompt = "Enter Customer Address", Description = "Customer Address Line 2")]
            [StringLength(50)]
            public string Address2;

            [Display(Name = "City*", Prompt = "Enter City", Description = "Customer City")]
            [StringLength(30)]
            [Required]
            public string City;

            [Display(Name = "State*", Prompt = "Enter State", Description = "Customer State")]
            [StringLength(2)]
            [Required]
            public string State;

            [Display(Name = "Zip Code*", Prompt = "Enter Zip Code", Description = "Customer Zip Code")]
            [StringLength(5)]
            [Required]
            public string ZipCode;

            [Display(Name = "Home Number", Prompt = "Enter Home Phone Number", Description = "Customer Home Phone")]
            [StringLength(10)]
            public string PhoneNumber;

            [Display(Name = "Mobile Number", Prompt = "Enter Mobile Phone Number", Description = "Customer Mobile Phone")]
            [StringLength(10)]
            public string MobileNumber;

            [Display(Name = "Work Number", Prompt = "Enter Work Number", Description = "Customer Work Number")]
            [StringLength(10)]
            public string WorkNumber;


		}
	}

}