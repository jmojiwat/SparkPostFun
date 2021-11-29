namespace SparkPostFun.Sending
{
    public record CreateSendingDomain
    {
        public string Domain { get; init; }
        public string TrackingDomain { get; init; }
        public CreateDkim Dkim { get; init; }
        public bool? GenerateDkim { get; init; }
        public int? DkimKeyLength { get; init; }
    }
}