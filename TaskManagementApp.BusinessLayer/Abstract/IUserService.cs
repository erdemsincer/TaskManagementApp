using TaskManagementApp.EntityLayer.Entities;

namespace TaskManagementApp.BusinessLayer.Abstract
{
    public interface IUserService : IGenericService<User>
    {
        Task<User> GetByEmailAsync(string email);
        Task<List<User>> GetAllWithRoleAsync();   // 🔥 Ekstra
        Task<User> GetByIdWithRoleAsync(int id);  // 🔥 Ekstra
    }
}
