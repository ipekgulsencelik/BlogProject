using BlogProject.BusinessLayer.Abstract;
using BlogProject.DataAccessLayer.Abstract;
using BlogProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace BlogProject.BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        private IContentDAL _contentDAL;
        
        public ContentManager(IContentDAL contentDAL)
        {
            _contentDAL = contentDAL;
        }

        public void ContentAdd(Content content)
        {
            _contentDAL.Insert(content);
        }

        public void ContentDelete(Content content)
        {
            _contentDAL.Delete(content);
        }

        public void ContentUpdate(Content content)
        {
            _contentDAL.Update(content);
        }

        public Content GetByID(int id)
        {
            return _contentDAL.Get(x => x.ContentID == id);
        }

        public List<Content> GetList()
        {
            return _contentDAL.List();
        }

        public List<Content> GetListByHeading(int id)
        {
            return _contentDAL.List(x => x.HeadingID == id); 
        }

        public List<Content> GetListBySearch(string searchKeyWord)
        {
            return _contentDAL.List(x => x.ContentValue.Contains(searchKeyWord));
        }

        public List<Content> GetListByWriter(int id)
        {
            return _contentDAL.List(x => x.WriterID == id);
        }
    }
}