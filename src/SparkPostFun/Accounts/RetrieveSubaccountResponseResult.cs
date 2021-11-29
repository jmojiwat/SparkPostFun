using SparkPostFun.Sending;

namespace SparkPostFun.Accounts
{
    public record RetrieveSubaccountResponseResult
    {
        public int? Id { get; init; }
        public string Name { get; init; }
        public SubaccountStatus? Status { get; init; }
        public string ComplianceStatus { get; init; }
        public string IpPool { get; init; }
        public SubaccountOptions Options { get; init; }
    }
}