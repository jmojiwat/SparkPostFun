using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using LanguageExt;
using static SparkPostFun.Infrastructure.JsonSerializerOptionsExtensions;
using static SparkPostFun.ClientExtensions;

namespace SparkPostFun
{
    public class Client
    {
        public string ApiKey { get; }
        public string Host { get; }
        public string Version { get; }

        private readonly HttpClient httpClient = new();
        private static readonly JsonSerializerOptions JsonSerializerOptions = DefaultJsonSerializerOptions();

        public Client(string apiKey) : this(apiKey, Hosts.Host) { }

        public Client(string apiKey, string host, string version = "v1")
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("User-Agent", "SparkPostSharp");
            httpClient.BaseAddress = BuildBaseUri(host);
            httpClient.DefaultRequestHeaders.Add("Authorization", apiKey);
            ApiKey = apiKey;
            Host = host;
            Version = version;
        }

        public Task<HttpResponseMessage> Post<TRequest>(string requestUri, TRequest request)
        {
            return httpClient.PostAsJsonAsync(requestUri, request, JsonSerializerOptions, CancellationToken.None);
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
            return httpClient.PutAsJsonAsync(requestUri, request, JsonSerializerOptions, CancellationToken.None);
        }

        public async Task<Either<ErrorResponse, TResponse>> Get<TResponse>(string requestUri)
        {
            var message = await httpClient.GetAsync(requestUri, CancellationToken.None);
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
                Content = JsonContent.Create(request, null, JsonSerializerOptions),
                Method = HttpMethod.Delete,
                RequestUri = new Uri(requestUri, UriKind.Relative)
            };
            var message = await httpClient.SendAsync(httpRequestMessage, CancellationToken.None);
            return await ToResponse<Unit>(message);
        }
    }
}