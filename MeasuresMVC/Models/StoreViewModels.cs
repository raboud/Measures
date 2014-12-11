//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Web;
//using AutoMapper;
//using MeasuresMVC.Models.Repositories;
//using RandREng.MeasureDBEntity;

//namespace MeasuresMVC.Models
//{
//	public class StoreView
//	{
//		public StoreView()
//		{
//		}

//		public string Branch { get; set; }
//		public bool Active { get; set; }
//		public int Id { get; set; }
//		public string Address { get; set; }
//		public string Number { get; set; }
//		public string City { get; set; }
//		public string State { get; set; }
//		public string ZipCode { get; set; }
//		public short District { get; set; }

//		private static IMappingExpression<Store, StoreView> MapStores()
//		{
//			return Mapper.CreateMap<Store, StoreView>()
//				.ForMember(d => d.Id, m => m.MapFrom(s => s.Id))
//				.ForMember(d => d.Active, m => m.MapFrom(s => s.Active))
//				.ForMember(d => d.Address, m => m.MapFrom(s => s.BillingAddress))
//				.ForMember(d => d.Branch, m => m.MapFrom(s => s.Branch.Name))
//				.ForMember(d => d.City, m => m.MapFrom(s => s.City))
//				.ForMember(d => d.Number, m => m.MapFrom(s => s.Number))
//				.ForMember(d => d.State, m => m.MapFrom(s => s.State))
//				.ForMember(d => d.ZipCode, m => m.MapFrom(s => s.ZipCode))
//				.ForMember(d => d.District, m => m.MapFrom(s => s.DistrictNumber));

//		}

//		public static ItemRepository<StoreView> GetRepository()
//		{
//			MapStores();

//			IEnumerable<StoreView> products;
//			string sessionKey = RepositoryFactory.GetSessionKey(typeof(StoreView));
//			var session = HttpContext.Current.Session[sessionKey];

//			if (session != null)
//			{
//				products = session as IEnumerable<StoreView>;
//			}
//			else
//			{
//				products = Mapper.Map<IEnumerable<Store>, IEnumerable<StoreView>>(
//					new MeasureEntities().Stores.AsEnumerable());
//			}
//			return new ItemRepository<StoreView>(products, sessionKey);
//		}
//	}
//}