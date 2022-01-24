namespace SparkPostFun.Sending;

public record UpdatePublishedTemplate
{
    public string Name { get; init; }
    public string Description { get; init; }
    public UpdateTemplateContent Content { get; init; }
    public TemplateOptions Options { get; init; }
    public bool? SharedWithSubaccounts { get; init; }
}