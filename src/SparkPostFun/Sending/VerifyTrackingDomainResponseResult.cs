namespace SparkPostFun.Sending
{
    public record VerifyTrackingDomainResponseResult
    {
        public bool Verified { get; init; }
        public CnameStatus CnameStatus { get; init; }
        public ComplianceStatus ComplianceStatus { get; init; }
    }
}