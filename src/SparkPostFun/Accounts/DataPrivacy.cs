namespace SparkPostFun.Accounts
{
    public record DataPrivacy
    {
        public IList<DataPrivacyAddress> Recipients { get; init; }
        public bool IncludeSubaccounts { get; init; }
    }
}