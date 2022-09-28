using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace SparkPostFun.Sending
{
    public record CreateTransmissionResponseResult
    {
        [JsonPropertyName("rcpt_to_errors")] public IList<RecipientToError> RecipientToErrors { get; init; }

        public int TotalRejectedRecipients { get; init; }
        public int TotalAcceptedRecipients { get; init; }
        public string Id { get; init; }
    }
}