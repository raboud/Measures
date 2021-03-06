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
    
    public partial class Tech
    {
        public Tech()
        {
            this.Capacities = new HashSet<TechCapacity>();
            this.Stores = new HashSet<Store>();
        }
    
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public Nullable<double> Latitude { get; set; }
        public Nullable<double> Longitude { get; set; }
        public string EmailAddress { get; set; }
        public string LastModifiedById { get; set; }
        public System.DateTime LastModifiedDateTime { get; set; }
        public string UserId { get; set; }
        public bool Active { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
    
        public virtual AspNetUser User { get; set; }
        public virtual AspNetUser LastModifiedBy { get; set; }
        public virtual ICollection<TechCapacity> Capacities { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
    }
}
