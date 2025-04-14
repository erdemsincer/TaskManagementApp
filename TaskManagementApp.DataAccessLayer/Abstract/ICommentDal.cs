using TaskManagementApp.EntityLayer.Entities;

namespace TaskManagementApp.DataAccessLayer.Abstract
{
    public interface ICommentDal : IGenericDal<Comment>
    {
        Task<List<Comment>> GetCommentsWithUserByTaskItemIdAsync(int taskItemId);

    }
}
