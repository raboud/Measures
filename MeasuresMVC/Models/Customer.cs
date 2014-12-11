//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MeasuresMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer
    {
        public Customer()
        {
            this.Measures = new HashSet<Measure>();
        }
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public Nullable<double> Latitude { get; set; }
        public Nullable<double> Longitude { get; set; }
        public string Directions { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string WorkNumber { get; set; }
        public string Extension { get; set; }
        public string EmailAddress { get; set; }
        public System.DateTime LastModifiedDateTime { get; set; }
        public string Name { get; set; }
        public string LastModifiedById { get; set; }
    
        public virtual ICollection<Measure> Measures { get; set; }
        public virtual AspNetUser LastModifiedBy { get; set; }
    }
}
