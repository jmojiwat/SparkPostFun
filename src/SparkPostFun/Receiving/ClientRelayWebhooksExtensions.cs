using LanguageExt;
using SparkPostFun.Analytics;

namespace SparkPostFun.Receiving;

public static class ClientRelayWebhooksExtensions
{
    public static Task<Either<CreateRelayWebhookErrorResponse, CreateRelayWebhookResponse>> CreateRelayWebhook(this Client @this, CreateRelayWebhookRequest request)
    {
        var requestUrl = $"/api/{@this.Version}/relay-webhooks";
        return @this.Post(requestUrl, request)
            .MapAsync(ClientExtensions.ToResponse<CreateRelayWebhookErrorResponse, CreateRelayWebhookResponse>);
    }

    public static Task<Either<ErrorResponse, ValidateRelayWebhookResponse>> ValidateRelayWebhook(this Client @this, Guid id, ValidateWebhookRequest request)
    {
        throw new NotImplementedException();
        
        var requestUrl = $"/api/{@this.Version}/relay-webhooks/{id}/validate";
        return @this.Post(requestUrl, request)
            .MapAsync(ClientExtensions.ToResponse<ValidateRelayWebhookResponse>);
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
            .MapAsync(ClientExtensions.ToResponse<UpdateWebhookResponse>);
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