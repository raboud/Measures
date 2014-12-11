using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RandREng.Types
{
	public class PostalPlus4 : RegularExpressionAttribute
	{
		public PostalPlus4()
			: base(RegEx)
		{
			base.ErrorMessage = "Zip Code is invalid.";
		}

		public const string RegEx = @"^\d{5}(-\d{4})?$";

//		public const string ErrorMessage = "Zip Code is invalid.";
		public static void Register()
		{
			DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(PostalPlus4), typeof(RegularExpressionAttributeAdapter));
		}
	}
}
