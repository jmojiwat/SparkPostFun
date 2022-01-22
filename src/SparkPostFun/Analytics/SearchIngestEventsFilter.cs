namespace SparkPostFun.Analytics;

public record SearchIngestEventsFilter
{
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
    public string Cursor { get; set; }
    public int? PerPage { get; set; }
    public string Delimiter { get; set; }
    public IList<string> Events { get; set; } = new List<string>();
    public IList<string> EventIds { get; set; } = new List<string>();
    public IList<string> BatchIds { get; set; } = new List<string>();
    public bool? Retryable { get; set; }
    public IList<string> Subaccounts { get; set; } = new List<string>();
}