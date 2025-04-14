using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.DataAccessLayer.Abstract;
using TaskManagementApp.EntityLayer.Entities;

namespace TaskManagementApp.BusinessLayer.Concrete
{
    public class TaskItemManager : GenericManager<TaskItem>, ITaskItemService
    {
        private readonly ITaskItemDal _taskItemDal;

        public TaskItemManager(ITaskItemDal taskItemDal) : base(taskItemDal)
        {
            _taskItemDal = taskItemDal;
        }

        public async Task<List<TaskItem>> GetTasksByProjectIdAsync(int projectId)
        {
            return await _taskItemDal.GetTasksByProjectIdAsync(projectId);
        }

        public async Task<List<TaskItem>> GetTasksByUserIdAsync(int userId)
        {
            return await _taskItemDal.GetTasksByUserIdAsync(userId);
        }

        public async Task<List<TaskItem>> GetTasksByStatusAsync(string status)
        {
            return await _taskItemDal.GetTasksByStatusAsync(status);
        }

        public async Task<List<TaskItem>> GetOverdueTasksAsync()
        {
            return await _taskItemDal.GetOverdueTasksAsync();
        }
    }

}
