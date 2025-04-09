using TaskManagementApp.DataAccessLayer.Abstract;
using TaskManagementApp.DataAccessLayer.Contexts;
using TaskManagementApp.DataAccessLayer.Repositories;
using TaskManagementApp.EntityLayer.Entities;

namespace TaskManagementApp.DataAccessLayer.EntityFrameworkCore
{
    public class EfRoleDal : GenericRepository<Role>, IRoleDal
    {
        public EfRoleDal(AppDbContext context) : base(context)
        {
        }
    }
}
