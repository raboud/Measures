using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using RandREng.Types;

namespace RandREng.MeasureDBEntity
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

			[Display(Name = "Company Name*", Prompt = "Enter Company Name", Description = "Customer Company Name")]
			[StringLength(50)]
			[Required]
			public string CompanyName;

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
			[PostalPlus4]
            [StringLength(10)]
            [Required]
            public string ZipCode;

            [Display(Name = "Primary Number", Prompt = "Enter Primary Phone Number", Description = "Customer Home Phone")]
            [PhoneNumber10Ext]
            public string PhoneNumber1;

            [Display(Name = "Secondary Number", Prompt = "Enter Secondary Phone Number", Description = "Customer Mobile Phone")]
			[PhoneNumber10Ext]
            public string PhoneNumber2;

            [Display(Name = "Third Number", Prompt = "Enter Tertiaryy Number", Description = "Customer Work Number")]
			[PhoneNumber10Ext]
            public string PhoneNumber3;


		}
	}

}