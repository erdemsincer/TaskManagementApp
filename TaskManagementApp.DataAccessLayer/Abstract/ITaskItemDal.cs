using TaskManagementApp.EntityLayer.Entities;

namespace TaskManagementApp.DataAccessLayer.Abstract
{
    public interface ITaskItemDal : IGenericDal<TaskItem> {

        Task<List<TaskItem>> GetTasksByProjectIdAsync(int projectId);
        Task<List<TaskItem>> GetTasksByUserIdAsync(int userId);
        Task<List<TaskItem>> GetTasksByStatusAsync(string status);
        Task<List<TaskItem>> GetOverdueTasksAsync();


    }
}
