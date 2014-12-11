using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RandREng.MeasureDBEntity;

namespace MeasuresMVC.Models
{
	public class AddTech
	{
		public AddTech()
		{
		}

		public string TechId { get; set; }
		public int Id { get; set; }
	}

}