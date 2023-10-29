using BlogProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace BlogProject.BusinessLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetList();
        void AdminAdd(Admin admin);
        void AdminDelete(Admin admin);
        void AdminUpdate(Admin admin);
        Admin GetByID(int id);
    }
}