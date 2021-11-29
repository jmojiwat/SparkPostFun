namespace SparkPostFun.Sending
{
    public record RetrieveTemplateResponse
    {
        public RetrieveTemplateResponseResult Results { get; init; } = new();
    }
}