using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandREng.MeasureDBEntity
{
	[MetadataType(typeof(Branch.MetaData))]
	public partial class Branch
    {
		public override string ToString()
		{
			return this.Name;
		}

		public string toLower()
		{
			return this.Name.ToLower();
		}
		public class MetaData
		{
			[Display(Name = "Branch Name", Prompt = "Branch Name")]
			public string Name;

			[Display(Name = "Printer Name", Prompt = "Printer Name")]
			public string PrinterName;
			[Display(Name = "Printer Port", Prompt = "Printer Port")]
			public string PrinterPort;
			[Display(Name = "Printer Driver", Prompt = "Printer Driver")]
			public string PrinterDriver;

		}
    }
}
