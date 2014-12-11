using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandREng.MeasureDBEntity
{
	[MetadataType(typeof(MeasureMaterial.MetaData))]
	public partial class MeasureMaterial
	{
		public class MetaData
		{
			public int Id;
			public int MaterialTypeId;
			public int MeasureId;
			public Nullable<int> WidthId;
			public Nullable<int> AltWidthId;
			public string Description;

			[Display(Name = "Pattern Match Width", Prompt = "Enter Pattern Match Width in inches", Description = "Pattern Match Width(inches)")]
			[DisplayFormat(DataFormatString = "{0:F3}")]
			public Nullable<decimal> PatternMatchWidth;

			[Display(Name = "Pattern Match Length", Prompt = "Enter Pattern Match Length in inches", Description = "Pattern Match Length(inches)")]
			[DisplayFormat(DataFormatString = "{0:F3}")]
			public Nullable<decimal> PatternMatchLength;

		}
	}
}
