using System.Collections.Specialized;

namespace SparkPostFun.Sending
{
    public record PreviewTemplate
    {
        public NameValueCollection SubstitutionData { get; init; }
    }
}