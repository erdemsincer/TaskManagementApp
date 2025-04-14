using Microsoft.EntityFrameworkCore;
using TaskManagementApp.DataAccessLayer.Abstract;
using TaskManagementApp.DataAccessLayer.Contexts;
using TaskManagementApp.DataAccessLayer.Repositories;
using TaskManagementApp.EntityLayer.Entities;

namespace TaskManagementApp.DataAccessLayer.EntityFrameworkCore
{
    public class EfUserDal : GenericRepository<User>, IUserDal
    {
        private readonly AppDbContext _context;
        public EfUserDal(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users
                .Include(u => u.Role) // Eğer token'da Role kullanılacaksa
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<List<User>> GetAllWithRoleAsync()
        {
            return await _context.Users
                .Include(u => u.Role)
                .ToListAsync();
        }

        public async Task<User> GetByIdWithRoleAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetUserWithAssignedTasksAsync(int id)
        {
            return await _context.Users
                .Include(u => u.AssignedTasks)
                .Include(u => u.Role) 
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<(int taskCount, int commentCount)> GetUserActivitySummaryAsync(int id)
        {
            var taskCount = await _context.TaskItems.CountAsync(t => t.AssignedToUserId == id);
            var commentCount = await _context.Comments.CountAsync(c => c.UserId == id);
            return (taskCount, commentCount);
        }
    }
}
