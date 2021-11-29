using System.Net;

namespace SparkPostFun.Sending
{
    public record SubaccountCreate
    {
        public string Name { get; init; }
        public string KeyLabel { get; init; }
        public string[] KeyGrants { get; init; }
        public IPAddress[] KeyValidIps { get; init; }
        public string IpPool { get; init; }
    }
}