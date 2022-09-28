namespace SparkPostFun.Sending
{
    public record VerifySendingDomain
    {
    
        public bool? DkimVerify { get; init; }
        public bool? CnameVerify { get; init; }
        public bool? VerificationMailboxVerify { get; init; }
        public string VerificationMailbox { get; init; }
        public bool? PostmasterAtVerify { get; init; }
        public bool? AbuseAtVerify { get; init; }
        public string VerificationMailboxToken { get; init; }
        public string PostmasterAtToken { get; init; }
        public string AbuseAtToken { get; init; }
    }
}