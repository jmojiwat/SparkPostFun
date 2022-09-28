namespace SparkPostFun.Analytics
{
    public record BounceReasonMetricsByDomainResponseResult
    {
        public string Reason {get; init;}
        public string Domain {get; init;}
        public string BounceClassName {get; init;}
        public string BounceClassDescription {get; init;}
        public int BounceCategoryId {get; init;}
        public string BounceCategoryName {get; init;}
        public int ClassificationId {get; init;}
        public int CountInbandBounce {get; init;}
        public int CountOutofbandBounce {get; init;}
        public int CountBounce {get; init;}
    }
}