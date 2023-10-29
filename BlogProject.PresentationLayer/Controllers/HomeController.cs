using BlogProject.BusinessLayer.Concrete;
using BlogProject.DataAccessLayer.Concrete;
using BlogProject.DataAccessLayer.EntityFramework;
using System.Linq;
using System.Web.Mvc;

namespace BlogProject.PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        ScreenShotManager screenShotManager = new ScreenShotManager(new EFScreenShotDAL());

        Context _context = new Context();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult HomePage()
        {
            var files = screenShotManager.GetList();

            var totalCategory = _context.Categories.Count(); 
            ViewBag.totalNumberOfCategories = totalCategory;

            var totalHeading = _context.Headings.Count(); 
            ViewBag.totalHeading = totalHeading;

            var totalWriter = _context.Writers.Count();
            ViewBag.totalWriter = totalWriter;

            var categoryStatusTrue = _context.Categories.Count(x => x.StatusID == 2); 
            ViewBag.activeCategories = categoryStatusTrue;

            return View(files);
        }
    }
}