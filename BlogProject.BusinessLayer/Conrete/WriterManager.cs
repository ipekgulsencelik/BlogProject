using BlogProject.BusinessLayer.Abstract;
using BlogProject.DataAccessLayer.Abstract;
using BlogProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BusinessLayer.Conrete
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

        public void Update(Writer writer)
        {
            _writerDAL.Update(writer);
        }

        public void WriterAdd(Writer witer)
        {
            _writerDAL.Insert(witer);

        }

        public void WriterDelete(Writer writer)
        {
            _writerDAL.Delete(writer);
        }
    }
}
