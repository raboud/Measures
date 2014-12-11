using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandREng.MeasureDBEntity
{
	public partial class MeasureEntities
	{
		public MeasureEntities(string connection)
			: base(connection)
		{
		}

		public AspNetUser GetUser(string userId)
		{
			return this.AspNetUsers.Find(userId);
		}
	}
}
