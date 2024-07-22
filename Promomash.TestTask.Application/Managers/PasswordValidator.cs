using Promomash.TestTask.Application.Interfaces;
using System.Text.RegularExpressions;

namespace Promomash.TestTask.Application.Managers
{
    internal class PasswordValidator : IPasswordValidator
    {
        public bool Validate(string password) =>
             Regex.IsMatch(password, @"^(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{2,}$");
    }
}
