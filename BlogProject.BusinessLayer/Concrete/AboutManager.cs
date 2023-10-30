using BlogProject.BusinessLayer.Abstract;
using BlogProject.DataAccessLayer.Abstract;
using BlogProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace BlogProject.BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private IAboutDAL _aboutDAL;

        public AboutManager(IAboutDAL aboutDAL)
        {
            _aboutDAL = aboutDAL;
        }

        public void AboutAdd(About about)
        {
            _aboutDAL.Insert(about);
        }

        public void AboutDelete(About about)
        {
            _aboutDAL.Delete(about);    
        }

        public void AboutUpdate(About about)
        {
            _aboutDAL.Update(about);
        }

        public About GetByID(int id)
        {
            return _aboutDAL.Get(x => x.AboutID == id);
        }

        public List<About> GetList()
        {
            return _aboutDAL.List();
        }
    }
}