﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeasuresMVC.Models.Repositories
{
    public class RepositoryMapping
    {
		//public AppUrlHelper PathHelper;
        #region Northwind
		public IMappingExpression<RandREng.MeasureDBEntity.Store, StoreView> MapStores()
        {
			return Mapper.CreateMap<RandREng.MeasureDBEntity.Store, StoreView>()
				.ForMember(d => d.Id, m => m.MapFrom(s => s.Id))
				.ForMember(d => d.Active, m => m.MapFrom(s => s.Active))
				.ForMember(d => d.Address, m => m.MapFrom(s => s.BillingAddress))
				.ForMember(d => d.Branch, m => m.MapFrom(s => s.Branch.Name))
				.ForMember(d => d.City, m => m.MapFrom(s => s.City))
				.ForMember(d => d.Number, m => m.MapFrom(s => s.Number))
				.ForMember(d => d.State, m => m.MapFrom(s => s.State))
				.ForMember(d => d.ZipCode, m => m.MapFrom(s => s.ZipCode));
        }

		//public IMappingExpression<CategoryEntity, Category> MapCategories(IncludeChildren includes)
		//{
		//	Mapper.Reset();

		//	var mapping = Mapper.CreateMap<CategoryEntity, Category>()
		//			.ForMember(d => d.ID, m => m.MapFrom(s => s.CategoryID))
		//			.ForMember(d => d.ProductCount, m => m.MapFrom(s => s.Products.Count))
		//			.ForMember(d => d.ImageUrl, m => m.MapFrom(s => PathHelper.FullCategoryImagePath(s.CategoryID)));

		//	if (includes == IncludeChildren.Products)
		//	{
		//		MapProducts();

		//		return mapping.ForMember(d => d.Products, m => m.MapFrom(s => s.Products));
		//	}

		//	return mapping.ForMember(d => d.Products, m => m.UseValue(new List<Product>().AsEnumerable()));
		//}

		//public IMappingExpression<EmployeeEntity, Employee> MapEmployees(IncludeChildren includeChildren)
		//{
		//	Mapper.Reset();

		//	String culture = PathHelper.Resources.Culture;
		//	String formatString = (culture == "JA") ? "{1} {0}" : "{0} {1}";
		//	var mapping = Mapper.CreateMap<EmployeeEntity, Employee>()
		//		.ForMember(d => d.ID, m => m.MapFrom(s => s.EmployeeID))
		//		.ForMember(d => d.Name, m => m.MapFrom(s => string.Format(formatString, s.FirstName, s.LastName)))
		//		.ForMember(d => d.Supervisor, m => m.MapFrom(s => string.Format(formatString,
		//			s.Employee.FirstName, s.Employee.LastName)))
		//		.ForMember(d => d.ImageUrl, m => m.MapFrom(s => PathHelper.FullEmployeeImagePath(s.EmployeeID)))
		//		.ForMember(d => d.HireDate, m => m.MapFrom(s => s.HireDate.Value.Date.ToShortDateString()))
		//		.ForMember(d => d.BirthDate, m => m.MapFrom(s => s.BirthDate.Value.Date.ToShortDateString()));

		//	if (includeChildren == IncludeChildren.Employees)
		//		mapping.ForMember(d => d.Employees, m => m.MapFrom(s => s.Employees));
		//	else
		//		mapping.ForMember(d => d.Employees, m => m.UseValue(new List<Employee>().AsEnumerable()));

		//	return mapping;
		//}

		//public IMappingExpression<CustomerEntity, Customer> MapCustomers(IncludeChildren includeChildren = new IncludeChildren())
		//{
		//	Mapper.Reset();

		//	var mapping = Mapper.CreateMap<CustomerEntity, Customer>()
		//		.ForMember(d => d.ID, m => m.MapFrom(s => s.CustomerID));

		//	if (includeChildren == IncludeChildren.Orders)
		//	{
		//		MapOrders();

		//		mapping.ForMember(d => d.Orders, m => m.MapFrom(s => s.Orders));
		//	}
		//	else
		//		mapping.ForMember(d => d.Orders, m => m.UseValue(new List<Order>().AsEnumerable()));

		//	return mapping;
		//}

		//public IMappingExpression<InvoiceEntity, Invoice> MapInvoices()
		//{
		//	return Mapper.CreateMap<InvoiceEntity, Invoice>();
		//}

		//public IMappingExpression<OrderEntity, Order> MapOrders()
		//{
		//	Func<OrderEntity, decimal> orderTotalMethod = (OrderEntity order) =>
		//	{

		//		decimal total = 0;

		//		foreach (var od in order.OrderDetails)
		//		{
		//			total = total + (od.UnitPrice * od.Quantity);
		//		}

		//		return total;
		//	};

		//	Func<OrderEntity, int> unitTotalMethod = (OrderEntity order) =>
		//	{
		//		int total = 0;

		//		foreach (var od in order.OrderDetails)
		//		{
		//			total = total + od.Quantity;
		//		}

		//		return total;
		//	};

		//	String culture = PathHelper.Resources.Culture;
		//	String formatString = (culture == "JA") ? "{1} {0}" : "{0} {1}";
		//	return Mapper.CreateMap<OrderEntity, Order>()
		//		.ForMember(d => d.ContactName, m => m.MapFrom(s => s.Customer.ContactName))
		//		.ForMember(d => d.EmployeeName, m => m.MapFrom(s => string.Format(formatString, s.Employee.FirstName, s.Employee.LastName)))
		//		.ForMember(d => d.ShipperID, m => m.MapFrom(s => s.Shipper.ShipperID))
		//		.ForMember(d => d.ShipperName, m => m.MapFrom(s => s.Shipper.CompanyName))
		//		.ForMember(d => d.TotalPrice, m => m.MapFrom(s => orderTotalMethod(s)))
		//		.ForMember(d => d.TotalItems, m => m.MapFrom(s => unitTotalMethod(s)));

		//}

        #endregion Northwind

        public RepositoryMapping()
        {
			//Config cfg = new Config();
			//FileSystemHelper fs = new FileSystemHelper(cfg);
			//ResourceStrings r = new ResourceStrings(cfg);
			//PathHelper = new AppUrlHelper(fs, r);
        }
    }
}
