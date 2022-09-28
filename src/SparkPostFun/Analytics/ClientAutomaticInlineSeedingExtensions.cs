using System.Threading.Tasks;
using LanguageExt;
using static SparkPostFun.ClientExtensions;

namespace SparkPostFun.Analytics
{
    public static class ClientAutomaticInlineSeedingExtensions
    {
        public static Task<Either<ErrorResponse, SeedConfigResponse>> GetSeedConfig(this Client @this)
        {
            var requestUrl = $"/api/{@this.Version}/inline-seeds/config";
            return @this.Get<SeedConfigResponse>(requestUrl);
        }
    
        public static Task<Either<ErrorResponse, SeedConfigResponse>> CreateSeedConfig(this Client @this, SeedConfig request)
        {
            var requestUrl = $"/api/{@this.Version}/inline-seeds/config";
            return @this.Post(requestUrl, request)
                .MapAsync(ToResponse<SeedConfigResponse>);
        }

        public static Task<Either<ErrorResponse, SeedConfigResponse>> UpdateSeedConfig(this Client @this, string id, SeedConfig request)
        {
            var requestUrl = $"/api/{@this.Version}/inline-seeds/config";
            return @this.Put(requestUrl, request)
                .MapAsync(ToResponse<SeedConfigResponse>);
        }

        public static Task<Either<ErrorResponse, ListActiveCampaignsResponse>> ListActiveCampaigns(this Client @this)
        {
            var requestUrl = $"/api/{@this.Version}/inline-seeds/status";
            return @this.Get<ListActiveCampaignsResponse>(requestUrl);
        }

        public static Task<Either<ErrorResponse, ListActiveCampaignsResponse>> ListActiveCampaigns(this Client @this, int subaccountId)
        {
            var requestUrl = $"/api/{@this.Version}/inline-seeds/status";
            return @this.GetWithSubaccount<ListActiveCampaignsResponse>(requestUrl, subaccountId);
        }

        public static Task<Either<ErrorResponse, CheckCampainStatusResponse>> CheckCampaignStatus(this Client @this, string id, string sendingDomain)
        {
            var requestUrl = $"/api/{@this.Version}/inline-seeds/status?id={id}&sending_domain={sendingDomain}";
            return @this.Get<CheckCampainStatusResponse>(requestUrl);
        }

        public static Task<Either<ErrorResponse, SeedOptionsResponse>> GetOptions(this Client @this)
        {
            var requestUrl = $"/api/{@this.Version}/inline-seeds/options";
            return @this.Get<SeedOptionsResponse>(requestUrl);
        }

        public static Task<Either<ErrorResponse, SubaccountSeedOptionsResponse>> GetSubaccountOptions(this Client @this, int subaccountId)
        {
            var requestUrl = $"/api/{@this.Version}/inline-seeds/options";
            return @this.GetWithSubaccount<SubaccountSeedOptionsResponse>(requestUrl, subaccountId);
        }

        public static Task<Either<ErrorResponse, Unit>> UpdateOptions(this Client @this, bool enabled)
        {
            var request = new UpdateOptions
            {
                Enabled = enabled
            };
        
            var requestUrl = $"/api/{@this.Version}/inline-seeds/options";
            return @this.Put(requestUrl, request)
                .MapAsync(ToResponse<Unit>);
        }

        public static Task<Either<ErrorResponse, Unit>> UpdateSubaccountOptions(this Client @this, bool enabled, int subaccountId)
        {
            var request = new UpdateOptions
            {
                Enabled = enabled
            };
        
            var requestUrl = $"/api/{@this.Version}/inline-seeds/options";
            return @this.PutWithSubaccount(requestUrl, request, subaccountId)
                .MapAsync(ToResponse<Unit>);
        }

    }
}