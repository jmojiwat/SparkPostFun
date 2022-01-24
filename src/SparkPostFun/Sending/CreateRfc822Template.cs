namespace SparkPostFun.Sending;

public record CreateRfc822Template
{
    public string Id { get; init; }
    public string Name { get; init; }
    public bool? Published { get; init; }
    public string Description { get; init; }
    public TemplateOptions Options { get; init; }
    public CreateRfc822TemplateContent Content { get; init; }
    public bool? SharedWithSubaccounts { get; init; }
}