using System.Threading.Tasks;
using LanguageExt;
using static SparkPostFun.ClientExtensions;
using static LanguageExt.Prelude;

namespace SparkPostFun.Accounts;

public static class SubaccountExtensions
{
    public static Reader<SparkPostEnvironment, Task<Either<SubaccountErrorResponse, CreateSubaccountResponse>>>
        CreateSubaccount(CreateSubaccount request)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/subaccounts"
            select env.Client.Post(requestUrl, request)
                .MapAsync(ToResponse<SubaccountErrorResponse, CreateSubaccountResponse>);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, RetrieveSubaccountResponse>>>
        RetrieveSubaccount(int id)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/subaccounts/{id}"
            select env.Client.Get<RetrieveSubaccountResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<SubaccountErrorResponse, UpdateSubaccountResponse>>> 
        UpdateSubaccount(int id, UpdateSubaccount request)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/subaccounts/{id}"
            select env.Client.Put(requestUrl, request)
                .MapAsync(ToResponse<SubaccountErrorResponse, UpdateSubaccountResponse>);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, ListSubaccountsResponse>>> 
        ListSubaccounts ()
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/subaccounts"
            select env.Client.Get<ListSubaccountsResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, RetrieveSubaccountsSummaryResponse>>> 
        RetrieveSubaccountsSummary()
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/subaccounts/summary"
            select env.Client.Get<RetrieveSubaccountsSummaryResponse>(requestUrl);
    }
}