using LanguageExt;
using static SparkPostFun.ClientExtensions;

namespace SparkPostFun.Analytics;

public static class ClientWebhooksExtensions
{
    public static Task<Either<CreateWebhookErrorResponse, CreateWebhookResponse>> CreateWebhook(this Client @this, CreateWebhookRequest request)
    {
        var requestUrl = $"/api/{@this.Version}/webhooks";
        return @this.Post(requestUrl, request)
            .MapAsync(ToResponse<CreateWebhookErrorResponse, CreateWebhookResponse>);
    }

    public static Task<Either<ErrorResponse, ValidateWebhookResponse>> ValidateWebhook(this Client @this, Guid id, ValidateWebhookRequest request)
    {
        throw new NotImplementedException();
        
        var requestUrl = $"/api/{@this.Version}/webhooks/{id}/validate";
        return @this.Post(requestUrl, request)
            .MapAsync(ToResponse<ValidateWebhookResponse>);
    }

    public static Task<Either<ErrorResponse, RetrieveWebhookResponse>> RetrieveWebhook(this Client @this, Guid id)
    {
        throw new NotImplementedException();
        var requestUrl = $"/api/{@this.Version}/webhooks/{id}";
        return @this.Get<RetrieveWebhookResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, RetrieveBatchStatusInformationResponse>> RetrieveBatchStatusInformation(this Client @this, Guid id)
    {
        var requestUrl = $"/api/{@this.Version}/webhooks/{id}/batch-status";
        return @this.Get<RetrieveBatchStatusInformationResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, RetrieveBatchStatusInformationResponse>> RetrieveBatchStatusInformation(this Client @this, Guid id, int limit)
    {
        var requestUrl = $"/api/{@this.Version}/webhooks/{id}/batch-status?limit={limit}";
        return @this.Get<RetrieveBatchStatusInformationResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, UpdateWebhookResponse>> UpdateWebhook(this Client @this, Guid id, UpdateWebhookRequest request)
    {
        var requestUrl = $"/api/{@this.Version}/webhooks/{id}";
        return @this.Put(requestUrl, request)
            .MapAsync(ToResponse<UpdateWebhookResponse>);
    }

    public static Task<Either<ErrorResponse, Unit>> DeleteWebhook(this Client @this, Guid id)
    {
        var requestUrl = $"/api/{@this.Version}/webhooks/{id}";
        return @this.Delete(requestUrl);
    }

    public static Task<Either<ErrorResponse, ListWebhooksResponse>> ListWebhooks(this Client @this)
    {
        var requestUrl = $"/api/{@this.Version}/webhooks";
        return @this.Get<ListWebhooksResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, ListWebhooksResponse>> ListWebhooks(this Client @this, string timezone)
    {
        var requestUrl = $"/api/{@this.Version}/webhooks?timezone={timezone}";
        return @this.Get<ListWebhooksResponse>(requestUrl);
    }
}