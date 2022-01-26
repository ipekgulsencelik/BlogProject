using BlogProject.BusinessLayer.Conrete;
using BlogProject.BusinessLayer.ValidationRule;
using BlogProject.DataAccessLayer.EntityFramework;
using BlogProject.EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.WebUI.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EFCategoryDAL());

        // GET: AdminCategory
        public ActionResult Index()
        {
            var categoryVlues = categoryManager.GetList();

            return View(categoryVlues);
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

        public ActionResult DeleteCategory(int id)
        {
            var categoryValue = categoryManager.GetByID(id);

            categoryManager.CategoryDelete(categoryValue);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryValue = categoryManager.GetByID(id);

            return View(categoryValue);
        }

        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            categoryManager.CategoryUpdate(category);

            return RedirectToAction("Index");
        }
    }
}