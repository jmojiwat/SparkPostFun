namespace SparkPostFun.Sending;

public record TemplateOptions
{
    public bool Transactional { get; init; }
    public bool OpenTracking { get; init; }
    public bool ClickTracking { get; init; }
}