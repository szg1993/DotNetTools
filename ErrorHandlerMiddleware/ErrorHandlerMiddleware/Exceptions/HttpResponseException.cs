namespace ErrorHandlerMiddleware.Exceptions
{
    public class HttpResponseException : Exception
    {
        public int HttpStatusCode { get; }

        public HttpResponseException(string message, int httpStatusCode)
            : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}