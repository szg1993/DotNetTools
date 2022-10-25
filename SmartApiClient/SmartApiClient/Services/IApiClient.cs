namespace SmartApiClient.Services
{
    public interface IApiClient
    {
        Task<TReturn> GetAsync<TReturn>(
            string url,
            CancellationToken cancellationToken = default);

        Task<TReturn> GetAsync<TReturn, TRequestContent>(
            string url,
            TRequestContent requestContent,
            CancellationToken cancellationToken = default);

        Task<bool> PostAsync(
            string url,
            CancellationToken cancellationToken = default);

        Task<bool> PostAsync<TRequestContent>(
            string url,
            TRequestContent requestContent,
            CancellationToken cancellationToken = default);

        Task<TReturn> PostAsync<TReturn>(
            string url,
            CancellationToken cancellationToken = default);

        Task<TReturn> PostAsync<TReturn, TRequestContent>(
            string url,
            TRequestContent requestContent,
            CancellationToken cancellationToken = default);
    }
}