using System.Web.Mvc;

namespace BlogProject.PresentationLayer.Controllers
{
    public class SweetAlertController : Controller
    {
        public ActionResult Alert()
        {
            return View();
        }
    }
}