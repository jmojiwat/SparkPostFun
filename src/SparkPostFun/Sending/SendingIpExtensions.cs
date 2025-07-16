using System.Threading.Tasks;
using LanguageExt;
using static SparkPostFun.ClientExtensions;
using static LanguageExt.Prelude;

namespace SparkPostFun.Sending
{
    public static class SendingIpExtensions
    {
        public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, ListSendingIpsResponse>>> ListSendingIps()
        {
            return 
                from env in ask<SparkPostEnvironment>()
                let requestUrl = $"/api/{env.Version}/sending-ips"
                select env.Client.Get<ListSendingIpsResponse>(requestUrl);
        }

        public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, RetrieveSendingIpResponse>>> RetrieveSendingIp(string externalIp)
        {
            return 
                from env in ask<SparkPostEnvironment>()
                let requestUrl = $"/api/{env.Version}/sending-ips/{externalIp}"
                select env.Client.Get<RetrieveSendingIpResponse>(requestUrl);
        }

        public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, UpdateSendingIpResponse>>> UpdateSendingIp(string externalIp,
            UpdateSendingIp updateSendingIp)
        {
            return 
                from env in ask<SparkPostEnvironment>()
                let requestUrl = $"/api/{env.Version}/sending-ips/{externalIp}"
                select env.Client.Put(requestUrl, updateSendingIp)
                    .MapAsync(ToResponse<UpdateSendingIpResponse>);
        }
    }
}