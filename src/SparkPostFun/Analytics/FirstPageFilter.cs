namespace SparkPostFun.Analytics
{
    public record FirstPageFilter
    {
        public int? PerPage { get; init; }
        public string Cursor => "initial";
    }
}