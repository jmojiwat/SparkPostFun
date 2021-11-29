namespace SparkPostFun.Accounts
{
    public record AccountUpdate
    {
        public string CompanyName { get; init; }
        public bool TwoFactorAuthenticationRequired { get; init; }
        public AccountOptions Options { get; init; }
    }
}