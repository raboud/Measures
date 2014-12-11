using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandREng.MeasureDBEntity
{
	public interface IStoreView
	{
		string BranchName { get; }
		bool Active { get; set; }
		int Id { get; set; }
		string BillingAddress { get; set; }
		string Number { get; set; }
		string City { get; set; }
		string State { get; set; }
		string ZipCode { get; set; }
		Nullable<short> DistrictNumber { get; set; }
	}
	public partial class Store : IStoreView
	{
		public string BranchName { get { return this.Branch.Name; } }
	}
}
