using SmartApiClient.Exceptions;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace SmartApiClient.Services
{
    public abstract class ApiClient : IApiClient
    {
        private HttpClient httpClient;

        protected virtual string DefaultApiCallError
            => "An unexpected error has occured during the server call.";

        public ApiClient(IHttpClientFactory httpClientFactory)
        {
            SetHttpClient(httpClientFactory);
        }

        #region Public

        public async Task<TReturn> GetAsync<TReturn>(
            string url,
            CancellationToken cancellationToken = default)
        {
            return await GetReturnObjectAsync<TReturn>(url, HttpMethod.Get, cancellationToken);
        }

        public async Task<TReturn> GetAsync<TReturn, TRequestContent>(
            string url,
            TRequestContent requestContent,
            CancellationToken cancellationToken = default)
        {
            return await GetReturnObjectAsync<TReturn>(url, HttpMethod.Get, cancellationToken, requestContent);
        }

        public async Task<bool> PostAsync(
            string url,
            CancellationToken cancellationToken)
        {
            return await IsHttpRequestSuccessfulAsync(new HttpRequestMessage(HttpMethod.Post, url), cancellationToken);
        }

        public async Task<bool> PostAsync<TRequestContent>(string url,
            TRequestContent requestContent,
            CancellationToken cancellationToken)
        {
            return await IsHttpRequestSuccessfulAsync(GetHttpRequestMessage(url, HttpMethod.Post, requestContent), cancellationToken);
        }

        public async Task<TReturn> PostAsync<TReturn>(
            string url,
            CancellationToken cancellationToken)
        {
            return await GetReturnObjectAsync<TReturn>(url, HttpMethod.Post, cancellationToken);
        }

        public async Task<TReturn> PostAsync<TReturn, TRequestContent>(
            string url,
            TRequestContent requestContent,
            CancellationToken cancellationToken)
        {
            return await GetReturnObjectAsync<TReturn>(url, HttpMethod.Post, cancellationToken, requestContent);
        }

        public async Task<bool> PutAsync(
            string url,
            CancellationToken cancellationToken)
        {
            return await IsHttpRequestSuccessfulAsync(new HttpRequestMessage(HttpMethod.Put, url), cancellationToken);
        }

        public async Task<bool> PutAsync<TRequestContent>(string url,
            TRequestContent requestContent,
            CancellationToken cancellationToken)
        {
            return await IsHttpRequestSuccessfulAsync(GetHttpRequestMessage(url, HttpMethod.Put, requestContent), cancellationToken);
        }

        public async Task<TReturn> PutAsync<TReturn>(
            string url,
            CancellationToken cancellationToken)
        {
            return await GetReturnObjectAsync<TReturn>(url, HttpMethod.Put, cancellationToken);
        }

        public async Task<TReturn> PutAsync<TReturn, TRequestContent>(
            string url,
            TRequestContent requestContent,
            CancellationToken cancellationToken)
        {
            return await GetReturnObjectAsync<TReturn>(url, HttpMethod.Put, cancellationToken, requestContent);
        }

        public async Task<bool> PatchAsync(
            string url,
            CancellationToken cancellationToken)
        {
            return await IsHttpRequestSuccessfulAsync(new HttpRequestMessage(HttpMethod.Patch, url), cancellationToken);
        }

        public async Task<bool> PatchAsync<TRequestContent>(string url,
            TRequestContent requestContent,
            CancellationToken cancellationToken)
        {
            return await IsHttpRequestSuccessfulAsync(GetHttpRequestMessage(url, HttpMethod.Patch, requestContent), cancellationToken);
        }

        public async Task<TReturn> PatchAsync<TReturn>(
            string url,
            CancellationToken cancellationToken)
        {
            return await GetReturnObjectAsync<TReturn>(url, HttpMethod.Patch, cancellationToken);
        }

        public async Task<TReturn> PatchAsync<TReturn, TRequestContent>(
            string url,
            TRequestContent requestContent,
            CancellationToken cancellationToken)
        {
            return await GetReturnObjectAsync<TReturn>(url, HttpMethod.Patch, cancellationToken, requestContent);
        }

        public async Task<bool> DeleteAsync(
            string url,
            CancellationToken cancellationToken)
        {
            return await IsHttpRequestSuccessfulAsync(new HttpRequestMessage(HttpMethod.Delete, url), cancellationToken);
        }

        public async Task<bool> DeleteAsync<TRequestContent>(string url,
            TRequestContent requestContent,
            CancellationToken cancellationToken)
        {
            return await IsHttpRequestSuccessfulAsync(GetHttpRequestMessage(url, HttpMethod.Delete, requestContent), cancellationToken);
        }

        public async Task<TReturn> DeleteAsync<TReturn>(
            string url,
            CancellationToken cancellationToken)
        {
            return await GetReturnObjectAsync<TReturn>(url, HttpMethod.Delete, cancellationToken);
        }

        public async Task<TReturn> DeleteAsync<TReturn, TRequestContent>(
            string url,
            TRequestContent requestContent,
            CancellationToken cancellationToken)
        {
            return await GetReturnObjectAsync<TReturn>(url, HttpMethod.Delete, cancellationToken, requestContent);
        }

        #endregion

        #region Protected

        protected virtual Uri SetBaseUrl()
            => new UriBuilder
            {
                Host = "localhost",
                Scheme = "https",
                Port = 8080
            }
            .Uri;

        protected virtual void SetHttpClient(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient();
            httpClient.BaseAddress = SetBaseUrl();
        }

        protected virtual JsonSerializerOptions GetJsonSerializerOptions()
        {
            return new()
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            };
        }

        #endregion

        #region Private

        private async Task<TReturn> GetReturnObjectAsync<TReturn>(
            string url,
            HttpMethod httpMethod,
            CancellationToken cancellationToken,
            object requestContent = null)
        {
            return DeserializeResponse<TReturn>(
                await GetHttpResponseContentAsync(
                    GetHttpRequestMessage(url, httpMethod, requestContent), cancellationToken));
        }

        private HttpRequestMessage GetHttpRequestMessage<TRequestContent>(
            string url,
            HttpMethod httpMethod,
            TRequestContent requestContent)
        {
            return new HttpRequestMessage(httpMethod, url)
            {
                Content = new StringContent(
                    JsonSerializer.Serialize(requestContent, GetJsonSerializerOptions()),
                    Encoding.UTF8,
                    "application/json")
            };
        }

        private async Task<bool> IsHttpRequestSuccessfulAsync(
            HttpRequestMessage httpRequestMessage,
            CancellationToken cancellationToken)
        {
            return (await httpClient.SendAsync(httpRequestMessage, cancellationToken)).IsSuccessStatusCode;
        }

        private async Task<string> GetHttpResponseContentAsync(
            HttpRequestMessage httpRequestMessage,
            CancellationToken cancellationToken)
        {
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage, cancellationToken);

            string responseMessageContent = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);

            if (!httpResponseMessage.IsSuccessStatusCode)
                throw new ApiClientException(GetErrorMessage(responseMessageContent));

            return responseMessageContent;
        }

        private TReturn DeserializeResponse<TReturn>(string responseMessageContent)
        {
            return !string.IsNullOrWhiteSpace(responseMessageContent)
                ? JsonSerializer.Deserialize<TReturn>(responseMessageContent)
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