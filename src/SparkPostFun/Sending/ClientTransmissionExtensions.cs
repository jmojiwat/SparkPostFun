using LanguageExt;
using static SparkPostFun.ClientExtensions;
using static SparkPostFun.Sending.TransmissionExtensions;

namespace SparkPostFun.Sending;

public static class ClientTransmissionExtensions
{
    public static Task<Either<ErrorResponse, CreateTransmissionResponse>> CreateTransmission(this Client client, Transmission request)
    {
        var requestUrl = $"/api/{client.Version}/transmissions/";
        var requestWithParsedRecipients = HandleCcAndBccRecipients(request);
        return client.Post(requestUrl, requestWithParsedRecipients)
            .MapAsync(ToResponse<CreateTransmissionResponse>);
    }

    public static Task<Either<ErrorResponse, CreateTransmissionResponse>> CreateTransmission(this Client client, Transmission request,
        int maximumRecipientErrors)
    {
        var requestUrl = $"/api/{client.Version}/transmissions/?{maximumRecipientErrors}";
        var requestWithParsedRecipients = HandleCcAndBccRecipients(request);
        return client.Post(requestUrl, requestWithParsedRecipients)
            .MapAsync(ToResponse<CreateTransmissionResponse>);
    }

    public static Task<Either<ErrorResponse, Unit>> DeleteScheduledTransmissionsByCampaign(this Client @this, string campaignId)
    {
        var requestUrl = $"/api/{@this.Version}/transmissions?campaign_id={campaignId}";
        return @this.Delete(requestUrl);
    }
}