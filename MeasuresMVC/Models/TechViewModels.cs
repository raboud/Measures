using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoMapper;
using RandREng.MeasureDBEntity;

namespace MeasuresMVC.Models
{
//	public class TechView
//	{
//		public TechView()
//		{
//		}

//		public int Id { get; set; }
//		public bool Active { get; set; }
//		public string Name { get; set; }
//		public string Address { get; set; }
//		public string City { get; set; }
//		public string State { get; set; }
//		public string ZipCode { get; set; }

//		private static IMappingExpression<Tech, TechView> GetMapping()
//		{
//			return Mapper.CreateMap<Tech, TechView>()
//				.ForMember(d => d.Id, m => m.MapFrom(s => s.Id))
//				.ForMember(d => d.Active, m => m.MapFrom(s => s.Active))
//				.ForMember(d => d.Address, m => m.MapFrom(s => s.Address))
//				.ForMember(d => d.Name, m => m.MapFrom(s => s.Name))
//				.ForMember(d => d.City, m => m.MapFrom(s => s.City))
//				.ForMember(d => d.State, m => m.MapFrom(s => s.State))
//				.ForMember(d => d.ZipCode, m => m.MapFrom(s => s.ZipCode));
//		}
//	}

	public class TechDetail
	{
		public TechDetail(MeasureEntities db, int id)
		{
			this._inner = db.Teches.Find(id);
			this._modifiedBy = db.GetUser(this._inner.LastModifiedById);
		}

		internal RandREng.MeasureDBEntity.Tech _inner { get; set; }

		internal AspNetUser _modifiedBy { get; set; }

		public int Id { get { return this._inner.Id; } }
		public string FirstName { get { return this._inner.FirstName; } }
		public string LastName { get { return this._inner.LastName; } }
		public string Address { get { return this._inner.Address; } }

		[Display(Name = "Address Additional", Prompt = "Enter Customer Address", Description = "Address Line 2")]
		[StringLength(50)]
		public string Address2 { get { return this._inner.Address2 != null ? this._inner.Address2 : ""; } }
		public string City { get { return this._inner.City; } }
		public string State { get { return this._inner.State; } }
		public string ZipCode { get { return this._inner.ZipCode; } }
		public Nullable<double> Latitude { get { return this._inner.Latitude; } }
		public Nullable<double> Longitude { get { return this._inner.Longitude; } }
		public string PhoneNumber1 { get { return this._inner.PhoneNumber1; } }
		public string PhoneNumber2 { get { return this._inner.PhoneNumber2; } }
		public string EmailAddress { get { return this._inner.EmailAddress; } }
		public string LastModifiedById { get { return this._inner.LastModifiedById; } }
		public System.DateTime LastModifiedDateTime { get { return this._inner.LastModifiedDateTime; } }
		public string Name { get { return this._inner.Name; } }
		public string ModifiedBy { get { return this._modifiedBy.Name; } }

	}

	public class Edit2ViewModels
	{
		public int Id { get; set; }
		public string Name {get;set;}
		public string PhoneNumber1 {get;set;}
		public string PhoneNumber2 {get;set;}
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

		public Edit2ViewModels(RandREng.MeasureDBEntity.Tech tech)
		{
			this.Name = tech.Name;
			this.Id = tech.Id;
			this.PhoneNumber1 = tech.PhoneNumber1;
			this.PhoneNumber2 = tech.PhoneNumber2;
			this.EmailAddress = tech.EmailAddress;

			this.Morning = new int[7];
			this.Afternoon = new int[7];
			this.Evening = new int[7];
			foreach (TechCapacity c in tech.Capacities)
			{
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