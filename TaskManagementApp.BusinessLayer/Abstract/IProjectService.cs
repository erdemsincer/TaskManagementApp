using TaskManagementApp.EntityLayer.Entities;

namespace TaskManagementApp.BusinessLayer.Abstract
{
    public interface IProjectService : IGenericService<Project>
    {
        Task<List<Project>> GetAllWithOwnerAsync();
        Task<List<Project>> GetProjectsByUserIdAsync(int userId);
        Task<Project> GetProjectWithTasksAsync(int projectId);
    }
}
