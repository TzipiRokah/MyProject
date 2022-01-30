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
    
    public partial class Queues
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Queues()
        {
            this.QueuePerUser = new HashSet<QueuePerUser>();
        }
    
        public int QueueId { get; set; }
        public int AttractionId { get; set; }
        public System.DateTime Hour { get; set; }
        public Nullable<int> MaxPeopleInAttraction { get; set; }
        public Nullable<int> QueueStatus { get; set; }
    
        public virtual Attraction Attraction { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QueuePerUser> QueuePerUser { get; set; }
    }
}
