using System.Collections.Generic;

namespace SparkPostFun.Sending
{
    public record CreateTransmissionResponse
    {
        public CreateTransmissionResponseResult Results { get; init; } = new();
        public IList<CreateTransmissionResponseError> Errors { get; init; } = new List<CreateTransmissionResponseError>();
    }
}