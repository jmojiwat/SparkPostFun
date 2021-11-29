using System.Net;

namespace SparkPostFun.Sending
{
    public record Response
    {
        public bool IsSuccessStatusCode { get; init; }
        public string ReasonPhrase { get; init; }
        public HttpStatusCode StatusCode { get; init; }
    }
}