using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Worthy.Models;

namespace Worthy.Areas.Admin.Controllers
{
    [Authorize]
    public class CategoryPostController : Controller
    {
        hn_seoworhtyEntities db = new hn_seoworhtyEntities();
        // GET: Admin/CategoryNews
        public ActionResult Index()
        {
            var model = db.CategoryPosts.OrderByDescending(a => a.Create_date);
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "")] CategoryPost category)
        {
            if (ModelState.IsValid)
            {

                category.Create_date = DateTime.Now;
                db.CategoryPosts.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);

        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryPost category = db.CategoryPosts.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "")] CategoryPost category)
        {
            if (ModelState.IsValid)
            {
                category.Edit_date = DateTime.Now;
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);

        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryPost category = db.CategoryPosts.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            CategoryPost category = db.CategoryPosts.Find(id);
            db.CategoryPosts.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }

}