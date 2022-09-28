using System.Threading.Tasks;
using LanguageExt;

namespace SparkPostFun.Sending
{
    public static class ClientRecipientValidationExtensions
    {
        public static Task<Either<ErrorResponse, EmailAddressValidationResponse>> EmailAddressValidation(this Client @this, string address)
        {
            var requestUrl = $"/api/{@this.Version}/recipient-validation/single/{address}";
            return @this.Get<EmailAddressValidationResponse>(requestUrl);
        }
    }
}