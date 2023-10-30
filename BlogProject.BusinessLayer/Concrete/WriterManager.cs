using BlogProject.BusinessLayer.Abstract;
using BlogProject.DataAccessLayer.Abstract;
using BlogProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace BlogProject.BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDAL _writerDAL;  

        public WriterManager(IWriterDAL writerDAL) 
        {
            _writerDAL = writerDAL;
        }

        public Writer GetByID(int id)
        {
            return _writerDAL.Get(x => x.WriterID == id);
        }

        public List<Writer> GetList()
        {
            return _writerDAL.List();
        }

        public List<Writer> GetListByID(int id)
        {
            return _writerDAL.List(x => x.WriterID == id);
        }

        public void WriterAdd(Writer writer)
        {
            _writerDAL.Insert(writer);
        }

        public void WriterDelete(Writer writer)
        {
            _writerDAL.Delete(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            _writerDAL.Update(writer);
        }
    }
}