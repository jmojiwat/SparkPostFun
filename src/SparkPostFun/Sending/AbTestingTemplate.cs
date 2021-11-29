namespace SparkPostFun.Sending
{
    public record AbTestingTemplate
    {
        public string TemplateId { get; init; }
        public int SampleSize { get; init; }
        public int Percent { get; init; }
        public int CountUniqueClicked { get; init; }
        public int CountUniqueConfirmedOpened { get; init; }
        public int CountAccepted { get; init; }
        public float EngagementRate { get; init; }
    }
}