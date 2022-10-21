namespace ExGuard.Models
{
    public interface IValidatable<TValue>
    {
        TValue Value { get; }
    }
}