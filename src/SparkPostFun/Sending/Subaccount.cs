﻿namespace SparkPostFun.Sending
{
    public record Subaccount
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public SubaccountStatus Status { get; init; }
        public string ComplianceStatus { get; init; }
        public string IpPool { get; init; }
        public SubaccountOptions Options { get; init; }
    }
}