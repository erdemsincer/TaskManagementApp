using Microsoft.EntityFrameworkCore;
using TaskManagementApp.DataAccessLayer.Abstract;
using TaskManagementApp.DataAccessLayer.Contexts;
using TaskManagementApp.DataAccessLayer.Repositories;
using TaskManagementApp.EntityLayer.Entities;

namespace TaskManagementApp.DataAccessLayer.EntityFrameworkCore
{
    public class EfProjectDal : GenericRepository<Project>, IProjectDal
    {
        private readonly AppDbContext _context;

        public EfProjectDal(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Project>> GetAllWithOwnerAsync()
        {
            return await _context.Projects
                .Include(p => p.OwnerUser)
                .ToListAsync();
        }

        public async Task<List<Project>> GetProjectsByUserIdAsync(int userId)
        {
            return await _context.Projects
                .Where(p => p.OwnerUserId == userId)
                .ToListAsync();
        }

        public async Task<Project> GetProjectWithTasksAsync(int projectId)
        {
            return await _context.Projects
                .Include(p => p.Tasks)
                .FirstOrDefaultAsync(p => p.Id == projectId);
        }
    }
}
