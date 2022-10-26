namespace ExGuard.Utils
{
    internal static class ExceptionHandler
    {
        internal static Exception GetException(string message = null, Type customExceptionType = null)
        {
            if (!string.IsNullOrEmpty(message) && customExceptionType != null)
                return (Exception)Activator.CreateInstance(customExceptionType, message);

            if (!string.IsNullOrEmpty(message) && customExceptionType == null)
                return new ArgumentException(message);
            
            string defaultMessage = "This is a default message for the exception.";
            
            if (string.IsNullOrEmpty(message) && customExceptionType != null)
                return (Exception)Activator.CreateInstance(customExceptionType, defaultMessage);

            return new ArgumentException(defaultMessage);
        }
    }
}