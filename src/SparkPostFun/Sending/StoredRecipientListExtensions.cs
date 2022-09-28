namespace SparkPostFun.Sending
{
    public static class StoredRecipientListExtensions
    {
        public static StoredRecipientList WithListId(this StoredRecipientList @this, string listId) =>
            @this with { ListId = listId };
    }
}