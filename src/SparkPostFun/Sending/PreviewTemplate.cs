using System.Collections.Generic;

namespace SparkPostFun.Sending
{
    public record PreviewTemplate
    {
        public IDictionary<string, object> SubstitutionData { get; init; } = new Dictionary<string, object>();
    }
}