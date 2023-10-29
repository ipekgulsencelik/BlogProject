using BlogProject.BusinessLayer.Concrete;
using BlogProject.DataAccessLayer.EntityFramework;
using BlogProject.EntityLayer.Concrete;
using PagedList;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using BlogProject.PresentationLayer.Models;

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

        [HttpGet]
        public ActionResult AddImage()
        {
            ImageViewModel imageModel = new ImageViewModel() { FileAttach = null, Message = string.Empty, IsValid = false };

            try { }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return this.View(imageModel);
        }

        [HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult AddImage(ImageViewModel imageModel, ImageFile imageFile)
        {
            string folderPath = Server.MapPath("~/Images/Gallery/");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            try
            {
                if (ModelState.IsValid)
                {
                    string fileName = Path.GetFileName(Request.Files[0].FileName);
                    string expansion = Path.GetExtension(Request.Files[0].FileName);
                    string path = "/Images/Gallery/" + fileName + expansion;

                    if (Request.Files.Count > 0)
                    {
                        var fullPath = Server.MapPath("/Images/Gallery/") + fileName + expansion;
                        if (System.IO.File.Exists(fullPath))
                        {
                            ViewBag.ActionMessage = "Bu dosya adında başka bir resim mevcuttur";
                        }
                        else
                        {
                            Request.Files[0].SaveAs(Server.MapPath(path));
                            imageFile.ImageName = fileName;
                            imageFile.ImagePath = "/Images/Gallery/" + fileName + expansion;
                            imageFile.ImageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                            imageFileManager.ImageAdd(imageFile);
                            //ViewBag.ActionMessage = "Resim yükleme başarıyla gerçekleşmiştir.";
                            imageModel.Message = "'" + imageModel.FileAttach.FileName + "' dosya yükleme başarılı.   ";
                            return RedirectToAction("Index");
                        }
                    }

                    // Ayarlar - Dogrulama gecerliyse 
                    //imageModel.Message = "'" + imageModel.FileAttach.FileName + "' dosya yükleme başarılı.   ";
                    imageModel.IsValid = true;
                }
                else
                {
                    // Ayarlar - Dogrulama gecersizse  
                    imageModel.Message = "'" + imageModel.FileAttach.FileName + "' dosya yükleme başarısız!   ";
                    imageModel.IsValid = false;
                }
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
            }
            return View(imageModel);
        }


        [HttpGet]
        public ActionResult UpdateImage(int id)
        {
            ImageViewModel updateModel = new ImageViewModel();


            List<SelectListItem> _valueImage = (from x in imageFileManager.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.ImageName,
                                                    Value = x.ImageFileID.ToString()
                                                }).ToList();
            ViewBag.valueImage = _valueImage;
            ViewData["Image"] = imageFileManager.GetByID(id);
            ViewData["Models"] = updateModel;
            return View(_valueImage);
        }

        [HttpPost]
        public ActionResult UpdateImage(ImageFile imageFile, string[] DynamicTextBox)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ViewBag.Values = serializer.Serialize(DynamicTextBox);

            string message = "";

            foreach (string textboxValue in DynamicTextBox)
            {
                message = textboxValue;
            }
            ViewBag.Message = message;
            imageFile.ImageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            imageFileManager.ImageUpdate(imageFile);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteImage(int Id)
        {
            var imageValues = imageFileManager.GetByID(Id);
            imageFileManager.ImageDelete(imageValues);
            return RedirectToAction("Index");
        }

    }
}