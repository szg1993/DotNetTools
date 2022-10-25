using SmartApiClient.Exceptions;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

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

        #region PublicMembers

        public async Task<TReturn> GetAsync<TReturn>(
            string url,
            CancellationToken cancellationToken = default)
        {
            return DeserializeResponse<TReturn>(
                await GetHttpResponseMessageContentAsync(GetHttpRequestMessage(url, HttpMethod.Get), cancellationToken));
        }

        public async Task<TReturn> GetAsync<TReturn, TRequestContent>(
            string url,
            TRequestContent requestContent,
            CancellationToken cancellationToken = default)
        {
            return DeserializeResponse<TReturn>(
                await GetHttpResponseMessageContentAsync(GetHttpRequestMessage(url, HttpMethod.Get, requestContent), cancellationToken));
        }


        public async Task<bool> PostAsync(
            string url,
            CancellationToken cancellationToken)
        {
            return await IsHttpRequestSuccessful(new HttpRequestMessage(HttpMethod.Post, url), cancellationToken);
        }

        public async Task<bool> PostAsync<TRequestContent>(string url,
            TRequestContent requestContent,
            CancellationToken cancellationToken)
        {
            return await IsHttpRequestSuccessful(GetHttpRequestMessage(url, HttpMethod.Post, requestContent), cancellationToken);
        }

        public async Task<TReturn> PostAsync<TReturn>(
            string url,
            CancellationToken cancellationToken)
        {
            return DeserializeResponse<TReturn>(
                await GetHttpResponseMessageContentAsync(GetHttpRequestMessage(url, HttpMethod.Post),
                cancellationToken));
        }

        public async Task<TReturn> PostAsync<TReturn, TRequestContent>(
            string url,
            TRequestContent requestContent,
            CancellationToken cancellationToken)
        {
            return DeserializeResponse<TReturn>(
                await GetHttpResponseMessageContentAsync(GetHttpRequestMessage(url, HttpMethod.Post, requestContent), cancellationToken));
        }

        #endregion

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

        private HttpRequestMessage GetHttpRequestMessage(string url, HttpMethod httpMethod, object requestContent = null)
        {
            if (requestContent == null)
                return new HttpRequestMessage(httpMethod, url);

            return new HttpRequestMessage(httpMethod, url)
            {
                Content = new StringContent(
                    JsonSerializer.Serialize(requestContent, GetJsonSerializerOptions()),
                    Encoding.UTF8,
                    "application/json")
            };
        }

        private async Task<bool> IsHttpRequestSuccessful(
            HttpRequestMessage httpRequestMessage,
            CancellationToken cancellationToken)
        {
            return (await httpClient.SendAsync(httpRequestMessage, cancellationToken)).IsSuccessStatusCode;
        }

        private async Task<string> GetHttpResponseMessageContentAsync(
            HttpRequestMessage httpRequestMessage,
            CancellationToken cancellationToken)
        {
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage, cancellationToken);

            string responseMessageContent = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);

            if (!httpResponseMessage.IsSuccessStatusCode)
                throw new ApiClientException(GetErrorMessage(responseMessageContent));

            return responseMessageContent;
        }

        private TReturnObject DeserializeResponse<TReturnObject>(string responseMessageContent)
        {
            return !string.IsNullOrWhiteSpace(responseMessageContent)
                ? JsonSerializer.Deserialize<TReturnObject>(responseMessageContent)
                : default;
        }

        private string GetErrorMessage(string responseMessageContent)
        {
            if (string.IsNullOrEmpty(responseMessageContent))
                return DefaultApiCallError;

            return responseMessageContent;
        }

        #endregion
    }
}