namespace SparkPostFun.Sending
{
    public record ListRecipientListsResponse
    {
        public IList<ListRecipientListsResponseResult> Results { get; init; } = new List<ListRecipientListsResponseResult>();
    }
}