using Microsoft.EntityFrameworkCore;
using TaskManagementApp.DataAccessLayer.Abstract;
using TaskManagementApp.DataAccessLayer.Contexts;
using TaskManagementApp.DataAccessLayer.Repositories;
using TaskManagementApp.EntityLayer.Entities;

namespace TaskManagementApp.DataAccessLayer.EntityFrameworkCore
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        private readonly AppDbContext _context;
        public EfCommentDal(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetCommentsWithUserByTaskItemIdAsync(int taskItemId)
        {
            return await _context.Comments
                .Include(c => c.User) // ✅ Yorum yapan kullanıcıyı da getir
                .Where(c => c.TaskItemId == taskItemId)
                .ToListAsync();
        }

    }
}
