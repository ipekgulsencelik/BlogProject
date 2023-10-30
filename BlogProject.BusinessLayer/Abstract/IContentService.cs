using BlogProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace BlogProject.BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetListBySearch(string searchKeyWord);
        List<Content> GetList();
        List<Content> GetListByWriter(int id);
        List<Content> GetListByHeading(int id); 
        Content GetByID(int id);
        void ContentAdd(Content content);
        void ContentDelete(Content content);
        void ContentUpdate(Content content);
    }
}