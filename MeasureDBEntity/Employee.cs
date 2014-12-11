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
    
    public partial class Employee
    {
        public Employee()
        {
            this.Branches = new HashSet<Branch>();
        }
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string SSN { get; set; }
        public string Email { get; set; }
        public string SMTPEmail { get; set; }
        public bool ReceiveCallNotes { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
    
        public virtual ICollection<Branch> Branches { get; set; }
    }
}
