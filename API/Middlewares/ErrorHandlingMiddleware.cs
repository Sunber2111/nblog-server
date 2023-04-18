using System;
using Elasticsearch.Net;
using Newtonsoft.Json;

namespace API.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, _logger);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex, ILogger<ErrorHandlingMiddleware> logger)
        {
            object errors = null;

            switch (ex)
            {
                case ApplicationException e:
                    errors = new { status = "Fail", message = string.IsNullOrWhiteSpace(e.Message) ? "Error" : e.Message };
                    context.Response.StatusCode = 400;
                    break;
                case Exception e:
                    _logger.LogError(e.Message, "SERVER ERROR");
                    errors = new { status = "Fail", message = string.IsNullOrWhiteSpace(e.Message) ? "Error" : e.Message };
                    context.Response.StatusCode = 500;
                    break;
            }

            context.Response.ContentType = "application/json";

            if (errors != null)
            {
                var result = JsonConvert.SerializeObject(errors);

                await context.Response.WriteAsync(result);
            }

        }
    }
}

