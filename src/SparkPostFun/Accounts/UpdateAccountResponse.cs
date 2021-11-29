namespace SparkPostFun.Accounts
{
    public record UpdateAccountResponse
    {
        public UpdateAccountResponseResult Results { get; init; } = new();
    }
}