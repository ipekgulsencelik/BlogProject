using BlogProject.BusinessLayer.Abstract;
using BlogProject.DataAccessLayer.Abstract;
using BlogProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace BlogProject.BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDAL _adminDAL;

        public AdminManager(IAdminDAL adminDAL)
        {
            _adminDAL = adminDAL;
        }

        public void AdminAdd(Admin admin)
        {
            _adminDAL.Insert(admin);
        }

        public void AdminDelete(Admin admin)
        {
            _adminDAL.Delete(admin);
        }

        public void AdminUpdate(Admin admin)
        {
            _adminDAL.Update(admin);
        }

        public Admin GetByID(int id)
        {
            return _adminDAL.Get(x => x.AdminID == id);
        }

        public List<Admin> GetList()
        {
            return _adminDAL.List();
        }
    }
}