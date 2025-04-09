using TaskManagementApp.DataAccessLayer.Abstract;
using TaskManagementApp.DataAccessLayer.Contexts;
using TaskManagementApp.DataAccessLayer.Repositories;
using TaskManagementApp.EntityLayer.Entities;

namespace TaskManagementApp.DataAccessLayer.EntityFrameworkCore
{
    public class EfTaskItemDal : GenericRepository<TaskItem>, ITaskItemDal
    {
        public EfTaskItemDal(AppDbContext context) : base(context)
        {
        }
    }
}
