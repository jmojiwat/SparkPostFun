using System.Collections.Generic;

namespace SparkPostFun.Sending
{
    public record PreviewInlineTemplateResponse
    {
        public IDictionary<string, string> Results { get; init; }
    }
}