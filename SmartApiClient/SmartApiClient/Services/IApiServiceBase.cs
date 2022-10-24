namespace SmartApiClient.Services
{
    public interface IApiServiceBase
    {
        Task<string> PostAsync(
            string url,
            CancellationToken cancellationToken = default);

        Task<string> PostAsync<TObjectToPost>(
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