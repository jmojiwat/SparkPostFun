namespace SparkPostFun.Sending
{
    public record StoredTemplateContent
    {
        public string TemplateId { get; init; }
        public bool UseDraftTemplate { get; init; } = false;
    }
}