﻿using System.Collections.Generic;

namespace SparkPostFun.Sending
{
    public record ListSnippetsResponse
    {
        public IList<ListSnippetsResponseResult> Results { get; init; }
    }
}