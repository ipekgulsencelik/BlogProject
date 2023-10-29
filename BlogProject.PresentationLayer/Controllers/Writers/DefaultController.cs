using BlogProject.BusinessLayer.Concrete;
using BlogProject.DataAccessLayer.EntityFramework;
using System.Web.Mvc;

namespace BlogProject.PresentationLayer.Controllers.Writers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EFHeadingDAL());
        ContentManager contentManager = new ContentManager(new EFContentDAL());

        public ActionResult Headings()
        {
            var headingList = headingManager.GetList();
            return View(headingList);
        }

        public PartialViewResult Index(int id = 0)
        {
            var contentList = contentManager.GetListByHeadingID(id);
            return PartialView(contentList);
        }
    }
}