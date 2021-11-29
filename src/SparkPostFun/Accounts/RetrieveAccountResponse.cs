namespace SparkPostFun.Accounts
{
    public record RetrieveAccountResponse
    {
        public RetrieveAccountResponseResult Results { get; init; } = new();
    }
}