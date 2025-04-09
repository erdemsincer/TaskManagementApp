using TaskManagementApp.DataAccessLayer.Abstract;
using TaskManagementApp.DataAccessLayer.Contexts;
using TaskManagementApp.DataAccessLayer.Repositories;
using TaskManagementApp.EntityLayer.Entities;

namespace TaskManagementApp.DataAccessLayer.EntityFrameworkCore
{
    public class EfUserDal : GenericRepository<User>, IUserDal
    {
        public EfUserDal(AppDbContext context) : base(context)
        {
        }
    }
}
