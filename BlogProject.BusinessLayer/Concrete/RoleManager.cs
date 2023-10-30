using BlogProject.BusinessLayer.Abstract;
using BlogProject.DataAccessLayer.Abstract;
using BlogProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace BlogProject.BusinessLayer.Concrete
{
    public class RoleManager : IRoleService
    {
        IRoleDAL _roleDAL;

        public RoleManager(IRoleDAL roleDAL)
        {
            _roleDAL = roleDAL;
        }

        public List<Role> GetRoles()
        {
            return _roleDAL.List();
        }
    }
}