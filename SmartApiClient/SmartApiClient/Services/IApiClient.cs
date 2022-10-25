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

        Task<bool> PutAsync(
            string url,
            CancellationToken cancellationToken = default);

        Task<bool> PutAsync<TRequestContent>(
            string url,
            TRequestContent requestContent,
            CancellationToken cancellationToken = default);

        Task<TReturn> PutAsync<TReturn>(
            string url,
            CancellationToken cancellationToken = default);

        Task<TReturn> PutAsync<TReturn, TRequestContent>(
            string url,
            TRequestContent requestContent,
            CancellationToken cancellationToken = default);

        Task<bool> PatchAsync(
            string url,
            CancellationToken cancellationToken = default);

        Task<bool> PatchAsync<TRequestContent>(
            string url,
            TRequestContent requestContent,
            CancellationToken cancellationToken = default);

        Task<TReturn> PatchAsync<TReturn>(
            string url,
            CancellationToken cancellationToken = default);

        Task<TReturn> PatchAsync<TReturn, TRequestContent>(
            string url,
            TRequestContent requestContent,
            CancellationToken cancellationToken = default);
    }
}