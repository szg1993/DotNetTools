namespace ExGuard.Models
{
    public interface IValidable<TValue>
    {
        TValue Value { get; }
    }
}