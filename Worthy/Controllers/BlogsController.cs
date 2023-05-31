using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Worthy.Models;
using PagedList;
using System.Net;

namespace Worthy.Controllers
{
    [RoutePrefix("tin-tuc")]
    public class BlogsController : Controller
    {
        hn_seoworhtyEntities db = new hn_seoworhtyEntities();
        // GET: Blogs
        [Route]
        public ActionResult Index(int? page, string SearchString, string currentFilter)
        {


            if (page == null) page = 1;



            int pagesize = 4;

            int pagenumber = (page ?? 1);
            var newslist = new List<Post>();
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFilter;

            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                newslist = db.Posts.Where(a => a.Title.Contains(SearchString)).OrderByDescending(a => a.Create_date).Take(4).ToList();
            }
            else
            {
                newslist = db.Posts.OrderByDescending(a => a.Create_date).ToList();
            }
            var listpost = db.Posts.OrderByDescending(a => a.Create_by);
            List<Post> newslist1 = listpost.Take(3).ToList();
            ViewBag.newslist = newslist1;
            var listcate = db.CategoryPosts.OrderByDescending(a => a.Category_Post_ID);
            List<CategoryPost> newslist2 = listcate.ToList();
            ViewBag.listcate = newslist2;

            return View(newslist.ToPagedList(pagenumber, pagesize));

        }

        [HttpGet]
        [Route("{alt}")]
        public ActionResult Detail(string alt)
        {

            if (alt == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post model = db.Posts.Where(a => a.Alt == alt).SingleOrDefault();
            var listOld = db.Posts.Where(a => a.Category_Post_ID == model.Category_Post_ID && a.Post_ID != model.Post_ID).Take(3).ToList();
            ViewBag.listOld = listOld;
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

    }
}