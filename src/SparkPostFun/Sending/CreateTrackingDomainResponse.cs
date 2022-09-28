namespace SparkPostFun.Sending
{
    public record CreateTrackingDomainResponse
    {
        public CreateTrackingDomainResponseResult Results { get; init; } = new();
    }
}