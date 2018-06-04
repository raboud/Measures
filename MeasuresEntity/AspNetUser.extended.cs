using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandREng.MeasureDBEntity
{
	public partial class AspNetUser
	{
		public string Name
		{
			get
			{
				return this.LastName + ", " + this.FirstName;
			}
		}
	}
}
