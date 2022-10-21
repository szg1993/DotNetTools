using ExGuard.Models;
using ExGuard.Utils;
using System.Diagnostics.CodeAnalysis;

namespace ExGuard.Helpers
{
    public static class IfTrueHelpers
    {
        public static IValidatable<TObject> IfTrue<TObject>(
            [NotNull] this IValidatable<TObject> validatable,
            Func<TObject, bool> func)
            => Validate(validatable, func: func, message: null, exceptionType: null);

        public static IValidatable<TObject> IfTrue<TObject>(
            [NotNull] this IValidatable<TObject> validatable,
            Func<TObject, bool> func,
            string message)
            => Validate(validatable, func: func, message: message, exceptionType: null);

        public static IValidatable<TObject> IfTrue<TObject>(
            [NotNull] this IValidatable<TObject> validatable,
            Func<TObject, bool> func,
            Type exceptionType)
            => Validate(validatable, func: func, message: null, exceptionType: exceptionType);

        public static IValidatable<TObject> IfTrue<TObject>(
            [NotNull] this IValidatable<TObject> validatable,
            Func<TObject, bool> func,
            string message,
            Type exceptionType)
            => Validate(validatable, func: func, message: message, exceptionType: exceptionType);

        private static IValidatable<TObject> Validate<TObject>(
            [NotNull] this IValidatable<TObject> validatable,
            Func<TObject, bool> func,
            string message,
            Type exceptionType)
        {
            if (func.Invoke(validatable.Value))
                throw ExceptionHandler.GetException(message: message, exceptionType: exceptionType);

            return validatable;
        }
    }
}