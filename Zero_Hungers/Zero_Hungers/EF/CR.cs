//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zero_Hungers.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class CR
    {
        public int CRID { get; set; }
        public string Iteam { get; set; }
        public string CreationTime { get; set; }
        public string ExpireTime { get; set; }
        public int RestaurantID { get; set; }
        public string Status { get; set; }
        public Nullable<int> EmployeeID { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
