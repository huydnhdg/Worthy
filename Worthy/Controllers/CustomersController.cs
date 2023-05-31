using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Worthy.Models;

namespace Worthy.Controllers
{
    public class CustomersController : Controller
    {
        private hn_seoworhtyEntities db = new hn_seoworhtyEntities();

        [Route("gui-thanh-cong")]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult IndexConfirm(String name , String phone, 
            String ImageOrder, String ImageProduct, String model)
        {
         
                var cus = new Infor()
                {
                    FullName = name,
                    Phone = phone,
                    Image_Order = ImageOrder,
                    Image_Product = ImageProduct,
                    Model_size = model,
                    Create_date = DateTime.Now
                };
                db.Infors.Add(cus);
                db.SaveChanges();
               
           
            return RedirectToAction("Index");
        }
    }
}