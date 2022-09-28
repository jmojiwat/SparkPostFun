namespace SparkPostFun.Analytics
{
    public class MetricsSummaryPrecision
    {
        private readonly string value;

        private MetricsSummaryPrecision(string value)
        {
            this.value = value;
        }

        public override string ToString() => value;
    
        public static readonly MetricsSummaryPrecision OneMinute = new("1min");
        public static readonly MetricsSummaryPrecision FiveMinute = new("5min");
        public static readonly MetricsSummaryPrecision FifteenMinute = new("15min");
        public static readonly MetricsSummaryPrecision Hour = new("hour");
        public static readonly MetricsSummaryPrecision Day = new("day");
    }
}