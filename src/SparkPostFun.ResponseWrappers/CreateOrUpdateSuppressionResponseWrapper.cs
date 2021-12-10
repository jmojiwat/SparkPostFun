﻿using System.Net;
using SparkPostFun.Sending;

namespace SparkPostFun.ResponseWrappers;

public record CreateOrUpdateSuppressionResponseWrapper
{
    public CreateOrUpdateSuppressionResponseResult Results { get; init; } = new();
    public HttpStatusCode StatusCode { get; init; }
    public IList<Error> Errors { get; init; } = new List<Error>();
}