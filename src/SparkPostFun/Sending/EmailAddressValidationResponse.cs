namespace SparkPostFun.Sending;

public record EmailAddressValidationResponse
{
    public EmailAddressValidationResponseResult Results { get; init; } = new();
}