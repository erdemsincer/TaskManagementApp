using TaskManagementApp.DataAccessLayer.Abstract;
using TaskManagementApp.DataAccessLayer.Contexts;
using TaskManagementApp.DataAccessLayer.Repositories;
using TaskManagementApp.EntityLayer.Entities;

namespace TaskManagementApp.DataAccessLayer.EntityFrameworkCore
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public EfCommentDal(AppDbContext context) : base(context)
        {
        }
    }
}
