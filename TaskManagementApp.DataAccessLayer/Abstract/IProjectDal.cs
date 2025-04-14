using TaskManagementApp.EntityLayer.Entities;

namespace TaskManagementApp.DataAccessLayer.Abstract
{
    public interface IProjectDal : IGenericDal<Project> {

        Task<List<Project>> GetAllWithOwnerAsync();
        Task<List<Project>> GetProjectsByUserIdAsync(int userId);
        Task<Project> GetProjectWithTasksAsync(int projectId);

    }
}
