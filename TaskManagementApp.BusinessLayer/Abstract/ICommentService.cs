using TaskManagementApp.EntityLayer.Entities;

namespace TaskManagementApp.BusinessLayer.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
        Task<List<Comment>> GetCommentsWithUserByTaskItemIdAsync(int taskItemId);

    }
}
