using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.DataAccessLayer.Abstract;
using TaskManagementApp.EntityLayer.Entities;

namespace TaskManagementApp.BusinessLayer.Concrete
{
    public class RoleManager : GenericManager<Role>, IRoleService
    {
        private readonly IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal) : base(roleDal)
        {
            _roleDal = roleDal;
        }
   
    }
}
