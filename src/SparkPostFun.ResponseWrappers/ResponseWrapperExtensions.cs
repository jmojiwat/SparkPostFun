using System.Net;
using LanguageExt;
using SparkPostFun.Sending;

namespace SparkPostFun.ResponseWrappers;

public static class ResponseWrapperExtensions
{
    public static CreateTransmissionResponseWrapper Wrap(Either<ErrorResponse, CreateTransmissionResponse> response)
    {
        return response.Match(
            CreateTransmissionSuccess,
            CreateTransmissionFail);
    }

    public static UnitResponseWrapper Wrap(Either<ErrorResponse, Unit> response)
    {
        return response.Match(
            UnitSuccess,
            UnitFail);
    }

    public static CreateAbTestResponseWrapper Wrap(Either<ErrorResponse, CreateAbTestResponse> response)
    {
        return response.Match(
            CreateAbTestSuccess,
            CreateAbTestFail);
    }

    public static RetrieveTemplateResponseWrapper Wrap(Either<ErrorResponse, RetrieveTemplateResponse> response)
    {
        return response.Match(
            RetrieveTemplateSuccess,
            RetrieveTemplateFail);
    }

    private static CreateTransmissionResponseWrapper CreateTransmissionSuccess(CreateTransmissionResponse response) => new()
    {
        RecipientToErrors = response.Results.RecipientToErrors,
        TotalAcceptedRecipients = response.Results.TotalAcceptedRecipients,
        TotalRejectedRecipients = response.Results.TotalRejectedRecipients,
        Id = response.Results.Id,
        Errors = response.Errors.Map(error => new Error
        {
            Code = error.Code,
            Message = error.Message
        }).ToList(),

        StatusCode = HttpStatusCode.OK
    };

    private static CreateTransmissionResponseWrapper CreateTransmissionFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static RetrieveTemplateResponseWrapper RetrieveTemplateSuccess(RetrieveTemplateResponse response) => new()
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

    private static RetrieveTemplateResponseWrapper RetrieveTemplateFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static CreateAbTestResponseWrapper CreateAbTestSuccess(CreateAbTestResponse response) => new()
    {
        Id = response.Results.Id,

        StatusCode = HttpStatusCode.OK
    };

    private static UnitResponseWrapper UnitSuccess(Unit unit) => new()
    {
        StatusCode = HttpStatusCode.OK
    };

    private static UnitResponseWrapper UnitFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static CreateAbTestResponseWrapper CreateAbTestFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };
}