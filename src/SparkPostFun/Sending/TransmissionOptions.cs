namespace SparkPostFun.Sending;

public record TransmissionOptions
{
    public DateTimeOffset? StartTime { get; init; }
    public bool? OpenTracking { get; init; }
    public bool? InitialOpen { get; init; }
    public bool? ClickTracking { get; init; }
    public bool? Transactional { get; init; }
    public bool? Sandbox { get; init; }
    public bool? SkipSupression { get; init; }
    public string IpPool { get; init; }
    public bool? InlineCss { get; init; }
    public bool? PerformSubstitutions { get; init; }
}