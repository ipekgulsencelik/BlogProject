using BlogProject.BusinessLayer.Abstract;
using BlogProject.DataAccessLayer.Abstract;
using BlogProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BusinessLayer.Concrete
{
    public class ScreenShotManager : IScreenShotService
    {
        private IScreenShotDAL _screenShotDAL;

        public ScreenShotManager(IScreenShotDAL screenShotDAL)
        {
            _screenShotDAL = screenShotDAL;
        }

        public List<ScreenShot> GetList()
        {
            return _screenShotDAL.List();
        }
    }
}