using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeasuresMVC.Models
{
	public class Edit2ViewModels
	{
		public int Id { get; set; }
		public string Name {get;set;}
		public string HomeNumber {get;set;}
		public string MobileNumber {get;set;}
		public string EmailAddress {get;set;}
		//public int AM0 { get; set; }
		//public int AM1 { get; set; }

		public int[] Morning { get; set; }
		public int[] Afternoon { get; set; }
		public int[] Evening { get; set; }
		public Edit2ViewModels()
		{
			this.Morning = new int[7];
			this.Afternoon = new int[7];
			this.Evening = new int[7];
		}

		public Edit2ViewModels(Tech tech)
		{
			this.Name = tech.Name;
			this.Id = tech.Id;
			this.HomeNumber = tech.HomeNumber;
			this.MobileNumber = tech.MobileNumber;
			this.EmailAddress = tech.EmailAddress;

			this.Morning = new int[7];
			this.Afternoon = new int[7];
			this.Evening = new int[7];
			foreach (TechCapacity c in tech.Capacities)
			{
				int row = 0;

				switch (c.SlotType.Name)
				{
					case "Morning":
						//if (c.DayOfWeek == 0)
						//{
						//	AM0 = c.Capacity;
						//}
						//if (c.DayOfWeek == 1)
						//{
						//	AM1 = c.Capacity;
						//}
						this.Morning[c.DayOfWeek] = c.Capacity;
						break;
					case "Afternoon":
						this.Afternoon[c.DayOfWeek] = c.Capacity;
						break;
					case "Evening":
						this.Evening[c.DayOfWeek] = c.Capacity;
						break;
				}
			}
		}
	}
}