using ExGuard.Utils;
using System.Diagnostics.CodeAnalysis;

namespace ExGuard.Helpers
{
    public static class LesserThan
    {
        public static int ThrowIfLesser([NotNull] this int validatable, int limit)
            => ValidateInt(validatable, limit: limit, message: null, exceptionType: null);

        public static int ThrowIfLesser([NotNull] this int validatable, int limit, string message)
            => ValidateInt(validatable, limit: limit, message: message, exceptionType: null);

        public static int ThrowIfLesser([NotNull] this int validatable, int limit, Type exceptionType)
            => ValidateInt(validatable, limit: limit, message: null, exceptionType: exceptionType);

        public static int ThrowIfLesser([NotNull] this int validatable, int limit, string message, Type exceptionType)
            => ValidateInt(validatable, limit: limit, message: message, exceptionType: exceptionType);

        public static double ThrowIfLesser([NotNull] this double validatable, double limit)
            => ValidateDouble(validatable, limit: limit, message: null, exceptionType: null);

        public static double ThrowIfLesser([NotNull] this double validatable, double limit, string message)
            => ValidateDouble(validatable, limit: limit, message: message, exceptionType: null);

        public static double ThrowIfLesser([NotNull] this double validatable, double limit, Type exceptionType)
            => ValidateDouble(validatable, limit: limit, message: null, exceptionType: exceptionType);

        public static double ThrowIfLesser([NotNull] this double validatable, double limit, string message, Type exceptionType)
            => ValidateDouble(validatable, limit: limit, message: message, exceptionType: exceptionType);

        public static double ThrowIfLesser([NotNull] this float validatable, float limit)
            => ValidateFloat(validatable, limit: limit, message: null, exceptionType: null);

        public static double ThrowIfLesser([NotNull] this float validatable, float limit, string message)
            => ValidateFloat(validatable, limit: limit, message: message, exceptionType: null);

        public static double ThrowIfLesser([NotNull] this float validatable, float limit, Type exceptionType)
            => ValidateFloat(validatable, limit: limit, message: null, exceptionType: exceptionType);

        public static double ThrowIfLesser([NotNull] this float validatable, float limit, string message, Type exceptionType)
            => ValidateFloat(validatable, limit: limit, message: message, exceptionType: exceptionType);

        private static int ValidateInt([NotNull] this int validatable, int limit, string message, Type exceptionType)
        {
            if (validatable >= limit)
                return validatable;

            throw ExceptionHandler.GetException(message: message, exceptionType: exceptionType);
        }

        private static double ValidateDouble([NotNull] this double validatable, double limit, string message, Type exceptionType)
        {
            if (validatable >= limit)
                return validatable;

            throw ExceptionHandler.GetException(message: message, exceptionType: exceptionType);
        }

        private static double ValidateFloat([NotNull] this float validatable, float limit, string message, Type exceptionType)
        {
            if (validatable >= limit)
                return validatable;

            throw ExceptionHandler.GetException(message: message, exceptionType: exceptionType);
        }
    }
}