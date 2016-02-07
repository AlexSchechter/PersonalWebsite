using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Blog.Models;

namespace Blog.Controllers
{
    [RequireHttps]
    public class CommentsController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        public JsonResult GetComments(int blogEntryId)
        {
            var result = db.Comments.Where(c => c.PostId == blogEntryId).ToList().OrderByDescending(c => c.CreationDate);
            //var temp = db.Comments.ToList().OrderByDescending(p => p.CreationDate);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Comments
        public ActionResult Index()
        {
            //var comments = db.Comments.Include(c => c.Author).Include(c => c.Editor).Include(c => c.ParentComment).Include(c => c.Post);
            var comments = db.Comments.Include(c => c.Author);
            return View(comments.ToList());
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comments/Create
        [Authorize]
        public ActionResult Create(int id)
        {
            Comment model = new Comment { PostId = id };
            return View(model);
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostId,Body,Title")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.CreationDate = new DateTimeOffset(DateTime.Now);
                comment.AuthorId = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name).Id;
                db.Comments.Add(comment);
                db.SaveChanges();
                var test = Redirect(Url.Action("Index", "Home") + "/#blog");
                return test;
            }
            return View(comment);
        }

        // GET: Comments/Edit/5
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }         
            ViewBag.AuthorId = new SelectList(db.Users, "Id", "FirstName", comment.AuthorId);
            ViewBag.PostId = new SelectList(db.BlogEntries, "Id", "Title", comment.PostId);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Edit([Bind(Include = "Id,PostId,AuthorId,Title,Body,CreationDate,UpdatedDate,UpdateReason,MarkForDeletion,Author")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.UpdatedDate = new DateTimeOffset(DateTime.Now);
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.AuthorId = new SelectList(db.Users, "Id", "FirstName", comment.AuthorId);
            //ViewBag.ParentCommentId = new SelectList(db.Comments, "Id", "AuthorId", comment.ParentCommentId);
            ViewBag.PostId = new SelectList(db.BlogEntries, "Id", "Title", comment.PostId);
            return View(comment);
        }

        // GET: Comments/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
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
