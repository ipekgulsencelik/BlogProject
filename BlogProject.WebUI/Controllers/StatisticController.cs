using BlogProject.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.WebUI.Controllers
{
    public class StatisticController : Controller
    {
        Context _context = new Context();

        // GET: Istatistik
        public ActionResult Index()
        {
            var totalCategory = _context.Categories.Count(); //Toplam Kategori Sayisi
            ViewBag.totalNumberOfCategories = totalCategory;

            var softwareCategory = _context.Headings.Count(x => x.Category.CategoryName == "Yazılım"); // Yazilim Kategorisi (8) baslik sayisi
            ViewBag.softwareCategoryTitleNumber = softwareCategory;

            var writerNameSortByA = _context.Writers.Count(x => x.WriterName.Contains("a")); // Yazar adinda "a" harfi gecen yazar sayisi
            ViewBag.writerNameSortByA = writerNameSortByA;

            var mostTitles = _context.Headings.Max(x => x.Category.CategoryName); // En fazla basliga sahip kategori adi
            ViewBag.categoryNameWithTheMostTitles = mostTitles;

            var categoryStatusTrue = _context.Categories.Count(x => x.CategoryStatus == true); // Kategoriler tablosundaki aktif kategori sayisi
            ViewBag.activeCategories = categoryStatusTrue;
            var categoryStatusFalse = _context.Categories.Count(x => x.CategoryStatus == false); // Kategoriler tablosundaki pasif kategori sayisi
            ViewBag.passiveCategories = categoryStatusFalse;

            ViewBag.categoryStatus = (categoryStatusTrue - categoryStatusFalse);

            return View();
        }
    }
}