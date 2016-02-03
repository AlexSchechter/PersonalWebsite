using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog.Models;
using System.IO;

namespace Blog.Controllers
{
    [RequireHttps]
    public class BlogEntriesController : Controller
    {
    
        private ApplicationDbContext db = new ApplicationDbContext();

        public JsonResult GetBlogEntries()
        {
            return Json(db.BlogEntries.OrderByDescending(p => p.CreationDate).ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBlogEntry(int id)
        {
            
            return Json(db.BlogEntries.Find(id), JsonRequestBehavior.AllowGet);
        }

        // GET: BlogEntries
        public ActionResult Index()
        {
            return View(db.BlogEntries.ToList());
        }

        // GET: BlogEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogEntry blogEntry = db.BlogEntries.Find(id);
            if (blogEntry == null)
            {
                return HttpNotFound();
            }
            return View(blogEntry);
        }

        // GET: BlogEntries/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Title,Summary,Body,Published")] BlogEntry blogEntry, HttpPostedFileBase fileUpload)
        {
            if (ModelState.IsValid)
            {
                if (ImageUploadValidator.IsWebFriendlyImage(fileUpload))
                {
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    fileUpload.SaveAs(Path.Combine(Server.MapPath("~/assets/images/"), fileName));
                    blogEntry.MediaURL = string.Concat("/assets/images/", fileName);
                }
                blogEntry.CreationDate = new DateTimeOffset(DateTime.Now);
                db.BlogEntries.Add(blogEntry);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(blogEntry);
        }

        // GET: BlogEntries/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogEntry blogEntry = db.BlogEntries.Find(id);
            if (blogEntry == null)
            {
                return HttpNotFound();
            }
            return View(blogEntry);
        }

        // POST: BlogEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,CreationDate,UpdatedDate,Title,Summary,Body,MediaURL,Published")] BlogEntry blogEntry, HttpPostedFileBase fileUpload)
        {
            if (ModelState.IsValid)
            {
                if (ImageUploadValidator.IsWebFriendlyImage(fileUpload))
                {
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    fileUpload.SaveAs(Path.Combine(Server.MapPath("~/assets/images/"), fileName));
                    blogEntry.MediaURL = string.Concat("/assets/images/", fileName);
                }
                
                blogEntry.UpdatedDate = new DateTimeOffset(DateTime.Now);
                db.Entry(blogEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(blogEntry);
        }

        // GET: BlogEntries/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogEntry blogEntry = db.BlogEntries.Find(id);
            if (blogEntry == null)
            {
                return HttpNotFound();
            }
            return View(blogEntry);
        }

        // POST: BlogEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogEntry blogEntry = db.BlogEntries.Find(id);
            db.BlogEntries.Remove(blogEntry);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
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
