namespace SparkPostFun.Analytics
{
    public record MetricsByRecipientDomainResponseResult
    {
        public string Domain { get; init; }
        public int CountTargeted { get; init; }
        public int CountInjected { get; init; }
        public int CountRejected { get; init; }
        public int CountSent { get; init; }
    }
}