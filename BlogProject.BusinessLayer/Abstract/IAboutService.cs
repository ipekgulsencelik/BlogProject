using BlogProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace BlogProject.BusinessLayer.Abstract
{
    public interface IAboutService
    {
        About GetByAboutID(int id);
        List<About> GetList();
        //List<About> GetListIsFalse();
        //List<About> GetListIsTrue();
        void AboutAdd(About about);
        void AboutDelete(About about);
        void AboutUpdate(About about);
    }
}