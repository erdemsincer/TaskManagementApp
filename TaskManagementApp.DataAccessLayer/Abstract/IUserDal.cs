using TaskManagementApp.EntityLayer.Entities;

namespace TaskManagementApp.DataAccessLayer.Abstract
{
    public interface IUserDal : IGenericDal<User>
    {
        Task<User> GetByEmailAsync(string email);
        Task<List<User>> GetAllWithRoleAsync();  
        Task<User> GetByIdWithRoleAsync(int id);
        Task<User> GetUserWithAssignedTasksAsync(int id);
        Task<(int taskCount, int commentCount)> GetUserActivitySummaryAsync(int id);
    }
}
