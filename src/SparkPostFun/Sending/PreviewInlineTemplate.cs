namespace SparkPostFun.Sending;

public record PreviewInlineTemplate
{
    public IDictionary<string, object> SubstitutionData { get; init; } = new Dictionary<string, object>();
    public TemplateContent Content { get; init; } = new();
}