using Blog.Models;
using System.Web.Mvc;

namespace Blog.Controllers
{

    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()    
        {
            var db = new ApplicationDbContext();
           
            return View();

        }
    }
}
