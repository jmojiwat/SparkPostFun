namespace SparkPostFun.Sending
{
    public record SubaccountError
    {
        public string Message { get; init; }
        public string Param { get; init; }
        public string Value { get; init; }
    }
}