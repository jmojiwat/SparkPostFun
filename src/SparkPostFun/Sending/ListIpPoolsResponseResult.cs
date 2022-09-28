using System.Collections.Generic;

namespace SparkPostFun.Sending
{
    public record ListIpPoolsResponseResult
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public string SigningDomain { get; init; }
        public string FblSigningDomain { get; init; }
        public IList<Ip> Ips { get; init; } = new List<Ip>();
        public string AutoWarmupOverflowPool { get; init; }
    }
}