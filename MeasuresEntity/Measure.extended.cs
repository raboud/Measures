using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandREng.MeasureDBEntity
{
	[MetadataType(typeof(Measure.MetaData))]
	public partial class Measure
	{
		public class MetaData
		{
			public int Id;

			public int CustomerId;

			public System.DateTime Enterred;
			
			[Display(Name = "Store", Prompt = "Select Store", Description = "Store")]
			[Required]
			public int StoreId;
			
			public string EnterredById;

			[Display(Name = "Special Instructions", Prompt = "Enter any Special Instructions", Description = "Special Instructions")]
			public string SpecialInstructions;
			
			public bool Deleted;
			
			public Status Status;
		}
	}
}
