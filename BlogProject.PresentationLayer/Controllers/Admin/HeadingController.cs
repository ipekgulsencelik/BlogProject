using BlogProject.BusinessLayer.Concrete;
using BlogProject.DataAccessLayer.EntityFramework;
using BlogProject.EntityLayer.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BlogProject.PresentationLayer.Controllers.Admin
{
    public class HeadingController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EFHeadingDAL());
        CategoryManager categoryManager = new CategoryManager(new EFCategoryDAL());
        WriterManager writerManager = new WriterManager(new EFWriterDAL());
        StatusManager statusManager = new StatusManager(new EFStatusDAL());

        public ActionResult Index(int? page) 
        {
            var headingValues = headingManager.GetList().ToPagedList(page ?? 1, 8); 
            return View(headingValues);
        }

        public ActionResult HeadingReport()
        {
            var headingValues = headingManager.GetList();
            return View(headingValues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> _valueCategory = (from x in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();

            List<SelectListItem> _valueWriter = (from x in writerManager.GetList()
                                                 select new SelectListItem()
                                                 {
                                                     Text = x.WriterName + " " + x.WriterSurName,
                                                     Value = x.WriterID.ToString()
                                                 }).ToList();

            List<SelectListItem> headingStatusValue = (from x in statusManager.GetList()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.StatusName,
                                                           Value = x.StatusID.ToString()
                                                       }).ToList();

            ViewBag.valueHeadingStatus = headingStatusValue;
            ViewBag.valueCategory = _valueCategory;
            ViewBag.valueWriter = _valueWriter;

            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            headingManager.HeadingAdd(heading);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> _valueCategory = (from x in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();

            List<SelectListItem> headingStatusValue = (from x in statusManager.GetList()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.StatusName,
                                                           Value = x.StatusID.ToString()
                                                       }).ToList();

            ViewBag.valueHeadingStatus = headingStatusValue;
            ViewBag.valueCategory = _valueCategory; 
            var headingValue = headingManager.GetByIDHeading(id);

            return View(headingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = headingManager.GetByIDHeading(id);

            if (headingValue.StatusID == 2)
            {
                headingValue.StatusID = 1;
            }
            else
            {
                headingValue.StatusID = 2;
            }

            headingManager.HeadingDelete(headingValue);
            return RedirectToAction("Index");
        }

        public ActionResult HeadingByCategory(int id)
        {
            var headingValue = headingManager.GetListByCategoryID(id);
            return View(headingValue);
        }

        public ActionResult HeadingByWriter(int id)
        {
            var headingValue = headingManager.GetListByWriterID(id);
            return View(headingValue);
        }
    }
}