using Games_Storage.Core.Services.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Text;

namespace Games_Storage.Presentation.ExceptionHendler
{
    internal class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandler> _logger;

        public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                var statusCode = StatusCodes.Status500InternalServerError;
                _logger.LogError(error.HResult, error, "An error has occurred");

                switch (error)
                {
                    case ConflictException:
                        statusCode = StatusCodes.Status409Conflict;
                        break;
                    case NotFoundException:
                        statusCode = StatusCodes.Status404NotFound;
                        break;
                    case BadRequestException:
                        statusCode = StatusCodes.Status400BadRequest;
                        break;
                }

                response.StatusCode = statusCode;
                var content = Encoding.UTF8.GetBytes($"Error [{error.Message}]");
                await response.Body.WriteAsync(content, 0, content.Length);
            }
        }

    }
}
