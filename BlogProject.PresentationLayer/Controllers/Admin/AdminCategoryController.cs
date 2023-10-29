using BlogProject.BusinessLayer.Concrete;
using BlogProject.BusinessLayer.ValidationRules.FluentValidation;
using BlogProject.DataAccessLayer.EntityFramework;
using BlogProject.EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BlogProject.PresentationLayer.Controllers.Admin
{
    public class AdminCategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EFCategoryDAL());
        StatusManager statusManager = new StatusManager(new EFStatusDAL());

        public ActionResult Index(int? page)
        {
            var categoryValues = categoryManager.GetList().ToPagedList(page ?? 1, 10);
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
                category.CategoryDate = DateTime.Parse(DateTime.Now.ToShortDateString());
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
            var categoryValue = categoryManager.GetByIdCategory(id);

            if (categoryValue.StatusID == 2)
            {
                categoryValue.StatusID = 1;
            }
            else
            {
                categoryValue.StatusID = 2;
            }

            categoryManager.CategoryDelete(categoryValue);
            return RedirectToAction("Index");
        }

        [HttpGet] 
        public ActionResult UpdateCategory(int id)
        {
            List<SelectListItem> categoryStatusValue = (from x in statusManager.GetList()
                                                        select new SelectListItem
                                                        {
                                                            Text = x.StatusName,
                                                            Value = x.StatusID.ToString()
                                                        }).ToList();

            ViewBag.valueCategoryStatus = categoryStatusValue;

            var categoryValue = categoryManager.GetByIdCategory(id);
            return View(categoryValue); 
        }

        [HttpPost] 
        public ActionResult UpdateCategory(Category category)
        {
            category.CategoryDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            categoryManager.CategoryUpdate(category);
            return RedirectToAction("Index");
        }

        //public ActionResult CategoryByHeading(int id)
        //{
        //    var categoryValue = categoryManager.GetByIdCategory(id);
        //    return View(categoryValue);
        //}
    }
}