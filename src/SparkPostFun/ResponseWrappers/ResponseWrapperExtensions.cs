using System.Net;
using LanguageExt;
using SparkPostFun.Sending;

namespace SparkPostFun.ResponseWrappers
{
    public static class ResponseWrapperExtensions
    {
        public static RetrieveTemplateResponseWrapper Wrap(Either<ErrorResponse, RetrieveTemplateResponse> response)
        {
            return response.Match(
                Success,
                Fail);
        }

        private static RetrieveTemplateResponseWrapper Success(RetrieveTemplateResponse response) => new RetrieveTemplateResponseWrapper
        {
            Id = response.Results.Id,
            Name = response.Results.Name,
            Description = response.Results.Description,
            Content = response.Results.Content,
            Published = response.Results.Published,
            Options = response.Results.Options,
            HasDraft = response.Results.HasDraft,
            HasPublished = response.Results.HasPublished,
            LastUpdateTime = response.Results.LastUpdateTime,
            LastUse = response.Results.LastUse,
            SharedWithSubaccounts = response.Results.SharedWithSubaccounts,
            SubaccountId = response.Results.SubaccountId,

            StatusCode = HttpStatusCode.OK
        };

        private static RetrieveTemplateResponseWrapper Fail(ErrorResponse response) => new RetrieveTemplateResponseWrapper
        {
            StatusCode = response.StatusCode,
            Errors = response.Errors
        };
    }

}
