using BlogProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace BlogProject.BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetList();
        List<Writer> GetListByWriterID(int id);
        Writer GetByID(int id);
        void WriterAdd(Writer writer);
        void WriterDelete(Writer writer);
        void WriterUpdate(Writer writer);
    }
}
