using SmartApiClient.Exceptions;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading;

namespace SmartApiClient.Services
{
    public abstract class ApiClient : IApiClient
    {
        protected HttpClient httpClient;
        protected JsonSerializerOptions jsonSerializerOptions;
        protected virtual string DefaultApiCallError
            => "An unexpected error has occured during the server call.";

        public ApiClient(IHttpClientFactory httpClientFactory)
        {
            SetHttpClient(httpClientFactory);
        }

        public async Task<bool> PostAsync(
            string url,
            CancellationToken cancellationToken = default)
        {
            return await GetHttpResponseMessage1(new HttpRequestMessage(HttpMethod.Post, url), cancellationToken);
        }

        public async Task<bool> PostAsync<TObjectToPost>(string url,
            TObjectToPost objectToPost,
            CancellationToken cancellationToken)
        {
            return await GetHttpResponseMessage1(GetHttpRequestMessage(url, objectToPost), cancellationToken);
        }

        public async Task<TReturnObject> PostAsync<TReturnObject>(
            string url,
            CancellationToken cancellationToken = default)
        {
            return DeserializeResponse<TReturnObject>(
                await GetHttpResponseMessage(GetHttpRequestMessage(url),
                cancellationToken));
        }

        public async Task<TReturnObject> PostAsync<TReturnObject, TObjectToPost>(
            string url,
            TObjectToPost objectToPost,
            CancellationToken cancellationToken = default)
        {
            return DeserializeResponse<TReturnObject>(
                await GetHttpResponseMessage(GetHttpRequestMessage(url, objectToPost), cancellationToken));
        }

        #region ProtectedMembers

        protected virtual Uri SetBaseUrl()
            => new UriBuilder
            {
                Host = "localhost",
                Scheme = "https",
                Port = 8080
            }
            .Uri;

        protected virtual JsonSerializerOptions GetJsonSerializerOptions()
            => new()
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            };

        #endregion

        #region PrivateMethods

        private void SetHttpClient(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient();
            httpClient.BaseAddress = SetBaseUrl();
        }

        private HttpRequestMessage GetHttpRequestMessage(string url, object objectToPost = null)
        {
            if (objectToPost == null)
                return new HttpRequestMessage(HttpMethod.Post, url);

            return new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(
                    JsonSerializer.Serialize(objectToPost, GetJsonSerializerOptions()),
                    Encoding.UTF8,
                    "application/json")
            };
        }

        private async Task<bool> GetHttpResponseMessage1(
            HttpRequestMessage httpRequestMessage,
            CancellationToken cancellationToken)
        {
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage, cancellationToken);        

            if (!httpResponseMessage.IsSuccessStatusCode)
                throw new ApiClientException(await GetErrorMessageAsync(httpResponseMessage, cancellationToken));

            return true;
        }

        private async Task<string> GetHttpResponseMessage(
            HttpRequestMessage httpRequestMessage,
            CancellationToken cancellationToken)
        {
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage, cancellationToken);

            if (!httpResponseMessage.IsSuccessStatusCode)
                throw new ApiClientException(await GetErrorMessageAsync(httpResponseMessage, cancellationToken));

            return await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);
        }

        private TReturnObject DeserializeResponse<TReturnObject>(string responseMessage)
        {
            return !string.IsNullOrWhiteSpace(responseMessage)
                ? JsonSerializer.Deserialize<TReturnObject>(responseMessage)
                : default;
        }

        private async Task<string> GetErrorMessageAsync(
            HttpResponseMessage httpResponseMessage,
            CancellationToken cancellationToken)
        {
            string responseMessage = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);

            if (string.IsNullOrEmpty(responseMessage))
                return DefaultApiCallError;

            return responseMessage;
        }

        #endregion
    }
}