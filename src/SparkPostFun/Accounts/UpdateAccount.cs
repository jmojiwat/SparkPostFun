using System.Text.Json.Serialization;

namespace SparkPostFun.Accounts
{
    public record UpdateAccount
    {
        public string CompanyName { get; init; }
        [JsonPropertyName("tfa_required")]
        public bool? TwoFactorAuthenticationRequired { get; init; }
        public AccountOptions Options { get; init; }
    }
}