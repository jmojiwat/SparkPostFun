namespace SparkPostFun.Analytics
{
    public record PageFilter
    {
        public int? PerPage { get; init; }
        public string Cursor { get; init; }
    }
}