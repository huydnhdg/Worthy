using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Worthy.Models;

namespace Worthy.Areas.Admin.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        hn_seoworhtyEntities db = new hn_seoworhtyEntities();
        // GET: Admin/Khachhang
        public ActionResult Index()
        {
            var model = db.Customers.OrderByDescending(a => a.Customer_Name);
            return View(model);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer cus = db.Customers.Find(id);
            if (cus == null)
            {
                return HttpNotFound();
            }
            return View(cus);
        }
    }
}