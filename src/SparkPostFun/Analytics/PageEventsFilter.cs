namespace SparkPostFun.Analytics;

public record PageEventsFilter
{
    public int? PerPage { get; set; }
    public string Cursor { get; set; }
}