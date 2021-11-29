namespace SparkPostFun.Accounts
{
    public record DataPrivacyResponse
    {
        public DataPrivacyResponseResult Results { get; init; } = new();
    }
}