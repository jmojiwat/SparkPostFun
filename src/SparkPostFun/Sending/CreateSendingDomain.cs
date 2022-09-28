namespace SparkPostFun.Sending
{
    public record CreateSendingDomain(string Domain)
    {
        public string TrackingDomain { get; init; }
        public CreateDkim Dkim { get; init; }
        public bool? GenerateDkim { get; init; }
        public int? DkimKeyLength { get; init; }
        public bool? SharedWithSubaccounts { get; init; }
    }
}