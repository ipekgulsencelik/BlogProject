using BlogProject.BusinessLayer.Abstract;
using BlogProject.DataAccessLayer.Abstract;
using BlogProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace BlogProject.BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        private IHeadingDAL _headingDAL; 

        public HeadingManager(IHeadingDAL headingDAL) 
        {
            _headingDAL = headingDAL;
        }

        public Heading GetByIDHeading(int id)
        {
            return _headingDAL.Get(x => x.HeadingID == id);
        }

        public List<Heading> GetList()
        {
            return _headingDAL.List();
        }

        public List<Heading> GetListByCategoryID(int id)
        {
            return _headingDAL.List(x => x.CategoryID == id);
        }

        public List<Heading> GetListByWriterID(int id)
        {
            return _headingDAL.List(x => x.WriterID == id);
        }

        public void HeadingAdd(Heading heading)
        {
            _headingDAL.Insert(heading);
        }

        public void HeadingDelete(Heading heading)
        {
            _headingDAL.Update(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            _headingDAL.Update(heading);
        }
    }
}