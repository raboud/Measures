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
            this.MeasureRooms = new HashSet<MeasureRoom>();
        }
    
        public int Id { get; set; }
        public int MaterialTypeId { get; set; }
        public int MeasureId { get; set; }
        public int WidthId { get; set; }
        public int AltWidthId { get; set; }
    
        public virtual MaterialType MaterialType { get; set; }
        public virtual Width AltWidth { get; set; }
        public virtual Width Width { get; set; }
        public virtual ICollection<MeasureRoom> MeasureRooms { get; set; }
    }
}
