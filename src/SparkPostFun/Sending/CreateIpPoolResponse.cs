namespace SparkPostFun.Sending
{
    public record CreateIpPoolResponse
    {
        public CreateIpPoolResponseResult Results { get; init; } = new();
    }
}