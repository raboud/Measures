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
    
    public partial class OptionRetail
    {
        public int Id { get; set; }
        public int LaborId { get; set; }
        public Nullable<int> BranchId { get; set; }
        public Nullable<int> StoreId { get; set; }
        public decimal Amount { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
    
        public virtual Branch Branch { get; set; }
        public virtual Store Store { get; set; }
    }
}
