using System.Threading.Tasks;
using LanguageExt;

namespace SparkPostFun.Analytics
{
    public static class ClientSeedListExtensions
    {
        public static Task<Either<ErrorResponse, SeedListResponse>> RetrieveSeedList(this Client @this)
        {
            var requestUrl = $"/api/{@this.Version}/seeds";
            return @this.Get<SeedListResponse>(requestUrl);
        }

        public static Task<Either<ErrorResponse, SeedListResponse>> RetrieveSubaccountSeedList(this Client @this, int subaccountId)
        {
            var requestUrl = $"/api/{@this.Version}/seeds";
            return @this.GetWithSubaccount<SeedListResponse>(requestUrl, subaccountId);
        }
    }
}