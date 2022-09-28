using System.Threading.Tasks;
using LanguageExt;
using static SparkPostFun.ClientExtensions;

namespace SparkPostFun.Accounts
{
    public static class ClientSubaccountExtensions
    {
        public static Task<Either<SubaccountErrorResponse, CreateSubaccountResponse>> CreateSubaccount(this Client @this, CreateSubaccount request)
        {
            var requestUrl = $"/api/{@this.Version}/subaccounts";
            return @this.Post(requestUrl, request)
                .MapAsync(ToResponse<SubaccountErrorResponse, CreateSubaccountResponse>);
        }

        public static Task<Either<ErrorResponse, RetrieveSubaccountResponse>> RetrieveSubaccount(this Client @this, int id)
        {
            var requestUrl = $"/api/{@this.Version}/subaccounts/{id}";
            return @this.Get<RetrieveSubaccountResponse>(requestUrl);
        }

        public static Task<Either<SubaccountErrorResponse, UpdateSubaccountResponse>> UpdateSubaccount(this Client @this, int id, UpdateSubaccount request)
        {
            var requestUrl = $"/api/{@this.Version}/subaccounts/{id}";
            return @this.Put(requestUrl, request)
                .MapAsync(ToResponse<SubaccountErrorResponse, UpdateSubaccountResponse>);
        }

        public static Task<Either<ErrorResponse, ListSubaccountsResponse>> ListSubaccounts(this Client @this)
        {
            var requestUrl = $"/api/{@this.Version}/subaccounts";
            return @this.Get<ListSubaccountsResponse>(requestUrl);
        }

        public static Task<Either<ErrorResponse, RetrieveSubaccountsSummaryResponse>> RetrieveSubaccountsSummary(this Client @this)
        {
            var requestUrl = $"/api/{@this.Version}/subaccounts/summary";
            return @this.Get<RetrieveSubaccountsSummaryResponse>(requestUrl);
        }
    }
}