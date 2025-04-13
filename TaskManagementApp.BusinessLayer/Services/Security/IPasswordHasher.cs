namespace TaskManagementApp.BusinessLayer.Services.Security
{
    public interface IPasswordHasher
    {
        string Hash(string plainText);
    }
}
