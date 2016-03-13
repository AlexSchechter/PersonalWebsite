using System.Web.Mvc;

namespace Blog.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index(bool? formSent)    
        {
            ViewBag.FormSent = formSent == null ? false : true;
            formSent = null;
            return View();
        }

        //[ChildActionOnly]
        //public ActionResult FormSent()
        //{
            
        //    return new ContentResult { Content = "true" };
        //}
    }
}
