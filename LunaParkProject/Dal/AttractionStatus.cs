//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class AttractionStatus
    {
        public int AttractionStatusId { get; set; }
        public Nullable<int> StatusId { get; set; }
        public Nullable<int> AttractionId { get; set; }
        public Nullable<System.DateTime> AttractionStatusDateTime { get; set; }
        public Nullable<int> EmployeeReportId { get; set; }
    
        public virtual Attraction Attraction { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Status Status { get; set; }
    }
}