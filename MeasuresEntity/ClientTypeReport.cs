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
    
    public partial class ClientTypeReport
    {
        public int Id { get; set; }
        public int ReportTypeID { get; set; }
        public int ClientTypeID { get; set; }
        public string Location { get; set; }
    
        public virtual StoreType StoreType { get; set; }
        public virtual ReportType ReportType { get; set; }
    }
}