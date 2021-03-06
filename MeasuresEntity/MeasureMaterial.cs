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
    
    public partial class MeasureMaterial
    {
        public MeasureMaterial()
        {
            this.Rooms = new HashSet<MeasureRoom>();
        }
    
        public int Id { get; set; }
        public int MaterialTypeId { get; set; }
        public int MeasureId { get; set; }
        public Nullable<int> WidthId { get; set; }
        public Nullable<int> AltWidthId { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> PatternMatchLength { get; set; }
        public Nullable<decimal> PatternMatchWidth { get; set; }
        public bool Deleted { get; set; }
    
        public virtual MaterialType MaterialType { get; set; }
        public virtual Width AltWidth { get; set; }
        public virtual Width Width { get; set; }
        public virtual ICollection<MeasureRoom> Rooms { get; set; }
    }
}
