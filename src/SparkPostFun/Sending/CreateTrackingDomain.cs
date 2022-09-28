namespace SparkPostFun.Sending
{
    public record CreateTrackingDomain(string Domain)
    {
        public bool? Secure { get; init; }
    }
}