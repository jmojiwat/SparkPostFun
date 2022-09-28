using System.Collections.Generic;

namespace SparkPostFun.Analytics
{
    public record RetrieveBatchStatusInformationResponse
    {
        public IList<RetrieveBatchStatusInformationResponseResult> Results { get; init; } = new List<RetrieveBatchStatusInformationResponseResult>();
    }
}