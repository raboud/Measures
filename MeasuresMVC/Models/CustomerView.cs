using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MeasuresMVC.Models.Repositories;
using RandREng.MeasureDBEntity;

namespace MeasuresMVC.Models
{
	public class CustomerView
	{
		public CustomerView()
		{
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string ZipCode { get; set; }

		private static IMappingExpression<Customer, CustomerView> MapStores()
		{
			return Mapper.CreateMap<Customer, CustomerView>()
				.ForMember(d => d.Id, m => m.MapFrom(s => s.Id))
				.ForMember(d => d.Address, m => m.MapFrom(s => s.Address))
				.ForMember(d => d.Name, m => m.MapFrom(s => s.Name))
				.ForMember(d => d.City, m => m.MapFrom(s => s.City))
				.ForMember(d => d.State, m => m.MapFrom(s => s.State))
				.ForMember(d => d.ZipCode, m => m.MapFrom(s => s.ZipCode));
		}

		public static ItemRepository<CustomerView> GetRepository()
		{
			MapStores();

			IEnumerable<CustomerView> products;
			string sessionKey = RepositoryFactory.GetSessionKey(typeof(CustomerView));
			var session = HttpContext.Current.Session[sessionKey];

			if (session != null)
			{
				products = session as IEnumerable<CustomerView>;
			}
			else
			{
				products = Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerView>>(
					new MeasureEntities().Customers.AsEnumerable());
			}
			return new ItemRepository<CustomerView>(products, sessionKey);
		}
	}
}