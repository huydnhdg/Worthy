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
    
    public partial class Post
    {
        public int Post_ID { get; set; }
        public string Title { get; set; }
        public Nullable<int> Category_Post_ID { get; set; }
        public string Thumbnail { get; set; }
        public string Content { get; set; }
        public string Tag { get; set; }
        public string Alt { get; set; }
        public Nullable<System.DateTime> Create_date { get; set; }
        public Nullable<System.DateTime> Edit_date { get; set; }
        public string Create_by { get; set; }
        public string Description { get; set; }
    
        public virtual CategoryPost CategoryPost { get; set; }
    }
}
