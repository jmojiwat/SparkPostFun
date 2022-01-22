namespace SparkPostFun.Sending;

public record SearchSuppressionsFilter
{
    public DateTime? To { get; init; }
    public DateTime? From { get; init; }
    public string Domain { get; init; }
    public IList<SuppressionSource> Sources { get; init; } = new List<SuppressionSource>();
    public IList<SuppressionType> Types { get; init; } = new List<SuppressionType>();
    public string Description { get; init; }
    public bool? DescriptionStrict { get; init; }
    public string Cursor { get; init; }
    public int? PerPage { get; init; }
    public int? Page { get; init; }
    public SortOrder? Sort { get; init; }
}