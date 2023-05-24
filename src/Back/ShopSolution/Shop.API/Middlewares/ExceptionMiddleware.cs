using Shop.API.Errors;
using Shop.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace Shop.API.Middlewares
{
    public class ExceptionMiddleware 
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                int statusCode = (int)HttpStatusCode.InternalServerError;
                var result = string.Empty;

                switch (ex)
                {
                    case NotFoundExecption notFoundExecption:
                        statusCode = (int)HttpStatusCode.NotFound;
                        break;

                    case FluentValidation.ValidationException fluentValidation:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        var errors = fluentValidation.Errors.Select(x => x.ErrorMessage).ToArray();
                        result = JsonSerializer.Serialize(new CodeErrorException(statusCode, errors));
                        break;

                    case BadRequestException badRequestException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        break;
                }

                if (string.IsNullOrEmpty(result))
                {
                    result = JsonSerializer.Serialize(new CodeErrorException(statusCode, new string[] { ex.Message }, ex.StackTrace));
                }

                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsync(result);
            }
        }
    }
}
