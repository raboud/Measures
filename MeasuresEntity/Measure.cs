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
    
    public partial class Measure
    {
        public Measure()
        {
            this.Emails = new HashSet<MeasureEmail>();
            this.Materials = new HashSet<MeasureMaterial>();
            this.Slots = new HashSet<Slot>();
        }
    
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public System.DateTime Enterred { get; set; }
        public int StoreId { get; set; }
        public string EnterredById { get; set; }
        public string SpecialInstructions { get; set; }
        public bool Deleted { get; set; }
        public Status Status { get; set; }
    
        public virtual Store Store { get; set; }
        public virtual ICollection<MeasureEmail> Emails { get; set; }
        public virtual ICollection<MeasureMaterial> Materials { get; set; }
        public virtual AspNetUser EnterredBy { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Slot> Slots { get; set; }
    }
}
