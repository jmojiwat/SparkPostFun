namespace SparkPostFun.Analytics
{
    public record MetricsBySubjectCampaignResponseResult
    {
        public string SubjectCampaign { get; init; }
        public int CountInboxPanel { get; init; }
        public int CountSpamPanel { get; init; }
        public int CountInboxSeed { get; init; }
        public int CountSpamSeed { get; init; }
        public int CountMovedToInbox { get; init; }
        public int CountMovedToSpam { get; init; }
    }
}