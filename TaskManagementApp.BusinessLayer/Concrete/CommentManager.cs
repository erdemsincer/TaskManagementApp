using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.DataAccessLayer.Abstract;
using TaskManagementApp.EntityLayer.Entities;

namespace TaskManagementApp.BusinessLayer.Concrete
{
    public class CommentManager : GenericManager<Comment>, ICommentService
    {
        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal) : base(commentDal)
        {
            _commentDal = commentDal;
        }

        public async Task<List<Comment>> GetCommentsWithUserByTaskItemIdAsync(int taskItemId)
        {
            return await _commentDal.GetCommentsWithUserByTaskItemIdAsync(taskItemId);
        }

    }
}
