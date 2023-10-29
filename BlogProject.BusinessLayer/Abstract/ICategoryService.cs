using BlogProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace BlogProject.BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList();
        Category GetByIdCategory(int id); 
        void CategoryAdd(Category category);
        void CategoryDelete(Category category);
        void CategoryUpdate(Category category);
    }
}
