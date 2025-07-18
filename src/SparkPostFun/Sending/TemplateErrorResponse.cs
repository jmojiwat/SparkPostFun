﻿using System.Collections.Generic;

namespace SparkPostFun.Sending
{
    public record TemplateErrorResponse : BaseErrorResponse
    {
        public IList<TemplateError> Errors { get; init; } = new List<TemplateError>();
    }
}