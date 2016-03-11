using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog.Models;

namespace Blog.Controllers
{
    public class ContactFormsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // POST: ContactForms/Create       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FullName,Company,Email,PhoneNumber,Message")] ContactForm contactForm)
        {

            if (ModelState.IsValid)
            {
                db.ContactForm.Add(contactForm);
                await db.SaveChangesAsync();              
            }

         

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
