namespace SparkPostFun.Receiving
{
    public record AuthenticationRequestDetailsBody
    {
        public string ClientId { get; init; }
        public string ClientSecret { get; init; }
    }
}