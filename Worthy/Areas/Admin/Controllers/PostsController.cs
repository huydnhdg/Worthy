using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Worthy.Models;

namespace Worthy.Areas.Admin.Controllers
{
    public class PostsController : Controller
    {
        private hn_seoworhtyEntities db = new hn_seoworhtyEntities();

        // GET: Admin/Posts
        public ActionResult Index()
        {
            var model = db.Posts.OrderByDescending(a => a.Create_date);
            return View(model);
        }

        // GET: Admin/Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Admin/Posts/Create
        public ActionResult Create()
        {
            var droplist = new List<CategoryPost>();
            droplist.Add(new CategoryPost()
            {

                Category_Name = "Select CategoryPost",
            });
            droplist.AddRange(db.CategoryPosts.OrderBy(a => a.Category_Name).ToList());
            ViewBag.Category_Post = droplist;
            return View();
        }

        // POST: Admin/Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "")] Post post)
        {

            if (ModelState.IsValid)
            {
                post.Create_date = DateTime.Now;
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

            // GET: Admin/Posts/Edit/5
            public ActionResult Edit(int? id)
        {
            var droplist = new List<CategoryPost>();
            droplist.Add(new CategoryPost()
            {

                Category_Name = "Select CategoryPost",
            });
            droplist.AddRange(db.CategoryPosts.OrderBy(a => a.Category_Name).ToList());
            ViewBag.Category_Post = droplist;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
         
            return View(post);
        }

        // POST: Admin/Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "")] Post post)
        {

            if (ModelState.IsValid)
            {
                post.Edit_date = DateTime.Now;
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Admin/Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Admin/Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
