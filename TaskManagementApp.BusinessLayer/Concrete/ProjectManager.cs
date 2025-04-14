using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.DataAccessLayer.Abstract;
using TaskManagementApp.EntityLayer.Entities;

namespace TaskManagementApp.BusinessLayer.Concrete
{
    public class ProjectManager: GenericManager<Project>, IProjectService
    {
        private readonly IProjectDal _projectDal;

        public ProjectManager(IProjectDal projectDal) : base(projectDal)
        {
            _projectDal = projectDal;
        }

        public async Task<List<Project>> GetAllWithOwnerAsync()
        {
            return await _projectDal.GetAllWithOwnerAsync();
        }

        public async Task<List<Project>> GetProjectsByUserIdAsync(int userId)
        {
            return await _projectDal.GetProjectsByUserIdAsync(userId);
        }

        public async Task<Project> GetProjectWithTasksAsync(int projectId)
        {
            return await _projectDal.GetProjectWithTasksAsync(projectId);
        }
    }
  
}
