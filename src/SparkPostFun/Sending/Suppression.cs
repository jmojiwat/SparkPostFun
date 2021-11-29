namespace SparkPostFun.Sending
{
    public record Suppression
    {
        public string Recipient { get; init; }
        
        public SuppressionType Type { get; init; }
        
        public SuppressionSource Source { get; init; }
        
        public string Description { get; init; }
        
        public DateTime Created { get; init; }
        
        public DateTime Updated { get; init; }
        
        public int? SubaccountId { get; init; }
    }
}