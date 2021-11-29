namespace SparkPostFun.Sending
{
    public record CreateTemplate
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public string escription { get; init; }
        public object ontent { get; init; } = new TemplateContent();
        public TemplateOptions Options { get; init; }
        public bool? SharedWithSubaccounts { get; init; }
    }
}