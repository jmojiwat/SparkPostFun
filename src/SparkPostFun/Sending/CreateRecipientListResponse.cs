namespace SparkPostFun.Sending;

public record CreateRecipientListResponse
{
    public CreateRecipientListResponseResult Results { get; init; } = new();
}