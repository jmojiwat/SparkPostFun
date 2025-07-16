using System.Threading.Tasks;
using LanguageExt;
using static LanguageExt.Prelude;

namespace SparkPostFun.Analytics;

public static class SeedListExtensions
{
    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, SeedListResponse>>> RetrieveSeedList()
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/seeds"
            select env.Client.Get<SeedListResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, SeedListResponse>>>
        RetrieveSubaccountSeedList(int subaccountId)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/seeds"
            select env.Client.GetWithSubaccount<SeedListResponse>(requestUrl, subaccountId);
    }
}