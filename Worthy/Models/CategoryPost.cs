//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Worthy.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CategoryPost
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CategoryPost()
        {
            this.Posts = new HashSet<Post>();
        }
    
        public int Category_Post_ID { get; set; }
        public string Category_Name { get; set; }
        public string Short_Decription { get; set; }
        public Nullable<System.DateTime> Create_date { get; set; }
        public Nullable<System.DateTime> Edit_date { get; set; }
        public string Alt { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
