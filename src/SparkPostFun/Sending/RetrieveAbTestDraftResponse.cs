namespace SparkPostFun.Sending
{
    public record RetrieveAbTestDraftResponse
    {
        public RetrieveAbTestDraftResponseResult Results { get; init; } = new();
    }
}