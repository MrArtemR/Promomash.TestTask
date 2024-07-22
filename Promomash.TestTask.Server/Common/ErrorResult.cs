using Newtonsoft.Json;
using Promomash.TestTask.Domain.Common;

namespace Promomash.TestTask.Server.Common
{
    public class ErrorResult
    {
        [JsonProperty]
        public ErrorCode? ErrorCode { get; private set; }
        [JsonProperty]
        public string ErrorMessage { get; private set; }
        [JsonProperty]
        public List<ValidationError> ValidationErrors { get; private set; }

        public ErrorResult(ErrorCode? errorCode)
            : this(errorCode, [])
        {
        }

        public ErrorResult(ErrorCode? errorCode, IEnumerable<ValidationItemModel> validationErrors, string errorMessage = null)
        {
            ErrorCode = errorCode;
            ErrorMessage = string.IsNullOrEmpty(errorMessage) ? (errorCode?.ToString() ?? string.Empty) : errorMessage;
            ValidationErrors = validationErrors?
                .Select(e => new ValidationError(e.Name, e.Message, e.Index))
                .ToList() ?? [];
        }
    }

    public class ValidationError
    {
        public string Name { get; }
        public string Message { get; }
        public int? Index { get; }

        public ValidationError(string name, string message, int? index = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Can't be null or empty.", nameof(name));
            }

            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException("Can't be null or empty.", nameof(message));
            }

            Name = name;
            Message = message;
            Index = index;
        }
    }
}
