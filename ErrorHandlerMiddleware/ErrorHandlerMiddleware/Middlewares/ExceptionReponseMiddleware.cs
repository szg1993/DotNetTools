using ErrorHandlerMiddleware.Exceptions;
using ErrorHandlerMiddleware.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Globalization;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace ErrorHandlerMiddleware.Middlewares
{
    public class ExceptionReponseMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionReponseMiddleware(RequestDelegate next)
            => this.next = next;

        public async Task Invoke(
            HttpContext httpContext,
            ILogger<ExceptionReponseMiddleware> logger)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception e)
            {
                var response = httpContext.Response;
                response.ContentType = "application/json";

                response.StatusCode = e is HttpResponseException hre
                    ? hre.HttpStatusCode
                    : StatusCodes.Status500InternalServerError;

                string[] errorMessages = string
                    .Format(new CultureInfo("hu-HU"), e?.Message.Replace("{", "").Replace("}", ""))
                    .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

                string result = JsonSerializer.Serialize(
                    new ErrorResponse(errorMessages, e!.GetType().Name), 
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                        WriteIndented = true
                    });

                await Task.WhenAll(
                    Task.Run(() => logger.LogError(result)),
                    Task.Run(() => response.WriteAsync(result)));
            }
        }
    }
}