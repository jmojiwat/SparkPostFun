namespace SparkPostFun.Sending
{
    public record CreateTransmission
    {
        public TransmissionOptions Options { get; init; }
        public object Recipients { get; init; } = new();
        public object Content { get; init; } = new InlineContent();
        public string CampaignId { get; init; }
        public string Description { get; init; }
        public IDictionary<string, object> Metadata { get; init; }
        public IDictionary<string, object> SubstitutionData { get; init; }
        public string ReturnPath { get; init; }
    }
}