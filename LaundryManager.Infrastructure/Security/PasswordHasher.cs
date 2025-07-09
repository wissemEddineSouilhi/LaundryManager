using LaundryManager.Domain.Contracts.Security;
using System.Security.Cryptography;
using System.Text;

namespace LaundryManager.Infrastructure.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Hash(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = md5.ComputeHash(bytes);
                return Convert.ToHexString(hash);
            }
        }

        public bool Verify(string password, string hash)
        {
            return Hash(password).Equals(hash, StringComparison.OrdinalIgnoreCase);
        }
    }
}
