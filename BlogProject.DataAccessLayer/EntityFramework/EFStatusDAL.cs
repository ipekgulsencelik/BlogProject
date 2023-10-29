using BlogProject.DataAccessLayer.Abstract;
using BlogProject.DataAccessLayer.Concrete.Repositories;
using BlogProject.EntityLayer.Concrete;

namespace BlogProject.DataAccessLayer.EntityFramework
{
    public class EFStatusDAL : GenericRepository<Status>, IStatusDAL
    {
    }
}
