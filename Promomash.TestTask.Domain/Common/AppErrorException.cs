namespace Promomash.TestTask.Domain.Common
{
    public class AppErrorException : Exception
    {
        public ErrorCode ErrorCode { get; private set; }

        public AppErrorException(string message, ErrorCode errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }

        public IEnumerable<ValidationItemModel> ValidationErrors { get; set; } = Array.Empty<ValidationItemModel>();
    }
}
