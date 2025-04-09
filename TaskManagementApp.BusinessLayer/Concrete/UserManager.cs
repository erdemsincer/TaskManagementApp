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

        
    }
}
