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
    
    public partial class OrderOption
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int OptionId { get; set; }
        public Nullable<int> SubContractorId { get; set; }
        public int EntryMethodId { get; set; }
        public Nullable<int> ServiceLineNumber { get; set; }
        public decimal Quantity { get; set; }
        public Nullable<bool> SubContractorPaid { get; set; }
        public bool PrintOnInvoice { get; set; }
        public bool PrintOnWO { get; set; }
        public bool Deleted { get; set; }
        public bool Reviewed { get; set; }
        public string ReviewedByID { get; set; }
        public Nullable<System.DateTime> ReviewedDate { get; set; }
        public Nullable<decimal> SubContractorPay { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitLabor { get; set; }
        public Nullable<decimal> UnitRetail { get; set; }
        public decimal UnitMaterialCost { get; set; }
        public decimal ExtendedPrice { get; set; }
        public decimal ExtendedCost { get; set; }
    
        public virtual Employee ReviewedBy { get; set; }
        public virtual EntryMethod EntryMethod { get; set; }
        public virtual Option Option { get; set; }
    }
}
