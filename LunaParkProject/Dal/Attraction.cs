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
    
    public partial class Attraction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Attraction()
        {
            this.AttractionStatus = new HashSet<AttractionStatus>();
            this.FavoriteAttraction = new HashSet<FavoriteAttraction>();
            this.Message = new HashSet<Message>();
            this.Queues = new HashSet<Queues>();
            this.Rate = new HashSet<Rate>();
        }
    
        public int AttractionId { get; set; }
        public string AttractionName { get; set; }
        public Nullable<int> AttractionIfActive { get; set; }
        public int AttractionMaxPeople { get; set; }
        public Nullable<int> AttractionNowPeople { get; set; }
        public int AttractionCountQueue { get; set; }
        public int AttractionTime { get; set; }
        public int AttractionTimeOUt { get; set; }
        public Nullable<int> AttractionLastAction { get; set; }
        public Nullable<int> AttractionCost { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AttractionStatus> AttractionStatus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FavoriteAttraction> FavoriteAttraction { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Message { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Queues> Queues { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rate> Rate { get; set; }
    }
}
