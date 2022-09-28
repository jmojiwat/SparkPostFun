using System.Collections.Generic;

namespace SparkPostFun.Accounts
{
    public record SubaccountErrorResponse : BaseErrorResponse
    {
        public IList<SubaccountErrorResponseError> Errors { get; init; } = new List<SubaccountErrorResponseError>();
    }
}