using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Worthy.Models;

namespace Worthy.Controllers
{
    public class HomeController : Controller
    {
        hn_seoworhtyEntities db = new hn_seoworhtyEntities();
        [Route]
        public ActionResult Index()
        {
            var model = db.Posts.OrderByDescending(x => x.Create_date).Take(3).ToList();
            return View(model);
        }
        [Route("gioi-thieu")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Route("lien-he")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Route("huong-dan")]
        public ActionResult Guide()
        {
            ViewBag.Message = "Your guide page.";

            return View();
        }
        [Route("In-tem")]
        public ActionResult TemPrint(string alt)
        {
            alt ="in-tem";
            var model = db.Posts.Where(a => a.Alt == alt).SingleOrDefault();
            return View(model);
        }
    }
}