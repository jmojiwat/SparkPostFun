using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LanguageExt;
using static SparkPostFun.Infrastructure.JsonSerializerOptionsExtensions;
using static SparkPostFun.ClientExtensions;

namespace SparkPostFun
{
    public class Client : IDisposable
    {
        private readonly HttpClient httpClient;
        public string ApiKey { get; }
        public string Host { get; }
        public string Version { get; }

        private static readonly JsonSerializerOptions JsonSerializerOptions1 = DefaultJsonSerializerOptions();

        public Client(HttpClient httpClient, string apiKey, string host = Hosts.Host, string version = "v1")
        {
            this.httpClient = httpClient;
            InitializeHttpClient(this.httpClient, apiKey, host);
            ApiKey = apiKey;
            Host = host;
            Version = version;
        }

        private static void InitializeHttpClient(HttpClient httpClient, string apiKey, string host)
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("User-Agent", "SparkPostFun");
            httpClient.BaseAddress = BuildBaseUri(host);
            httpClient.DefaultRequestHeaders.Add("Authorization", apiKey);
        }

        public Task<HttpResponseMessage> Post<TRequest>(string requestUri, TRequest request)
        {
            return httpClient.PostAsJsonAsync(requestUri, request, JsonSerializerOptions1, CancellationToken.None);
        }

        public async Task<HttpResponseMessage> Post(string requestUri)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(requestUri, UriKind.Relative)
            };
            return await httpClient.SendAsync(request, CancellationToken.None);
        }

        public Task<HttpResponseMessage> Put<TRequest>(string requestUri, TRequest request)
        {
            return httpClient.PutAsJsonAsync(requestUri, request, JsonSerializerOptions1, CancellationToken.None);
        }

        public Task<HttpResponseMessage> PutWithSubaccount<TRequest>(string requestUri, TRequest request, int subaccountId)
        {
            var content = JsonSerializer.Serialize(request, JsonSerializerOptions1);
            using var requestMessage = new HttpRequestMessage(HttpMethod.Put, requestUri);
            requestMessage.Content = new StringContent(content);
            
            requestMessage.Headers.Add("X-MSYS-SUBACCOUNT", subaccountId.ToString());
            return httpClient.SendAsync(requestMessage, CancellationToken.None);
        }

        public async Task<Either<ErrorResponse, TResponse>> Get<TResponse>(string requestUri)
        {
            var message = await httpClient.GetAsync(requestUri, CancellationToken.None);
            return await ToResponse<TResponse>(message);
        }

        public async Task<Either<ErrorResponse, TResponse>> GetWithSubaccount<TResponse>(string requestUri, int subaccountId)
        {
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
            requestMessage.Headers.Add("X-MSYS-SUBACCOUNT", subaccountId.ToString());
            var message = await httpClient.SendAsync(requestMessage, CancellationToken.None);
            return await ToResponse<TResponse>(message);
        }

        public async Task<Either<TError, TResponse>> Get<TError, TResponse>(string requestUri) where TError : BaseErrorResponse
        {
            var message = await httpClient.GetAsync(requestUri, CancellationToken.None);
            return await ToResponse<TError, TResponse>(message);
        }

        public async Task<Either<ErrorResponse, Unit>> Delete(string requestUri)
        {
            var message = await httpClient.DeleteAsync(requestUri, CancellationToken.None);
            return await ToResponse<Unit>(message);
        }

        public async Task<Either<ErrorResponse, Unit>> Delete<TRequest>(string requestUri, TRequest request)
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                Content = JsonContent.Create(request, null, JsonSerializerOptions1),
                Method = HttpMethod.Delete,
                RequestUri = new Uri(requestUri, UriKind.Relative)
            };
            var message = await httpClient.SendAsync(httpRequestMessage, CancellationToken.None);
            return await ToResponse<Unit>(message);
        }

        public void Dispose()
        {
            httpClient.Dispose();
        }
    }
}