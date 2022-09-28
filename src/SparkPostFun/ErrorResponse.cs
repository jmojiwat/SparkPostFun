using System.Net;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using SparkPostFun.Sending;

namespace SparkPostFun
{
    public record ErrorResponse
    {
        [JsonIgnore]
        public HttpStatusCode StatusCode { get; init; }
        
        public IList<Error> Errors { get; init; } = new List<Error>();
    }
}