namespace SparkPostFun.Sending
{
    public record UpdateAbTestResponse
    {
        public UpdateAbTestResponseResult Results { get; init; }
    }

    public record CancelAbTestResponse
    {
        public CancelAbTestResponseResult Results { get; init; }
    }

    public record CancelAbTestResponseResult
    {
        public string Status { get; init; }
    }
}