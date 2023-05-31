using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Worthy.Areas.Admin.Data;
using Worthy.Models;

namespace Worthy.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        hn_seoworhtyEntities db = new hn_seoworhtyEntities();
        // GET: Admin/Home
        public ActionResult Index()
        {
            var model = new HomeModel();
            var customer = db.Infors.Count();
            var code = db.Codes.Count();

            model.Code = code;
            model.Customer = customer;
            return View(model);
        }
    }
}