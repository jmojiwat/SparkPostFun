namespace SparkPostFun.Accounts
{
    public record AddDataPrivacy
    {
        public IList<string> Recipients { get; init; } = new List<string>();
        public bool? IncludeSubaccounts { get; init; }
    }
}