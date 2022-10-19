using ExGuard.Constants;
using System.Diagnostics.CodeAnalysis;

namespace ExGuard
{
    public static class ExGuard
    {
        public static TValidable ThrowIfNull<TValidable>([NotNull] this TValidable param, Func<Exception> customException = null, string message = null)
        {
            if (param != null)
                return param;

            if (customException != null)
                throw customException.Invoke();

            if (!string.IsNullOrEmpty(message))
                throw new ArgumentNullException(message);

            throw new ArgumentNullException(DefaultMessages.ArgumentWasNull);
        }

        public static IEnumerable<TValidable> ThrowIfNullOrEmpty<TValidable>(
            [NotNull] this IEnumerable<TValidable> param,
            Func<Exception> customException = null,
            string message = null)
        {
            if (param != null && param.Any())
                return param;

            //throw GetException();

            if (customException != null)
                throw customException.Invoke();

            if (!string.IsNullOrEmpty(message))
                throw new ArgumentException(message);

            throw new ArgumentException(DefaultMessages.ArgumentListWasNullOrEmpty);
        }

        private static Exception GetException(Func<Exception> customException = null, string message = null)
        {
            if (customException != null)
                throw customException.Invoke();

            if (!string.IsNullOrEmpty(message))
                throw new ArgumentNullException(message);

            throw new ArgumentNullException(DefaultMessages.ArgumentWasNull);
        }

        //private static Exception GetException(string message, Type type)
        //    => (Exception)Activator.CreateInstance(type, message);

        //private static Exception GetException<TException>(string message) where TException : Exception, new()
        //    => (TException)Activator.CreateInstance(typeof(TException), message);
    }
}