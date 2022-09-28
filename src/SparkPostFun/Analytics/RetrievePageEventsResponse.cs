namespace SparkPostFun.Analytics
{
    public record RetrievePageEventsResponse
    {
        public object Results { get; init; } = new();
        public int TotalCount { get; set; }
        public Links Links { get; set; }
    }
}