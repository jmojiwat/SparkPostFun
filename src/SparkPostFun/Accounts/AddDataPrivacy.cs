namespace SparkPostFun.Accounts
{
    public record AddDataPrivacy(IList<string> Recipients)
    {
        public bool? IncludeSubaccounts { get; init; }
    }
}