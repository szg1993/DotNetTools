using ExGuard.Utils;
using System.Diagnostics.CodeAnalysis;

namespace ExGuard.Helpers
{
    public static class IfNullOrEmpty
    {
        public static IEnumerable<TValidable> ThrowIfNullOrEmpty<TValidable>([NotNull] this IEnumerable<TValidable> param)
            => Validate(param, message: null, exceptionType: null);

        public static IEnumerable<TValidable> ThrowIfNullOrEmpty<TValidable>([NotNull] this IEnumerable<TValidable> param, string message)
            => Validate(param, message: message, exceptionType: null);

        public static IEnumerable<TValidable> ThrowIfNullOrEmpty<TValidable>([NotNull] this IEnumerable<TValidable> param, Type exceptionType)
            => Validate(param, message: null, exceptionType: exceptionType);

        public static IEnumerable<TValidable> ThrowIfNullOrEmpty<TValidable>([NotNull] this IEnumerable<TValidable> param, string message, Type exceptionType)
            => Validate(param, message, exceptionType);

        private static IEnumerable<TValidable> Validate<TValidable>([NotNull] this IEnumerable<TValidable> param, string message, Type exceptionType)
        {
            if (param != null && param.Any())
                return param;

            throw ExceptionHandler.GetException(message: message, exceptionType: exceptionType);
        }
    }
}
