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
    
    public partial class JobStatu
    {
        public JobStatu()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public int Id { get; set; }
        public string JobStatusDescription { get; set; }
    
        public virtual ICollection<Order> Orders { get; set; }
    }
}
