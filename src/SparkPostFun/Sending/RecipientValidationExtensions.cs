using System.Threading.Tasks;
using LanguageExt;
using static LanguageExt.Prelude;

namespace SparkPostFun.Sending
{
    public static class RecipientValidationExtensions
    {
        public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, EmailAddressValidationResponse>>> 
            EmailAddressValidation(string address)
        {
            return 
                from env in ask<SparkPostEnvironment>()
                let requestUrl = $"/api/{env.Version}/recipient-validation/single/{address}"
                select env.Client.Get<EmailAddressValidationResponse>(requestUrl);
        }
    }
}