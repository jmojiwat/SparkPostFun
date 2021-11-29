namespace SparkPostFun.Sending
{
    public record Dns
    {
        public string DkimRecord { get; init; }
        public string CnameRecord { get; init; }
        public string DkimError { get; init; }
        public string CnameError { get; init; }
    }
}