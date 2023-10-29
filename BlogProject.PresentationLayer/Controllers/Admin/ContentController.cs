using BlogProject.BusinessLayer.Concrete;
using BlogProject.DataAccessLayer.EntityFramework;
using System.Web.Mvc;

namespace BlogProject.PresentationLayer.Controllers.Admin
{
    public class ContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EFContentDAL());

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllContent()
        {
            var values = contentManager.GetList();

            return View(values);
        }

        [HttpPost]
        public ActionResult GetAllContent(string searchKeyWord)
        {
            var values = contentManager.GetListBySearch(searchKeyWord);

            return View(values);
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentValues = contentManager.GetListByHeadingID(id);
            return View(contentValues);
        }
    }
}