using BlogProject.BusinessLayer.Abstract;
using BlogProject.DataAccessLayer.Abstract;
using BlogProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace BlogProject.BusinessLayer.Concrete
{
    public class ImageFileManager : IImageFileService
    {
        private IImageFileDAL _imageFileDAL;

        public ImageFileManager(IImageFileDAL imageFileDAL)
        {
            _imageFileDAL = imageFileDAL;
        }

        public ImageFile GetByID(int id)
        {
            return _imageFileDAL.Get(x => x.ImageFileID == id);
        }

        public List<ImageFile> GetList()
        {
            return _imageFileDAL.List();
        }

        public void ImageAdd(ImageFile imageFile)
        {
            _imageFileDAL.Insert(imageFile);
        }

        public void ImageDelete(ImageFile imageFile)
        {
            _imageFileDAL.Delete(imageFile);
        }

        public void ImageUpdate(ImageFile imageFile)
        {
            _imageFileDAL.Update(imageFile);
        }
    }
}