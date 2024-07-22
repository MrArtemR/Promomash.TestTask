using Promomash.TestTask.Domain.Common;
using System.Text.RegularExpressions;

namespace Promomash.TestTask.Domain.Values
{
    public record Login : ValueObject
    {
        public string Value { get; init; }

        public static Result<Login> Create(string value)
        {
            value = value.Trim();

            if (string.IsNullOrEmpty(value))
            {
                return Result<Login>.Fail(ErrorCode.ValidationError, "Login cannot be empty");
            }

            if (Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$") is false)
            {
                return Result<Login>.Fail(ErrorCode.ValidationError, "Login must be valid email");
            }

            return Result<Login>.Ok(new Login(value));
        }

        private Login(string value) =>
            Value = value;

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
