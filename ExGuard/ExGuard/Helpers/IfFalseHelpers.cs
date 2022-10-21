using ExGuard.Models;
using ExGuard.Utils;
using System.Diagnostics.CodeAnalysis;

namespace ExGuard.Helpers
{
    public static class IfFalseHelpers
    {
        public static IValidatable<TObject> IfFalse<TObject>(
            [NotNull] this IValidatable<TObject> validatable,
            Func<IValidatable<TObject>, bool> func) 
            where TObject : class
            => Validate(validatable, func: func, message: null, exceptionType: null);

        public static IValidatable<TObject> IfFalse<TObject>(
            [NotNull] this IValidatable<TObject> validatable, 
            Func<IValidatable<TObject>, bool> func, 
            string message) 
            where TObject : class
            => Validate(validatable, func: func, message: message, exceptionType: null);

        public static IValidatable<TObject> IfFalse<TObject>(
            [NotNull] this IValidatable<TObject> validatable,
            Func<IValidatable<TObject>, bool> func,
            Type exceptionType)
            where TObject : class
            => Validate(validatable, func: func, message: null, exceptionType: exceptionType);

        public static IValidatable<TObject> IfFalse<TObject>(
            [NotNull] this IValidatable<TObject> validatable,
            Func<IValidatable<TObject>, bool> func,
            string message,
            Type exceptionType) where TObject : class
            => Validate(validatable, func: func, message: message, exceptionType: exceptionType);

        private static IValidatable<TObject> Validate<TObject>(
            [NotNull] this IValidatable<TObject> validatable,
            Func<IValidatable<TObject>, bool> func,
            string message,
            Type exceptionType) where TObject : class
        {
            if (!func.Invoke(validatable))
                throw ExceptionHandler.GetException(message: message, exceptionType: exceptionType);

            return validatable;
        }
    }
}