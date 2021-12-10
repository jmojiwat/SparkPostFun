namespace SparkPostFun.Sending;

public record ListTemplatesResponseResult
{
    public string Id { get; init; }
    public string Name { get; init; }
    public bool Published { get; init; }
    public string Description { get; init; }
    public bool HasDraft { get; init; }
    public bool HasPublished { get; init; }
    public DateTime? LastUse { get; init; }
    public DateTime? LastUpdateTime { get; init; }
    public bool SharedWithSubaccount { get; init; }
}