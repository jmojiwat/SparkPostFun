using System.Threading.Tasks;
using LanguageExt;
using static SparkPostFun.ClientExtensions;
using static LanguageExt.Prelude;

namespace SparkPostFun.Analytics;

public static class AutomaticInlineSeedingExtensions
{
    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, SeedConfigResponse>>>
        GetSeedConfig()
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/inline-seeds/config"
            select env.Client.Get<SeedConfigResponse>(requestUrl);
    }
    
    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, SeedConfigResponse>>>
        CreateSeedConfig(SeedConfig request)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/inline-seeds/config"
            select env.Client.Post(requestUrl, request)
                .MapAsync(ToResponse<SeedConfigResponse>);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, SeedConfigResponse>>> 
        UpdateSeedConfig(string id, SeedConfig request)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/inline-seeds/config"
            select env.Client.Put(requestUrl, request)
                .MapAsync(ToResponse<SeedConfigResponse>);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, ListActiveCampaignsResponse>>>
        ListActiveCampaigns()
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/inline-seeds/status"
            select env.Client.Get<ListActiveCampaignsResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, ListActiveCampaignsResponse>>>
        ListActiveCampaigns(int subaccountId)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/inline-seeds/status"
            select env.Client.GetWithSubaccount<ListActiveCampaignsResponse>(requestUrl, subaccountId);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, CheckCampainStatusResponse>>>
        CheckCampaignStatus(string id, string sendingDomain)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/inline-seeds/status?id={id}&sending_domain={sendingDomain}"
            select env.Client.Get<CheckCampainStatusResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, SeedOptionsResponse>>>
        GetOptions()
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/inline-seeds/options"
            select env.Client.Get<SeedOptionsResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, SubaccountSeedOptionsResponse>>>
        GetSubaccountOptions(int subaccountId)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/inline-seeds/options"
            select env.Client.GetWithSubaccount<SubaccountSeedOptionsResponse>(requestUrl, subaccountId);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, Unit>>> 
        UpdateOptions(bool enabled)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/inline-seeds/options"
            let request = new UpdateOptions { Enabled = enabled }
            select env.Client.Put(requestUrl, request)
                .MapAsync(ToResponse<Unit>);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, Unit>>>
        UpdateSubaccountOptions(bool enabled, int subaccountId)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/inline-seeds/options"
            let request = new UpdateOptions { Enabled = enabled }
            select env.Client.PutWithSubaccount(requestUrl, request, subaccountId)
                .MapAsync(ToResponse<Unit>);
    }

}