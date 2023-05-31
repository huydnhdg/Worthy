using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Worthy.Models
{
    public class GetPost
    {
        public static List<Post> posts = Posts();

        static List<Post> Posts()
        {
            hn_seoworhtyEntities db = new hn_seoworhtyEntities();
            var data = (from d in db.Posts
                        orderby d.Post_ID
                        select d).Take(3).ToList();
            if (data.Count > 0)
            {
                return data;
            }
            return null;
        }
    }
}