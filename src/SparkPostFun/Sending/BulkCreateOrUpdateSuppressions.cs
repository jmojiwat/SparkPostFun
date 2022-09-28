using System.Collections.Generic;

namespace SparkPostFun.Sending
{
    public record BulkCreateOrUpdateSuppressions(IList<CreateOrUpdateSuppressionRecipient> Recipients);
}