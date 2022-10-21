using ExGuard.Models;
using System.Diagnostics.CodeAnalysis;

namespace ExGuard.Helpers
{
    public static class Throw2
    {
        public static IValidatable<TValidatable> Throw<TValidatable>([NotNull] this TValidatable validatable)
            => new Validatable<TValidatable>(validatable);
    }
}