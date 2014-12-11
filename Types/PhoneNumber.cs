using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RandREng.Types
{
	public class PhoneNumber10Ext : RegularExpressionAttribute
	{
		public PhoneNumber10Ext()
			: base(RegEx)
		{
			base.ErrorMessage = "Phone number in form of (123) 456-7890 [ext 12345]";
		}

		public const string RegEx = @"^\(?(\d{3})\)?[ |\-|\.]?(\d{3})[ |\-|\.]?(\d{4})(?:[\-\.\ \\\/]?(?:#|ext\.?|extension|x)[\-\.\ \\\/]?(\d+))?$";

		public static void Register()
		{
			DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(PhoneNumber10Ext), typeof(RegularExpressionAttributeAdapter));
		}


		public static string Reformat(string input)
		{
			string a = "ERROR";
			try
			{
				Regex reg = new Regex(RegEx);
				Match m = reg.Match(input);
				if (m.Groups.Count == 5 && !string.IsNullOrEmpty(m.Groups[4].Value))
				{
					a = string.Format("({0}) {1}-{2} ext {3}", m.Groups[1].Value, m.Groups[2].Value, m.Groups[3].Value, m.Groups[4].Value);
				}
				else if (m.Groups.Count == 4 || (m.Groups.Count == 5 && string.IsNullOrEmpty(m.Groups[4].Value)))
				{
					a = string.Format("({0}) {1}-{2}", m.Groups[1].Value, m.Groups[2].Value, m.Groups[3].Value);
				}
			}
			catch ( Exception)
			{

			}

			return a;
		}

	}

	public class PhoneNumber10 : RegularExpressionAttribute
	{
		public PhoneNumber10()
			: base(RegEx)
		{
			base.ErrorMessage = "Phone number in form of (123) 456-7890";
		}

		public const string RegEx = @"^\(?(\d{3})\)?[ |-|\.]?(\d{3})[ |-|\.]?(\d{4})$";

		//		public const string ErrorMessage = "Zip Code is invalid.";
		public static void Register()
		{
			DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(PhoneNumber10), typeof(RegularExpressionAttributeAdapter));
		}

		public override bool IsValid(object value)
		{
			return base.IsValid(value);
		}

		public static string Reformat(string input)
		{
			string a = "ERROR";
			try
			{
				Regex reg = new Regex(RegEx);
				Match m = reg.Match(input);
				if (m.Groups.Count == 4)
				{
					a = string.Format("({0}) {1}-{2}", m.Groups[1].Value, m.Groups[2].Value, m.Groups[3].Value);
				}
			}
			catch (Exception)
			{

			}

			return a;
		}
	}
}
