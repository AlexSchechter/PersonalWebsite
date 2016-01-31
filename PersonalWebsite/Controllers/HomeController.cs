using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()    
        {
            var db = new ApplicationDbContext();

            //var model = new SiteModel { BlogEntries = db.BlogEntries.ToList() };
            return View();
            //return View(model);
        }
    }
}
