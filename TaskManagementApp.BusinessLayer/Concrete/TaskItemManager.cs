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
    }
    
}
