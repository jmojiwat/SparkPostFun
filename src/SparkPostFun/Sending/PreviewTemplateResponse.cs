namespace SparkPostFun.Sending
{
    public record PreviewTemplateResponse
    {
        public TemplateContent Results { get; init; } = new();
    }
}