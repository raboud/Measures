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
			[Display(Name = "Last Name", Prompt = "Enter Last Name", Description="Customer Last Name")]
			[StringLength(50)]
			public string LastName;

			[Display(Name = "First Name", Prompt = "Enter First Name", Description="Customer First Name")]
			[StringLength(50)]
			public string FirstName;

			[DataType(DataType.EmailAddress)]
			public string EmailAddress;

		}
	}

}