using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Promomash.TestTask.Domain.Common;
using Promomash.TestTask.Server.Common;

namespace Promomash.TestTask.Server.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;

            if (loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            _logger = loggerFactory.CreateLogger(nameof(ExceptionHandlingMiddleware));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AppErrorException appErrorException)
            {
                var result = SerializeObject(new ErrorResult(appErrorException.ErrorCode, appErrorException.ValidationErrors, appErrorException.Message));
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(result);
            }
            catch (Exception exception)
            {
                var result = SerializeObject(new ErrorResult(ErrorCode.UnknowErorr));
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(result);
            }
        }

        private static string SerializeObject(object obj)
        {
            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            return JsonConvert.SerializeObject(obj, jsonSerializerSettings);
        }
    }

    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static void UseCustomAppErrorExceptionHandling(this IApplicationBuilder app)
        {
            app.UseMiddleware(typeof(ExceptionHandlingMiddleware));
        }
    }
}
