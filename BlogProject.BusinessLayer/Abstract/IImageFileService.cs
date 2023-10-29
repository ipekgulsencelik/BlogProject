using BlogProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace BlogProject.BusinessLayer.Abstract
{
    public interface IImageFileService
    {
        List<ImageFile> GetList();
        ImageFile GetByID(int id);
        void ImageAdd(ImageFile imageFile);
        void ImageDelete(ImageFile imageFile);
        void ImageUpdate(ImageFile imageFile);
    }
}
