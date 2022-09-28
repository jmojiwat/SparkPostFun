using System.Collections.Generic;

namespace SparkPostFun.Accounts
{
    public record CreateSubaccount(string Name)
    {
        public string IpPool { get; init; }
        public bool? SetupApiKey { get; init; }
        public string KeyLabel { get; init; }
        public IList<string> KeyGrants { get; init; }
        public IList<string> KeyValidIps { get; init; }
        public SubaccountOptions Options { get; init; }
    }
}