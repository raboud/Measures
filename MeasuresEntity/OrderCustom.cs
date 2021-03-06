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
    
    public partial class OrderCustom
    {
        public int Id { get; set; }
        public int OrderID { get; set; }
        public Nullable<int> SubContractorID { get; set; }
        public int EntryMethodID { get; set; }
        public string Description { get; set; }
        public Nullable<int> CustomItemNumber { get; set; }
        public decimal Quanity { get; set; }
        public Nullable<bool> SubContractorPaid { get; set; }
        public Nullable<int> UnitOfMeasureID { get; set; }
        public Nullable<bool> NotOnInvoice { get; set; }
        public Nullable<bool> NotOnWorkOrder { get; set; }
        public bool PrintOnWorkOrder { get; set; }
        public bool PrintOnInvoice { get; set; }
        public bool Deleted { get; set; }
        public bool Reviewed { get; set; }
        public string ReviewedByID { get; set; }
        public Nullable<System.DateTime> ReviewedDate { get; set; }
        public Nullable<double> SubContractorPay { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitLabor { get; set; }
        public Nullable<decimal> UnitRetail { get; set; }
        public decimal UnitMaterialCost { get; set; }
        public decimal ExtendedPrice { get; set; }
        public decimal ExtendedCost { get; set; }
    
        public virtual Employee ReviewedBy { get; set; }
        public virtual EntryMethod EntryMethod { get; set; }
        public virtual SubContractor SubContractor { get; set; }
        public virtual UnitOfMeasure UnitOfMeasure { get; set; }
    }
}
