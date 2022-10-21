using Microsoft.AspNetCore.Http;

namespace ErrorHandlerMiddleware.Exceptions
{
    public class BadRequestException : HttpResponseException
    {
        public BadRequestException(string message)
            : base(message, StatusCodes.Status400BadRequest)
        { }
    }
}