﻿namespace SparkPostFun.Sending;

public record UpdateTemplate
{
    public string Name { get; init; }
    public string Description { get; init; }
    public TemplateContent Content { get; init; }
    public TemplateOptions Options { get; init; }
    public bool? SharedWithSubaccounts { get; init; }
}