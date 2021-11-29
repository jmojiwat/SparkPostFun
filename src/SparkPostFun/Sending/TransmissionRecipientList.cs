namespace SparkPostFun.Sending
{
    public record TransmissionRecipientList : IRecipients
    {
        public IList<Recipient> Recipients { get; init; } = new List<Recipient>();
    }
}