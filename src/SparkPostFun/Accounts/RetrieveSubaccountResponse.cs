namespace SparkPostFun.Accounts
{
    public record RetrieveSubaccountResponse
    {
        public RetrieveSubaccountResponseResult Results { get; init; } = new();
    }
}