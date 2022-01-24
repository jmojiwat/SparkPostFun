namespace SparkPostFun.Sending;

public record ListTemplatesResponseResult
{
    public string Id { get; init; }
    public string Name { get; init; }
    public bool Published { get; init; }
    public string Description { get; init; }
    public bool HasDraft { get; init; }
    public bool HasPublished { get; init; }
    public DateTimeOffset? LastUse { get; init; }
    public DateTimeOffset? LastUpdateTime { get; init; }
    public bool SharedWithSubaccounts { get; init; }
}