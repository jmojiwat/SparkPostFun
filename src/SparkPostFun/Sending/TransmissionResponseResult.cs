using System.Text.Json.Serialization;

namespace SparkPostFun.Sending
{
    public record TransmissionResponseResult
    {
        [JsonPropertyName("rcpt_to_errors")]
        public IList<RecipientToError> RecipientToErrors { get; init; }
    }
}