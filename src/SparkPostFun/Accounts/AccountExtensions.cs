using System.Threading.Tasks;
using LanguageExt;
using static SparkPostFun.ClientExtensions;
using static LanguageExt.Prelude;

namespace SparkPostFun.Accounts;

public static class AccountExtensions
{
    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, RetrieveAccountResponse>>> RetrieveAccount()
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/account"
            select env.Client.Get<RetrieveAccountResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, RetrieveAccountResponse>>> RetrieveAccount(string include)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/account?include={include}"
            select env.Client.Get<RetrieveAccountResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, UpdateAccountResponse>>> UpdateAccount(int id, UpdateAccount request)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/account/{id}"
            select env.Client.Put(requestUrl, request)
                .MapAsync(ToResponse<UpdateAccountResponse>);
    }
}