using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using RandREng.Types;

namespace RandREng.MeasureDBEntity
{

	[MetadataType(typeof(Store.MetaData))]
	public partial class Store
	{
		public string BranchName { get { return this.Branch.Name; } }

		public class MetaData
		{

			public int Id;

			[Display(Name = "Type")]
			[Required]
			public int TypeID;

			public string Number { get; set; }

			[Display(Name = "Address", Prompt = "Enter Customer Address", Description = "Address Line 1")]
			[StringLength(50)]
			[Required]

			public string Address;
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
			public string ZipCode;

			[Display(Name = "Store Main Number", Prompt = "Enter Store Main Phone Number", Description = "Main Store Phone Number")]
			[PhoneNumber10]
			public string StorePhoneNumber;

			[Display(Name = "Flooring Direct Number", Prompt = "Enter Flooirng Dept. Phone Number", Description = "Flooring Dept. Phone Phone")]
			[PhoneNumber10]
			public string DirectPhoneNumber;

			[Display(Name = "Fax Number", Prompt = "Enter Fax Number", Description = "Fax Phone")]
			[PhoneNumber10]
			public string FaxNumber;

			public string Notes;

			[Display(Name = "Branch")]
			[Required]
			public int BranchId;

			public bool Active;
			[Display(Name = "Nickname", Prompt = "Nickname")]
			public string NickName;
			public Nullable<double> Latitude;
			public Nullable<double> Longitude;
			public Nullable<short> DistrictNumber;
			[Display(Name = "Send Status Report", Prompt = "Send Status Report", Description = "Sent email the store bi-weekly status reports.")]
			public bool IncludeInStatusReportAll;
		}
	}
}
