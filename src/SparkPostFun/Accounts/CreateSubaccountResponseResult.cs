namespace SparkPostFun.Accounts
{
    public record CreateSubaccountResponseResult
    {
        public int? SubaccountId { get; init; }
        public string Key { get; init; }
        public string Label { get; init; }
        public string ShortKey { get; init; }
    }
}