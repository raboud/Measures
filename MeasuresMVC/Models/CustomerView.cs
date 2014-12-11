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
	public class CustomerView
	{
		public Customer Customer { get; set; }
		public List<Measure> Measures { get; set; }
	}

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
		public bool IncludeCloset { get; set; }
		[Display(Name = "Include Closet", Prompt = "Include Closet in calculations.", Description = "Include Closet in calculations.")]
		public bool ShowCloset { get; set; }

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
	public class AddMaterialModel : MaterialModel
	{
		public AddMaterialModel()
		{
		}

		public Customer customer { get; set; }
		public int MeasureId { get; set; }
	}

	public class EditMaterialModel : MaterialModel
	{
		public EditMaterialModel()
		{
		}

		public int MeasureMaterialId { get; set; }
		public int MeasureId { get; set; }

	}

	public class MaterialModel
	{
		public	MaterialModel()
		{
		}

		public List<Lookup> MaterialTypeList { get; set; }
		public List<Width> WidthList { get; set; }
		[Required]
		public string Description { get; set; }
		[Display(Name = "Material Type", Prompt = "Select Material Type", Description = "Material Type")]
		[Required]
		public int? MaterialTypeId { get; set; }
		[Display(Name = "Material Width", Prompt = "Select Material Width", Description = "Material Width")]
		public int? WidthId { get; set; }
		[Display(Name = "Alternate Material Width", Prompt = "Select Alternate Material Width", Description = "Alternate Material Width")]
		public int? AltWidthId { get; set; }
		[Display(Name = "Pattern Match Width", Prompt = "Enter Pattern Match Width in inches", Description = "Pattern Match Width(inches)")]
		[DisplayFormat(DataFormatString = "{0:F3}")]
		public decimal? PatternWidth { get; set; }
		[Display(Name = "Pattern Match Length", Prompt = "Enter Pattern Match Length in inches", Description = "Pattern Match Length(inches)")]
		[DisplayFormat(DataFormatString = "{0:F3}")]
		public decimal? PatternLength { get; set; }

	}

}