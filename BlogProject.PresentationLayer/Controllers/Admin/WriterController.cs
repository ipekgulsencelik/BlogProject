using BlogProject.BusinessLayer.Concrete;
using BlogProject.BusinessLayer.ValidationRules.FluentValidation;
using BlogProject.DataAccessLayer.EntityFramework;
using BlogProject.EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using System.Web.Mvc;

namespace BlogProject.PresentationLayer.Controllers.Admin
{
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EFWriterDAL());
        WriterValidator writerValidator = new WriterValidator();  

        public ActionResult Index(int? page) 
        {
            var writerValues = writerManager.GetList().ToPagedList(page ?? 1, 12); 
            return View(writerValues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            ValidationResult results = writerValidator.Validate(writer);
            if (results.IsValid)
            {
                writerManager.WriterAdd(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writerValue = writerManager.GetByID(id);
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer writer)
        {
            ValidationResult results = writerValidator.Validate(writer);
            if (results.IsValid)
            {
                writerManager.WriterUpdate(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}