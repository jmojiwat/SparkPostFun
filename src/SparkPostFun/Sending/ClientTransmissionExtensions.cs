using LanguageExt;
using static SparkPostFun.ClientExtensions;

namespace SparkPostFun.Sending
{
    public static class ClientTransmissionExtensions
    {
        public static Task<Either<ErrorResponse, CreateTransmissionResponse>> CreateTransmission(this Client client, CreateTransmission request)
        {
            var requestUrl = $"/api/{client.Version}/transmissions/";
            var requestWithParsedRecipients = TransmissionExtensions.ParseTransmission(request);
            return client.Post(requestUrl, request)
                .MapAsync(ToResponse<CreateTransmissionResponse>);
        }

        public static Task<Either<ErrorResponse, CreateTransmissionResponse>> CreateTransmission(this Client client, CreateTransmission request,
            int maximumRecipientErrors)
        {
            var requestUrl = $"/api/{client.Version}/transmissions/?{maximumRecipientErrors}";
            return client.Post(requestUrl, request)
                .MapAsync(ToResponse<CreateTransmissionResponse>);
        }

        public static Task<Either<ErrorResponse, Unit>> DeleteScheduledTransmissionsByCampaign(this Client @this, string campaignId)
        {
            var requestUrl = $"/api/{@this.Version}/transmissions?campaign_id={campaignId}";
            return @this.Delete(requestUrl);
        }
    }
}