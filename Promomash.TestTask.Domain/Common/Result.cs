namespace Promomash.TestTask.Domain.Common
{
    public class Result<TResult>
    {
        public virtual TResult Value { get; set; }
        public bool IsSuccess => Error == null && !ErrorCode.HasValue;
        public string Error { get; set; }
        public ErrorCode? ErrorCode { get; private set; }

        public static Result<TResult> Ok(TResult value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return new Result<TResult> { Value = value };
        }

        public static Result<TResult> Fail(ErrorCode errorCode, string error)
        {
            if (string.IsNullOrEmpty(error))
            {
                throw new ArgumentException("Can't be null or empty", nameof(error));
            }

            return new Result<TResult> { ErrorCode = errorCode, Error = error };
        }
    }

    public class ValidationItemModel
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public int? Index { get; set; }

        public ValidationItemModel(string name, string message, int? index = null)
        {
            Name = name;
            Message = message;
            Index = index;
        }
    }
}
