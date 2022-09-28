using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace SparkPostFun.Sending
{
    public record TransmissionResponseResult
    {
        [JsonPropertyName("rcpt_to_errors")] public IList<RecipientToError> RecipientToErrors { get; init; }
    }
}