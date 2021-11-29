namespace SparkPostFun.Accounts
{
    public record DataPrivacyError
    {
        public string Message { get; init; }
        public string Recipient { get; init; }
    }
}