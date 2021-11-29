namespace SparkPostFun.Sending
{
    public record CreateRecipientList
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public IDictionary<string, object> Attributes { get; init; }
        public IList<Recipient> Recipients { get; init; } = new List<Recipient>();
    }
}