namespace SparkPostFun.Sending
{
    public record CreateTemplateResponse
    {
        public CreateTemplateResponseResult Results { get; init; } = new();
    }

    public record CreateTemplateResponseResult
    {
        public string Id { get; init; }
    }
}