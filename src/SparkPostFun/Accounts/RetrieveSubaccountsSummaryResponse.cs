namespace SparkPostFun.Accounts
{
    public record RetrieveSubaccountsSummaryResponse
    {
        public RetrieveSubaccountsSummaryResponseResult Results { get; init; } = new();
    }
}