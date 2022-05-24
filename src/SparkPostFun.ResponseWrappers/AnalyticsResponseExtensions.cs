using System.Net;
using LanguageExt;
using SparkPostFun.Analytics;
using SparkPostFun.Sending;

namespace SparkPostFun.ResponseWrappers;

public static class AnalyticsResponseExtensions
{
    public static async Task<CreateWebhookResponseWrapper> Wrap(Task<Either<CreateWebhookErrorResponse, CreateWebhookResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            CreateWebhookSuccess,
            CreateWebhookFail);
    
    private static CreateWebhookResponseWrapper CreateWebhookSuccess(CreateWebhookResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static CreateWebhookResponseWrapper CreateWebhookFail(CreateWebhookErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };
    
}