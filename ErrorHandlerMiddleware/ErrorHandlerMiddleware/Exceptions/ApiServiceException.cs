using Microsoft.AspNetCore.Http;

namespace ErrorHandlerMiddleware.Exceptions
{
    public class ApiServiceException : HttpResponseException
    {
        public ApiServiceException(string message)
            : base(message, StatusCodes.Status500InternalServerError)
        { }
    }
}