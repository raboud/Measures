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
    
    public partial class Check
    {
        public Check()
        {
            this.CheckCBDetails = new HashSet<CheckCBDetail>();
            this.CheckDetails = new HashSet<CheckDetail>();
        }
    
        public int Id { get; set; }
        public string Number { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public int VendorID { get; set; }
        public string QBTxnId { get; set; }
    
        public virtual ICollection<CheckCBDetail> CheckCBDetails { get; set; }
        public virtual ICollection<CheckDetail> CheckDetails { get; set; }
    }
}
