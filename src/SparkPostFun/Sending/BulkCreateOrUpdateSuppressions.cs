namespace SparkPostFun.Sending;

public record BulkCreateOrUpdateSuppressions
{
    public IList<CreateOrUpdateSuppression> Recipients { get; init; } = new List<CreateOrUpdateSuppression>();
}