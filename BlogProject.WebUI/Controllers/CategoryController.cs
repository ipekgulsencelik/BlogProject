using BlogProject.BusinessLayer.Conrate;
using BlogProject.BusinessLayer.ValidationRule;
using BlogProject.DataAccessLayer.EntityFramework;
using BlogProject.EntityLayer.Concrate;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EFCategoryDAL());

        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var categoryValues = categoryManager.GetList();

            return View(categoryValues);
        }

        [HttpGet]//sayfa yüklendiğinde çalışacak olan
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost] //sayfada butona tıkladığımda 
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