﻿namespace SparkPostFun.Sending;

public record BulkCreateOrUpdateSuppressions(IList<CreateOrUpdateSuppressionRecipient> Recipients);