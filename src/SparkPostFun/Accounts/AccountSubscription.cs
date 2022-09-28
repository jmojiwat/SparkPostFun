using System;

namespace SparkPostFun.Accounts
{
    public record AccountSubscription
    {
        public string Name { get; init; }
        public string Code { get; init; }
        public int? PlanVolume { get; init; }
        public DateTime? EffectiveDate { get; init; }
        public bool? SelfServe { get; init; }
        public string Type { get; init; }
    }
}