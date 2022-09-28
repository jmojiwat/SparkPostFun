using System.Threading.Tasks;
using LanguageExt;
using static SparkPostFun.ClientExtensions;

namespace SparkPostFun.Sending
{
    public static class ClientRecipientListExtensions
    {
        public static Task<Either<ErrorResponse, CreateRecipientListResponse>> CreateRecipientList(this Client @this, CreateRecipientList request)
        {
            var requestUrl = $"/api/{@this.Version}/recipient-lists";
            return @this.Post(requestUrl, request)
                .MapAsync(ToResponse<CreateRecipientListResponse>);
        }

        public static Task<Either<ErrorResponse, CreateRecipientListResponse>> CreateRecipientList(this Client @this, CreateRecipientList request,
            int numberOfRecipientErrors)
        {
            var requestUrl = $"/api/{@this.Version}/recipient-lists?num_rcpt_errors={numberOfRecipientErrors}";
            return @this.Post(requestUrl, request)
                .MapAsync(ToResponse<CreateRecipientListResponse>);
        }

        public static Task<Either<ErrorResponse, Unit>> DeleteRecipientList(this Client @this, string id)
        {
            var requestUrl = $"/api/{@this.Version}/recipient-lists/{id}";
            return @this.Delete(requestUrl);
        }

        public static Task<Either<ErrorResponse, ListRecipientListsResponse>> ListRecipientLists(this Client @this)
        {
            var requestUrl = $"/api/{@this.Version}/recipient-lists";
            return @this.Get<ListRecipientListsResponse>(requestUrl);
        }

        public static Task<Either<ErrorResponse, RetrieveRecipientListResponse>> RetrieveRecipientList(this Client @this, string id,
            bool showRecipients = false)
        {
            var requestUrl = $"/api/{@this.Version}/recipient-lists/{id}?show_recipients={showRecipients}";
            return @this.Get<RetrieveRecipientListResponse>(requestUrl);
        }

        public static Task<Either<ErrorResponse, UpdateRecipientListResponse>> UpdateRecipientList(this Client @this, string id, UpdateRecipientList request)
        {
            var requestUrl = $"/api/{@this.Version}/recipient-lists/{id}";
            return @this.Put(requestUrl, request)
                .MapAsync(ToResponse<UpdateRecipientListResponse>);
        }

        public static Task<Either<ErrorResponse, UpdateRecipientListResponse>> UpdateRecipientList(this Client @this, string id, UpdateRecipientList request,
            int numberOfRecipientErrors)
        {
            var requestUrl = $"/api/{@this.Version}/recipient-lists/{id}?num_rcpt_errors={numberOfRecipientErrors}";
            return @this.Put(requestUrl, request)
                .MapAsync(ToResponse<UpdateRecipientListResponse>);
        }
    }
}