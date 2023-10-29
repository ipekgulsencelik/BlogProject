using BlogProject.BusinessLayer.Concrete;
using BlogProject.DataAccessLayer.Concrete;
using BlogProject.DataAccessLayer.EntityFramework;
using BlogProject.EntityLayer.Concrete;
using System;
using System.Linq;
using System.Web.Mvc;

namespace BlogProject.PresentationLayer.Controllers.Writers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EFContentDAL());

        Context context = new Context();

        public ActionResult MyContent(string session)
        {
            session = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == session).Select(y => y.WriterID).FirstOrDefault();
            var contentValues = contentManager.GetListByWriter(writerIdInfo);
            return View(contentValues);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string session = (string)Session["WriterMail"];
            var writeridinfo = context.Writers.Where(x => x.WriterMail == session).Select(y => y.WriterID).FirstOrDefault();
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterID = writeridinfo;
            content.ContentStatus = true;
            contentManager.ContentAdd(content);
            return RedirectToAction("MyContent");
        }

        public ActionResult ToDoList()
        {
            return View();
        }
    }
}