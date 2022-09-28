namespace SparkPostFun.Analytics
{
    public record AuthorizationRequestDetails
    {
        public string Url { get; init; }
        public object Body { get; init; }
    }
}