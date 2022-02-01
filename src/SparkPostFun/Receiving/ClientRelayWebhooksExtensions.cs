using LanguageExt;
using SparkPostFun.Analytics;
using static SparkPostFun.ClientExtensions;

namespace SparkPostFun.Receiving;

public static class ClientRelayWebhooksExtensions
{
    public static Task<Either<CreateRelayWebhookErrorResponse, CreateRelayWebhookResponse>> CreateRelayWebhook(this Client @this, CreateRelayWebhook request)
    {
        var requestUrl = $"/api/{@this.Version}/relay-webhooks";
        return @this.Post(requestUrl, request)
            .MapAsync(ToResponse<CreateRelayWebhookErrorResponse, CreateRelayWebhookResponse>);
    }

    public static Task<Either<ErrorResponse, ValidateRelayWebhookResponse>> ValidateRelayWebhook(this Client @this, Guid id, ValidateRelayWebhook request)
    {
        var requestUrl = $"/api/{@this.Version}/relay-webhooks/{id}/validate";
        return @this.Post(requestUrl, request)
            .MapAsync(ToResponse<ValidateRelayWebhookResponse>);
    }

    public static Task<Either<ErrorResponse, RetrieveRelayWebhookResponse>> RetrieveRelayWebhook(this Client @this, Guid id)
    {
        var requestUrl = $"/api/{@this.Version}/relay-webhooks/{id}";
        return @this.Get<RetrieveRelayWebhookResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, UpdateWebhookResponse>> UpdateRelayWebhook(this Client @this, Guid id, UpdateRelayWebhookRequest request)
    {
        var requestUrl = $"/api/{@this.Version}/relay-webhooks/{id}";
        return @this.Put(requestUrl, request)
            .MapAsync(ToResponse<UpdateWebhookResponse>);
    }

    public static Task<Either<ErrorResponse, Unit>> DeleteRelayWebhook(this Client @this, string id)
    {
        var requestUrl = $"/api/{@this.Version}/relay-webhooks/{id}";
        return @this.Delete(requestUrl);
    }

    public static Task<Either<ErrorResponse, ListRelayWebhooksResponse>> ListRelayWebhooks(this Client @this)
    {
        var requestUrl = $"/api/{@this.Version}/relay-webhooks";
        return @this.Get<ListRelayWebhooksResponse>(requestUrl);
    }

}