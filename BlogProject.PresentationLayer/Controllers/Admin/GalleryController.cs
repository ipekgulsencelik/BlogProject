using BlogProject.BusinessLayer.Concrete;
using BlogProject.DataAccessLayer.EntityFramework;
using PagedList;
using System.Web.Mvc;

namespace BlogProject.PresentationLayer.Controllers.Admin
{
    public class GalleryController : Controller
    {
        ImageFileManager imageFileManager = new ImageFileManager(new EFImageFileDAL());

        public ActionResult Index(int? page)
        {
            var files = imageFileManager.GetList().ToPagedList(page ?? 1, 18);
            return View(files);
        }
    }
}