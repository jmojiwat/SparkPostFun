namespace SparkPostFun.Sending
{
    public record StoredRecipientList : IRecipients
    {
        public string ListId { get; init; }
    }
}