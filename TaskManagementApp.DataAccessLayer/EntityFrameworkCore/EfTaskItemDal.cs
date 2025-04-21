using Microsoft.EntityFrameworkCore;
using TaskManagementApp.DataAccessLayer.Abstract;
using TaskManagementApp.DataAccessLayer.Contexts;
using TaskManagementApp.DataAccessLayer.Repositories;
using TaskManagementApp.EntityLayer.Entities;

namespace TaskManagementApp.DataAccessLayer.EntityFrameworkCore
{
    public class EfTaskItemDal : GenericRepository<TaskItem>, ITaskItemDal
    {
        private readonly AppDbContext _context;

        public EfTaskItemDal(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<TaskItem>> GetTasksByProjectIdAsync(int projectId)
        {
            return await _context.TaskItems
                .Include(t => t.AssignedToUser) // Assigned user bilgisi gelsin
                .Include(t => t.Comments)       // Yorumlar da gelsin
                .Where(t => t.ProjectId == projectId)
                .ToListAsync();
        }

        public async Task<List<TaskItem>> GetTasksByUserIdAsync(int userId)
        {
            return await _context.TaskItems
         .Include(t => t.AssignedToUser)  // ✳️ Kullanıcı bilgisi
         .Include(t => t.Project)         // ✳️ Proje bilgisi
         .Where(t => t.AssignedToUserId == userId)
         .ToListAsync();        
        }

        public async Task<List<TaskItem>> GetTasksByStatusAsync(string status)
        {
            return await _context.TaskItems
                .Include(t => t.AssignedToUser)
                .Include(t => t.Project)
                .Where(t => t.Status == status)
                .ToListAsync();
        }

        public async Task<List<TaskItem>> GetOverdueTasksAsync()
        {
            return await _context.TaskItems
                .Include(t => t.AssignedToUser)
                .Include(t => t.Project)
                .Where(t => t.Deadline < DateTime.UtcNow && t.Status != "Done")
                .ToListAsync();
        }
        public async Task<TaskItem> GetTaskItemWithProjectAndCommentsAsync(int id)
        {
            return await _context.TaskItems
        .Include(t => t.Project)
        .Include(t => t.Comments)
            .ThenInclude(c => c.User) // yorum yazan kullanıcının bilgisi
        .FirstOrDefaultAsync(t => t.Id == id);
        }

    }
}
