using System.Web.Mvc;

namespace Blog.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()    
        {
            ViewBag.FormSent = TempData["formSent"] == null ? false : true;
            return View();
        }
    }
}
