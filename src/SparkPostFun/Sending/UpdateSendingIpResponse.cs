namespace SparkPostFun.Sending
{
    public record UpdateSendingIpResponse
    {
        public UpdateSendingIpResponseResult Results { get; init; } = new();
    }
}