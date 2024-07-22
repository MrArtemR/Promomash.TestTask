using Promomash.TestTask.Application.Interfaces;
using System.Text;
using XSystem.Security.Cryptography;

namespace Promomash.TestTask.Application.Managers
{
    internal class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            var data = Encoding.ASCII.GetBytes(password);
            return BitConverter.ToString(md5.ComputeHash(data));
        }
    }
}
