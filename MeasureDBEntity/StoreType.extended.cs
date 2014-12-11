using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using RandREng.Types;

namespace RandREng.MeasureDBEntity
{

	[MetadataType(typeof(StoreType.MetaData))]
	public partial class StoreType
	{
		public class MetaData
		{
			[Display(Name = "Store Type", Prompt = "Store Type")]
			public string StoreTypeName;
			[Display(Name = "Logo file name", Prompt = "Logo file name")]
			public string ImageName;
			public byte[] Logo;
			[Display(Name = "Quickbooks Classification", Prompt = "Quickbooks Classification")]
			public string QBClass;
		}
	}
}
