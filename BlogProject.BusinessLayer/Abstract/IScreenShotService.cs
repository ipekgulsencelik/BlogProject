using BlogProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace BlogProject.BusinessLayer.Abstract
{
    public interface IScreenShotService
    {
        List<ScreenShot> GetList();
    }
}
