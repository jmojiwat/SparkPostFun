using LanguageExt;

namespace SparkPostFun.Receiving
{
    public static class InboundDomainExtensions
    {
        public static Task<Either<ErrorResponse, Unit>> CreateInboundDomain(InboundDomain inboundDomain)
        {
            throw new NotImplementedException();
        }

        public static Task<Either<ErrorResponse, RetrieveInboundDomainResponse>> RetrieveInboundDomain(string domain)
        {
            throw new NotImplementedException();
        }

        public static Task<Either<ErrorResponse, Unit>> DeleteInboundDomain(string domain)
        {
            throw new NotImplementedException();
        }

        public static Task<Either<ErrorResponse, Unit>> ListInboundDomains()
        {
            throw new NotImplementedException();
        }
    }
}