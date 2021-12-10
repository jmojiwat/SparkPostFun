namespace SparkPostFun.Accounts
{
    public record SubaccountCreateResponse
    {
        public int SubaccountId { get; init; }
        public string Key { get; init; }
        public string Label { get; init; }
        public string ShortKey { get; init; }
    }
}