using System.Security.Cryptography;
using System.Text;

namespace TaskManagementApp.BusinessLayer.Services.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Hash(string plainText)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(plainText));
            return BitConverter.ToString(bytes).Replace("-", "").ToLowerInvariant();
        }
    }
}
