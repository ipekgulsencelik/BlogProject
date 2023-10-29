using BlogProject.BusinessLayer.Concrete;
using BlogProject.BusinessLayer.ValidationRules.FluentValidation;
using BlogProject.DataAccessLayer.EntityFramework;
using BlogProject.EntityLayer.Concrete;
using System.Web.Mvc;
using FluentValidation.Results;

namespace BlogProject.PresentationLayer.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EFCategoryDAL());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var categoryValues = categoryManager.GetList();
            return View(categoryValues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost] 
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(category);

            if (results.IsValid)
            {
                categoryManager.CategoryAdd(category);
                return RedirectToAction("GetCategoryList");
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