using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using RandREng.MeasureDBEntity;


namespace MeasuresMVC.Models
{
	public class CreateMeasureModel
	{
		public Customer customer { get; set; }
		public Measure measure { get; set; }
	}
	public class MeasureModel
	{
		public int MeasureId { get; set; }
		public int CustomerId { get; set; }
		public Customer customer { get; set; }
		public Measure measure { get; set; }

		public ICollection<RoomModel> Rooms { get; set; }
		public IEnumerable<SelectListItem> MaterialList { get; set; }

	}
	public class RoomModel
	{
		public int RoomId { get; set; }
		public string Name { get; set; }
		public int? MaterialId { get; set; }

	}

	public class Lookup
	{
		public int id { get; set; }
		public string text { get; set; }
		public Lookup(int i, string t)
		{
			this.id = i;
			this.text = t;
		}
	}

	public class MaterilaWidth
	{
		int MaterialTypeId {get;set;}
		public int Id { get; set; }
		public string Text { get; set; }
		public MaterilaWidth(int mti, int i, string t)
		{
			this.MaterialTypeId = mti;
			this.Id = i;
			this.Text = t;
		}
	}
	public class AddMaterialModel
	{
		public AddMaterialModel()
		{
			this.Material = new MaterialModel();
		}

		public Customer customer { get; set; }
		public int MeasureId { get; set; }
		public AddMaterialModel.MaterialModel Material { get; set; }

		public List<Lookup> MaterialTypeList { get; set; }
		public List<Width> WidthList { get; set; }

		public class MaterialModel
		{
			[Required]
			public string Description { get; set; }
			[Required]
			public int? MaterialTypeId { get; set; }
			public int? WidthId { get; set; }
			public int? AltWidthId { get; set; }
		}

	}

}