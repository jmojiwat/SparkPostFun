using System.Collections.Generic;

namespace SparkPostFun.Accounts
{
    public record DataPrivacyErrorResponse : BaseErrorResponse
    {
        public IList<DataPrivacyError> Errors { get; init; } = new List<DataPrivacyError>();
    }
}