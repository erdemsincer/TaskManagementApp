using TaskManagementApp.EntityLayer.Entities;

namespace TaskManagementApp.BusinessLayer.Services.Security
{
    public interface IJwtService
    {
        string CreateToken(User user);
    }
}
