namespace SparkPostFun.Receiving
{
    public record AuthenticationRequestDetails
    {
        public string Url { get; init; }
        public AuthenticationRequestDetailsBody Body { get; init; }
    }
}