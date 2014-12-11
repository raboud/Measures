using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using RandREng.MeasureDBEntity;


namespace MeasuresMVC.Models
{
	public class CreateMeasureModel
	{
		public Customer customer { get; set; }
		public Measure measure { get; set; }
	}
}