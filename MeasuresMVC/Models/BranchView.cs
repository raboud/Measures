using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MeasuresMVC.Models.Repositories;
using RandREng.MeasureDBEntity;

namespace MeasuresMVC.Models
{
	public class BranchView
	{
		public BranchView()
		{
		}

		public bool Active { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string ZipCode { get; set; }

		private static IMappingExpression<Branch, BranchView> MapStores()
		{
			return Mapper.CreateMap<Branch, BranchView>()
				.ForMember(d => d.Id, m => m.MapFrom(s => s.Id))
				.ForMember(d => d.Active, m => m.MapFrom(s => s.Active))
				.ForMember(d => d.Address, m => m.MapFrom(s => s.Address))
				.ForMember(d => d.Name, m => m.MapFrom(s => s.Name))
				.ForMember(d => d.City, m => m.MapFrom(s => s.City))
				.ForMember(d => d.State, m => m.MapFrom(s => s.State))
				.ForMember(d => d.ZipCode, m => m.MapFrom(s => s.ZipCode));
		}

		public static ItemRepository<BranchView> GetRepository()
		{
			MapStores();

			IEnumerable<BranchView> products;
			string sessionKey = RepositoryFactory.GetSessionKey(typeof(BranchView));
			var session = HttpContext.Current.Session[sessionKey];

			if (session != null)
			{
				products = session as IEnumerable<BranchView>;
			}
			else
			{
				products = Mapper.Map<IEnumerable<Branch>, IEnumerable<BranchView>>(
					new MeasureEntities().Branches.AsEnumerable());
			}
			return new ItemRepository<BranchView>(products, sessionKey);
		}
	}
}