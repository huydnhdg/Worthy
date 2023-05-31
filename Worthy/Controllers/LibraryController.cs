using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Worthy.Models;

namespace Worthy.Controllers
{
    [RoutePrefix("thu-vien")]
    public class LibraryController : Controller
    {
        hn_seoworhtyEntities db = new hn_seoworhtyEntities();
        // GET: Library
        [Route("{alt}")]
        public ActionResult Index(string alt  , int? page, string SearchString, string currentFilter)
        {
            if (page == null) page = 1;
            int pagesize = 6;

            int pagenumber = (page ?? 1);

            var newslist = new List<Post>();
            newslist = db.Posts.Where(a=>a.CategoryPost.Alt == alt).OrderByDescending(a => a.Create_date).ToList();

            return View(newslist.ToPagedList(pagenumber, pagesize));
        }
    }
}