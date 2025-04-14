using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.DataAccessLayer.Abstract;
using TaskManagementApp.EntityLayer.Entities;

namespace TaskManagementApp.BusinessLayer.Concrete
{
    public class UserManager : GenericManager<User>, IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal) : base(userDal)
        {
            _userDal = userDal;
        }

        public async Task<List<User>> GetAllWithRoleAsync()
        {
            return await _userDal.GetAllWithRoleAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
           return await _userDal.GetByEmailAsync(email);
        }

        public async Task<User> GetByIdWithRoleAsync(int id)
        {
            return await _userDal.GetByIdWithRoleAsync(id);
        }
        public async Task<User> GetUserWithAssignedTasksAsync(int id)
        {
            return await _userDal.GetUserWithAssignedTasksAsync(id);
        }

        public async Task<(int taskCount, int commentCount)> GetUserActivitySummaryAsync(int id)
        {
            return await _userDal.GetUserActivitySummaryAsync(id);
        }

    }
}
