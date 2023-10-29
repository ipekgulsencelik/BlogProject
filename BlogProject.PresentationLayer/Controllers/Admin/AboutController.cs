using BlogProject.BusinessLayer.Concrete;
using BlogProject.DataAccessLayer.EntityFramework;
using BlogProject.EntityLayer.Concrete;
using System.Web.Mvc;

namespace BlogProject.PresentationLayer.Controllers.Admin
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EFAboutDAL());

        public ActionResult Index()
        {
            var aboutValues = aboutManager.GetList();
            return View(aboutValues);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            aboutManager.AboutAdd(about);
            return RedirectToAction("Index");
        }

        public PartialViewResult _AboutPartial()
        {
            return PartialView();
        }

        public ActionResult IsActive(int id)
        {
            var aboutValue = aboutManager.GetByAboutID(id);
            if (aboutValue.Status)
            {
                aboutValue.Status = false;
            }
            else
            {
                aboutValue.Status = true;
            }
            aboutManager.AboutUpdate(aboutValue);

            return RedirectToAction("Index");
        }
    }
}