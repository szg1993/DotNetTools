namespace SmartApiClient.Services
{
    public interface IApiClient
    {
        Task<bool> PostAsync(
            string url,
            CancellationToken cancellationToken = default);

        Task<bool> PostAsync<TObjectToPost>(
            string url,
            TObjectToPost objectToPost,
            CancellationToken cancellationToken = default);

        Task<TReturnObject> PostAsync<TReturnObject>(
            string url,
            CancellationToken cancellationToken = default);

        Task<TReturnObject> PostAsync<TReturnObject, TObjectToPost>(
            string url,
            TObjectToPost objectToPost,
            CancellationToken cancellationToken = default);
    }
}