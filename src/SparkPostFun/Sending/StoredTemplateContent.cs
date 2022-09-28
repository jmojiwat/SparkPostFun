namespace SparkPostFun.Sending
{
    public record StoredTemplateContent(string TemplateId)
    {
        public bool UseDraftTemplate { get; init; } = false;
    }
}