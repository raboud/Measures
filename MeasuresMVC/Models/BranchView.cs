using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
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

	}
}