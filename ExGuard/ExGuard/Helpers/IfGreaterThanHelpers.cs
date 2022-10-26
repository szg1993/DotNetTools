using ExGuard.Models;
using ExGuard.Utils;
using System.Diagnostics.CodeAnalysis;

namespace ExGuard.Helpers
{
    public static class IfGreaterThanHelpers
    {
        public static IValidatable<int> IfGreaterThan([NotNull] this IValidatable<int> validatable, int limit)
            => ValidateInt(validatable, limit: limit, message: null, exceptionType: null);

        public static IValidatable<int> IfGreaterThan([NotNull] this IValidatable<int> validatable, int limit, string message)
            => ValidateInt(validatable, limit: limit, message: message, exceptionType: null);

        public static IValidatable<int> IfGreaterThan([NotNull] this IValidatable<int> validatable, int limit, Type exceptionType)
            => ValidateInt(validatable, limit: limit, message: null, exceptionType: exceptionType);

        public static IValidatable<int> IfGreaterThan([NotNull] this IValidatable<int> validatable, int limit, string message, Type exceptionType)
            => ValidateInt(validatable, limit: limit, message: message, exceptionType: exceptionType);

        public static IValidatable<double> IfGreaterThan([NotNull] this IValidatable<double> validatable, double limit)
            => ValidateDouble(validatable, limit: limit, message: null, exceptionType: null);

        public static IValidatable<double> IfGreaterThan([NotNull] this IValidatable<double> validatable, double limit, string message)
            => ValidateDouble(validatable, limit: limit, message: message, exceptionType: null);

        public static IValidatable<double> IfGreaterThan([NotNull] this IValidatable<double> validatable, double limit, Type exceptionType)
            => ValidateDouble(validatable, limit: limit, message: null, exceptionType: exceptionType);

        public static IValidatable<double> IfGreaterThan([NotNull] this IValidatable<double> validatable, double limit, string message, Type exceptionType)
            => ValidateDouble(validatable, limit: limit, message: message, exceptionType: exceptionType);

        public static IValidatable<float> IfGreaterThan([NotNull] this IValidatable<float> validatable, float limit)
            => ValidateFloat(validatable, limit: limit, message: null, exceptionType: null);

        public static IValidatable<float> IfGreaterThan([NotNull] this IValidatable<float> validatable, float limit, string message)
            => ValidateFloat(validatable, limit: limit, message: message, exceptionType: null);

        public static IValidatable<float> IfGreaterThan([NotNull] this IValidatable<float> validatable, float limit, Type exceptionType)
            => ValidateFloat(validatable, limit: limit, message: null, exceptionType: exceptionType);

        public static IValidatable<float> IfGreaterThan([NotNull] this IValidatable<float> validatable, float limit, string message, Type exceptionType)
            => ValidateFloat(validatable, limit: limit, message: message, exceptionType: exceptionType);

        public static IValidatable<int?> IfGreaterThan([NotNull] this IValidatable<int?> validatable, int limit)
            => ValidateNullableInt(validatable, limit: limit, message: null, exceptionType: null);

        public static IValidatable<int?> IfGreaterThan([NotNull] this IValidatable<int?> validatable, int limit, string message)
            => ValidateNullableInt(validatable, limit: limit, message: message, exceptionType: null);

        public static IValidatable<int?> IfGreaterThan([NotNull] this IValidatable<int?> validatable, int limit, Type exceptionType)
            => ValidateNullableInt(validatable, limit: limit, message: null, exceptionType: exceptionType);

        public static IValidatable<int?> IfGreaterThan([NotNull] this IValidatable<int?> validatable, int limit, string message, Type exceptionType)
            => ValidateNullableInt(validatable, limit: limit, message: message, exceptionType: exceptionType);

        public static IValidatable<double?> IfGreaterThan([NotNull] this IValidatable<double?> validatable, double limit)
            => ValidateNullableDouble(validatable, limit: limit, message: null, exceptionType: null);

        public static IValidatable<double?> IfGreaterThan([NotNull] this IValidatable<double?> validatable, double limit, string message)
            => ValidateNullableDouble(validatable, limit: limit, message: message, exceptionType: null);

        public static IValidatable<double?> IfGreaterThan([NotNull] this IValidatable<double?> validatable, double limit, Type exceptionType)
            => ValidateNullableDouble(validatable, limit: limit, message: null, exceptionType: exceptionType);

        public static IValidatable<double?> IfGreaterThan([NotNull] this IValidatable<double?> validatable, double limit, string message, Type exceptionType)
            => ValidateNullableDouble(validatable, limit: limit, message: message, exceptionType: exceptionType);

        public static IValidatable<float?> IfGreaterThan([NotNull] this IValidatable<float?> validatable, float limit)
            => ValidateNullableFloat(validatable, limit: limit, message: null, exceptionType: null);

        public static IValidatable<float?> IfGreaterThan([NotNull] this IValidatable<float?> validatable, float limit, string message)
            => ValidateNullableFloat(validatable, limit: limit, message: message, exceptionType: null);

        public static IValidatable<float?> IfGreaterThan([NotNull] this IValidatable<float?> validatable, float limit, Type exceptionType)
            => ValidateNullableFloat(validatable, limit: limit, message: null, exceptionType: exceptionType);

        public static IValidatable<float?> IfGreaterThan([NotNull] this IValidatable<float?> validatable, float limit, string message, Type exceptionType)
            => ValidateNullableFloat(validatable, limit: limit, message: message, exceptionType: exceptionType);

        private static IValidatable<int> ValidateInt([NotNull] this IValidatable<int> validatable, int limit, string message, Type exceptionType)
        {
            if (validatable.Value > limit)
                throw ExceptionHandler.GetException(message: message, customExceptionType: exceptionType);

            return validatable;
        }

        private static IValidatable<double> ValidateDouble([NotNull] this IValidatable<double> validatable, double limit, string message, Type exceptionType)
        {
            if (validatable.Value > limit)
                throw ExceptionHandler.GetException(message: message, customExceptionType: exceptionType);

            return validatable;
        }

        private static IValidatable<float> ValidateFloat([NotNull] this IValidatable<float> validatable, float limit, string message, Type exceptionType)
        {
            if (validatable.Value > limit)
                throw ExceptionHandler.GetException(message: message, customExceptionType: exceptionType);

            return validatable;
        }

        private static IValidatable<int?> ValidateNullableInt([NotNull] this IValidatable<int?> validatable, int limit, string message, Type exceptionType)
        {
            if (validatable.Value != null && validatable.Value > limit)
                throw ExceptionHandler.GetException(message: message, customExceptionType: exceptionType);

            return validatable;
        }

        private static IValidatable<double?> ValidateNullableDouble([NotNull] this IValidatable<double?> validatable, double limit, string message, Type exceptionType)
        {
            if (validatable.Value != null && validatable.Value > limit)
                throw ExceptionHandler.GetException(message: message, customExceptionType: exceptionType);

            return validatable;
        }

        private static IValidatable<float?> ValidateNullableFloat([NotNull] this IValidatable<float?> validatable, float limit, string message, Type exceptionType)
        {
            if (validatable.Value != null && validatable.Value > limit)
                throw ExceptionHandler.GetException(message: message, customExceptionType: exceptionType);

            return validatable;
        }
    }
}