using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Worthy.Models;

namespace Worthy.Areas.Admin.Controllers
{
    [Authorize]
    public class InforsController : Controller
    {
        private hn_seoworhtyEntities db = new hn_seoworhtyEntities();

        // GET: Admin/Infors
        public ActionResult Index(string SearchString)
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                var model = db.Infors.Where(a => a.FullName.Contains(SearchString) && a.Phone.Contains(SearchString) && a.Model_size.Contains(SearchString)).OrderByDescending(a => a.Create_date).ToList();
                return View(model);
            }
            else
            {
               var  model = db.Infors.OrderByDescending(a => a.FullName);
                return View(model);
            }
            
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Infor cus = db.Infors.Find(id);
            if (cus == null)
            {
                return HttpNotFound();
            }
            return View(cus);
        }
    }
}
