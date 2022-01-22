using LanguageExt;
using static SparkPostFun.ClientExtensions;

namespace SparkPostFun.Sending;

public static class ClientSendingIpExtensions
{
    public static Task<Either<ErrorResponse, ListSendingIpsResponse>> ListSendingIps(this Client @this)
    {
        var requestUrl = $"/api/{@this.Version}/sending-ips";
        return @this.Get<ListSendingIpsResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, RetrieveSendingIpResponse>> RetrieveSendingIp(this Client @this, string externalIp)
    {
        var requestUrl = $"/api/{@this.Version}/sending-ips/{externalIp}";
        return @this.Get<RetrieveSendingIpResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, UpdateSendingIpResponse>> UpdateSendingIp(this Client @this, string externalIp,
        UpdateSendingIp updateSendingIp)
    {
        var requestUrl = $"/api/{@this.Version}/sending-ips/{externalIp}";
        return @this.Put(requestUrl, updateSendingIp)
            .MapAsync(ToResponse<UpdateSendingIpResponse>);
    }
}