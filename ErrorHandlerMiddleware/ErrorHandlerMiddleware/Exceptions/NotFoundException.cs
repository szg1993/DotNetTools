using Microsoft.AspNetCore.Http;

namespace ErrorHandlerMiddleware.Exceptions
{
    public class NotFoundException : HttpResponseException
    {
        public NotFoundException(string message)
            : base(message, StatusCodes.Status404NotFound)
        { }
    }
}