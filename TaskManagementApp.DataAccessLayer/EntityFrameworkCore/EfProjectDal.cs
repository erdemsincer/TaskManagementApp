using TaskManagementApp.DataAccessLayer.Abstract;
using TaskManagementApp.DataAccessLayer.Contexts;
using TaskManagementApp.DataAccessLayer.Repositories;
using TaskManagementApp.EntityLayer.Entities;

namespace TaskManagementApp.DataAccessLayer.EntityFrameworkCore
{
    public class EfProjectDal : GenericRepository<Project>, IProjectDal
    {
        public EfProjectDal(AppDbContext context) : base(context)
        {
        }
    }
}
