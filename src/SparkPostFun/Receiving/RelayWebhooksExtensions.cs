using System;
using System.Threading.Tasks;
using LanguageExt;
using static SparkPostFun.ClientExtensions;
using static LanguageExt.Prelude;

namespace SparkPostFun.Receiving;

public static class RelayWebhooksExtensions
{
    public static
        Reader<SparkPostEnvironment, Task<Either<CreateRelayWebhookErrorResponse, CreateRelayWebhookResponse>>>
        CreateRelayWebhook(CreateRelayWebhook request)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/relay-webhooks"
            select env.Client.Post(requestUrl, request)
                .MapAsync(ToResponse<CreateRelayWebhookErrorResponse, CreateRelayWebhookResponse>);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, ValidateRelayWebhookResponse>>>
        ValidateRelayWebhook(Guid id, ValidateRelayWebhook request)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/relay-webhooks/{id}/validate"
            select env.Client.Post(requestUrl, request)
                .MapAsync(ToResponse<ValidateRelayWebhookResponse>);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, RetrieveRelayWebhookResponse>>>
        RetrieveRelayWebhook(Guid id)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/relay-webhooks/{id}"
            select env.Client.Get<RetrieveRelayWebhookResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, UpdateWebhookResponse>>> UpdateRelayWebhook(
        Guid id, UpdateRelayWebhookRequest request)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/relay-webhooks/{id}"
            select env.Client.Put(requestUrl, request)
                .MapAsync(ToResponse<UpdateWebhookResponse>);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, Unit>>> DeleteRelayWebhook(string id)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/relay-webhooks/{id}"
            select env.Client.Delete(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, ListRelayWebhooksResponse>>>
        ListRelayWebhooks(this Client @this)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/relay-webhooks"
            select env.Client.Get<ListRelayWebhooksResponse>(requestUrl);
    }
}