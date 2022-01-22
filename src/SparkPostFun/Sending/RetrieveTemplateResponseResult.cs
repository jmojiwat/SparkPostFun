namespace SparkPostFun.Sending;

public record RetrieveTemplateResponseResult
{
    public string Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public TemplateContent Content { get; init; } = new();
    public bool? Published { get; init; }
    public TemplateOptions Options { get; init; } = new();
    public bool? HasDraft { get; init; }
    public bool? HasPublished { get; init; }
    public DateTimeOffset? LastUpdateTime { get; init; }
    public DateTimeOffset? LastUse { get; init; }
    public bool? SharedWithSubaccounts { get; init; }
    public bool? SubaccountId { get; init; }
}