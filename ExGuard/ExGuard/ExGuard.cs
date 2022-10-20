using System.Diagnostics.CodeAnalysis;

namespace ExGuard
{
    public static class ExGuard
    {
        public static TValidable ThrowIfNull<TValidable>([NotNull] this TValidable param)
        {
            return RaiseIfNull(param, message: null, exceptionType: null);
        }

        public static TValidable ThrowIfNull<TValidable>([NotNull] this TValidable param, string message)
        {
            return RaiseIfNull(param, message: message, exceptionType: null);
        }

        public static TValidable ThrowIfNull<TValidable>([NotNull] this TValidable param, Type exceptionType)
        {
            return RaiseIfNull(param, message: null, exceptionType: exceptionType);
        }

        public static TValidable ThrowIfNull<TValidable>([NotNull] this TValidable param, string message, Type exceptionType)
        {
            return RaiseIfNull(param, message, exceptionType);
        }

        private static TValidable RaiseIfNull<TValidable>([NotNull] this TValidable param, string message, Type exceptionType)
        {
            if (param != null)
                return param;

            throw GetException(message: message, exceptionType: exceptionType);
        }

        public static IEnumerable<TValidable> ThrowIfNullOrEmpty<TValidable>([NotNull] this IEnumerable<TValidable> param)
        {
            return RaiseIfNullOrEmpty(param, message: null, exceptionType: null);
        }

        public static IEnumerable<TValidable> ThrowIfNullOrEmpty<TValidable>([NotNull] this IEnumerable<TValidable> param, string message)
        {
            return RaiseIfNullOrEmpty(param, message: message, exceptionType: null);
        }

        public static IEnumerable<TValidable> ThrowIfNullOrEmpty<TValidable>([NotNull] this IEnumerable<TValidable> param, Type exceptionType)
        {
            return RaiseIfNullOrEmpty(param, message: null, exceptionType: exceptionType);
        }

        public static IEnumerable<TValidable> ThrowIfNullOrEmpty<TValidable>([NotNull] this IEnumerable<TValidable> param, string message, Type exceptionType)
        {
            return RaiseIfNullOrEmpty(param, message, exceptionType);
        }

        private static IEnumerable<TValidable> RaiseIfNullOrEmpty<TValidable>([NotNull] this IEnumerable<TValidable> param, string message, Type exceptionType)
        {
            if (param != null && param.Any())
                return param;

            throw GetException(message: message, exceptionType: exceptionType);
        }

        private static Exception GetException(string message = null, Type exceptionType = null)
        {
            string defaultMessage = "Default message comes here";

            if (!string.IsNullOrEmpty(message) && exceptionType != null)
                return (Exception)Activator.CreateInstance(exceptionType, message);

            if (string.IsNullOrEmpty(message) && exceptionType != null)
                return (Exception)Activator.CreateInstance(exceptionType, defaultMessage);

            if (!string.IsNullOrEmpty(message) && exceptionType == null)
                return new ArgumentException(message);

            return new ArgumentException(defaultMessage); //Todo: itt is tudjon valami default messaget-t
        }

        //public static TValidable ThrowIfNull<TValidable>([NotNull] this TValidable param, Func<Exception> customException = null, string message = null)
        //{
        //    if (param != null)
        //        return param;

        //    if (customException != null)
        //        throw customException.Invoke();

        //    if (!string.IsNullOrEmpty(message))
        //        throw new ArgumentNullException(message);

        //    throw new ArgumentNullException(DefaultMessages.ArgumentWasNull);
        //}

        //public static IEnumerable<TValidable> ThrowIfNullOrEmpty<TValidable>(
        //    [NotNull] this IEnumerable<TValidable> param,
        //    Func<Exception> customException = null,
        //    string message = null)
        //{
        //    if (param != null && param.Any())
        //        return param;

        //    //throw GetException();

        //    if (customException != null)
        //        throw customException.Invoke();

        //    if (!string.IsNullOrEmpty(message))
        //        throw new ArgumentException(message);

        //    throw new ArgumentException(DefaultMessages.ArgumentListWasNullOrEmpty);
        //}

        //private static Exception GetException(Func<Exception> customException = null, string message = null)
        //{
        //    if (customException != null)
        //        throw customException.Invoke();

        //    if (!string.IsNullOrEmpty(message))
        //        throw new ArgumentNullException(message);

        //    throw new ArgumentNullException(DefaultMessages.ArgumentWasNull);
        //}

        //private static Exception GetException(string message, Type type)
        //    => (Exception)Activator.CreateInstance(type, message);

        //private static Exception GetException<TException>(string message) where TException : Exception, new()
        //    => (TException)Activator.CreateInstance(typeof(TException), message);
    }
}