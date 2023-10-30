using BlogProject.BusinessLayer.Abstract;
using BlogProject.DataAccessLayer.Abstract;
using BlogProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace BlogProject.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDAL _categoryDAL;

        public CategoryManager(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public void CategoryAdd(Category category)
        {
            _categoryDAL.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDAL.Update(category); 
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDAL.Update(category);
        }

        public Category GetByID(int id)
        {
            return _categoryDAL.Get(x => x.CategoryID == id);
        }

        public List<Category> GetList()
        {
            return _categoryDAL.List();
        }
    }
}