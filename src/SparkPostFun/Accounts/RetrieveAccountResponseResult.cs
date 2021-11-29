using System.Text.Json.Serialization;

namespace SparkPostFun.Accounts
{
    public record RetrieveAccountResponseResult
    {
        public int? CustomerId { get; init; }
        public string CompanyName { get; init; }
        public string CountryCode { get; init; }
        public DateTime? AnniversaryDate { get; init; }
        public DateTime? Created { get; init; }
        public DateTime? Updated { get; init; }
        public string Status { get; init; }
        [JsonPropertyName("tfa_required")]
        public bool? TwoFactorAuthenticationRequired { get; init; }
        public DateTime? StatusUpdated { get; init; }
        public string StatusReasonCategory { get; init; }
        public AccountSubscription Subscription { get; init; }
        public AccountSupport Support{ get; init; }
        public object PendingSubscription { get; init; }
        public AccountOptions Options { get; init; }
        public AccountUsage Usage { get; init; }
        public string ServiceLevel { get; init; }
        public AccountPendingCancellation PendingCancellation{ get; init; }
    }
}
