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
    
    public partial class SubContractor
    {
        public SubContractor()
        {
            this.OrderCustoms = new HashSet<OrderCustom>();
        }
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string HomePhoneNumber { get; set; }
        public string CellPhoneNumber { get; set; }
        public string Pager { get; set; }
        public string SSN { get; set; }
        public Nullable<bool> WorkmansCompInsuranceOK { get; set; }
        public Nullable<bool> LiabilityInsuranceOK { get; set; }
        public bool BackgroundCheckPassed { get; set; }
        public bool BackgroundRptRequested { get; set; }
        public bool Helper { get; set; }
        public string Notes { get; set; }
        public Nullable<decimal> Retainage { get; set; }
        public Nullable<double> SavingsRate { get; set; }
        public Nullable<decimal> RetainageRate { get; set; }
        public decimal InsuranceRate { get; set; }
        public decimal InsuranceDollarAmount { get; set; }
        public string BadgeStatus { get; set; }
        public Nullable<int> AssignedTo { get; set; }
        public Nullable<int> BranchId { get; set; }
        public int Status { get; set; }
        public int StateId { get; set; }
        public Nullable<System.DateTime> WorkmansCompInsuranceDate { get; set; }
        public Nullable<System.DateTime> LiabilityInsuranceDate { get; set; }
        public Nullable<System.DateTime> BackgroundChkDateApproved { get; set; }
        public string PictureFilename { get; set; }
        public string QBSubContractorId { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<OrderCustom> OrderCustoms { get; set; }
    }
}
