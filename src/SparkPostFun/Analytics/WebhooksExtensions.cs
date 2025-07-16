using System;
using System.Threading.Tasks;
using LanguageExt;
using static SparkPostFun.ClientExtensions;
using static LanguageExt.Prelude;

namespace SparkPostFun.Analytics;

public static class WebhooksExtensions
{
    public static Reader<SparkPostEnvironment, Task<Either<CreateWebhookErrorResponse, CreateWebhookResponse>>>
        CreateWebhook(CreateWebhook request)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/webhooks"
            select env.Client.Post(requestUrl, request)
                .MapAsync(ToResponse<CreateWebhookErrorResponse, CreateWebhookResponse>);
    }

    /*
    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, ValidateWebhookResponse>>> ValidateWebhook(Guid id, ValidateWebhookRequest request)
    {
        throw new NotImplementedException();

            let requestUrl = $"/api/{env.Version}/webhooks/{id}/validate";
select env.Client.Post(requestUrl, request)
            .MapAsync(ToResponse<ValidateWebhookResponse>);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, RetrieveWebhookResponse>>> RetrieveWebhook(Guid id)
    {
        throw new NotImplementedException();
            let requestUrl = $"/api/{env.Version}/webhooks/{id}";
select env.Client.Get<RetrieveWebhookResponse>(requestUrl);
    }
    */

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, RetrieveBatchStatusInformationResponse>>>
        RetrieveBatchStatusInformation(Guid id)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/webhooks/{id}/batch-status"
            select env.Client.Get<RetrieveBatchStatusInformationResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, RetrieveBatchStatusInformationResponse>>>
        RetrieveBatchStatusInformation(Guid id, int limit)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/webhooks/{id}/batch-status?limit={limit}"
            select env.Client.Get<RetrieveBatchStatusInformationResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, UpdateWebhookResponse>>> UpdateWebhook(
        Guid id, UpdateWebhookRequest request)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/webhooks/{id}"
            select env.Client.Put(requestUrl, request)
                .MapAsync(ToResponse<UpdateWebhookResponse>);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, Unit>>> DeleteWebhook(Guid id)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/webhooks/{id}"
            select env.Client.Delete(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, ListWebhooksResponse>>> ListWebhooks()
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/webhooks"
            select env.Client.Get<ListWebhooksResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, ListWebhooksResponse>>> ListWebhooks(
        string timezone)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/webhooks?timezone={timezone}"
            select env.Client.Get<ListWebhooksResponse>(requestUrl);
    }
}