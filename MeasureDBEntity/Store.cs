//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RandREng.MeasureDBEntity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Store
    {
        public Store()
        {
            this.Techs = new HashSet<Tech>();
            this.ItemCostings = new HashSet<ItemCosting>();
            this.ItemMatCostings = new HashSet<ItemMatCosting>();
            this.ItemPricings = new HashSet<ItemPricing>();
            this.OptionRetails = new HashSet<OptionRetail>();
        }
    
        public int Id { get; set; }
        public int TypeID { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string StorePhoneNumber { get; set; }
        public string DirectPhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Notes { get; set; }
        public int BranchId { get; set; }
        public bool Active { get; set; }
        public Nullable<double> Latitude { get; set; }
        public Nullable<double> Longitude { get; set; }
        public Nullable<short> DistrictNumber { get; set; }
        public bool IncludeInStatusReportAll { get; set; }
        public string Address { get; set; }
        public string NickName { get; set; }
    
        public virtual Branch Branch { get; set; }
        public virtual StoreType StoreType { get; set; }
        public virtual ICollection<Tech> Techs { get; set; }
        public virtual ICollection<ItemCosting> ItemCostings { get; set; }
        public virtual ICollection<ItemMatCosting> ItemMatCostings { get; set; }
        public virtual ICollection<ItemPricing> ItemPricings { get; set; }
        public virtual ICollection<OptionRetail> OptionRetails { get; set; }
    }
}
