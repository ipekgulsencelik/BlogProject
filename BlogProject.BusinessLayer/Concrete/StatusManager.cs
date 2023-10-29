using BlogProject.BusinessLayer.Abstract;
using BlogProject.DataAccessLayer.Abstract;
using BlogProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BusinessLayer.Concrete
{
    public class StatusManager : IStatusService
    {
        private IStatusDAL _statusDAL;

        public StatusManager(IStatusDAL statusDAL)
        {
            _statusDAL = statusDAL;
        }

        public List<Status> GetList()
        {
            return _statusDAL.List();
        }
    }
}