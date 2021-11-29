using System.Net;
using System.Text.Json.Serialization;

namespace SparkPostFun
{
    public abstract record BaseErrorResponse
    {
        [JsonIgnore]
        public HttpStatusCode StatusCode { get; init; }
    }
}