using System.Net;
using LanguageExt;
using SparkPostFun.Accounts;
using SparkPostFun.Sending;

namespace SparkPostFun.ResponseWrappers;

public static class ResponseExtensions
{
    public static async Task<ResponseWrapper<CreateSendingDomainResponseResult>> Wrap(Task<Either<ErrorResponse, CreateSendingDomainResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<CreateSendingDomainResponseResult>);

    public static async Task<AddDataPrivacyResponseWrapper> Wrap(Task<Either<DataPrivacyErrorResponse, AddDataPrivacyResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            AddDataPrivacySuccess,
            AddDataPrivacyFail);

    public static async Task<CreateSubaccountResponseWrapper> Wrap(Task<Either<SubaccountErrorResponse, CreateSubaccountResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            CreateSubaccountSuccess,
            CreateSubaccountFail);

    public static async Task<ResponseWrapper<RetrieveSubaccountResponseResult>> Wrap(Task<Either<ErrorResponse, RetrieveSubaccountResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<RetrieveSubaccountResponseResult>);

    public static async Task<ResponseWrapper<UpdateSubaccountResponseResult>> Wrap(Task<Either<ErrorResponse, UpdateSubaccountResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<UpdateSubaccountResponseResult>);

    public static async Task<ListSubaccountsResponseWrapper> Wrap(Task<Either<SubaccountErrorResponse, ListSubaccountsResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            ListSubaccountsSuccess,
            ListSubaccountsFail);

    public static async Task<ResponseWrapper<RetrieveSubaccountsSummaryResponseResult>> Wrap(Task<Either<ErrorResponse, RetrieveSubaccountsSummaryResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<RetrieveSubaccountsSummaryResponseResult>);

    public static async Task<ResponseWrapper<CreateIpPoolResponseResult>> Wrap(Task<Either<ErrorResponse, CreateIpPoolResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<CreateIpPoolResponseResult>);

    public static async Task<ResponseWrapper<RetrieveIpPoolResponseResult>> Wrap(Task<Either<ErrorResponse, RetrieveIpPoolResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<RetrieveIpPoolResponseResult>);

    public static async Task<ResponseWrapper<UpdateIpPoolResponseResult>> Wrap(Task<Either<ErrorResponse, UpdateIpPoolResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<UpdateIpPoolResponseResult>);

    public static async Task<ResponseListResultWrapper<ListIpPoolsResponseResult>> Wrap(Task<Either<ErrorResponse, ListIpPoolsResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            ListSuccess,
            ListResultFail<ListIpPoolsResponseResult>);

    public static async Task<ResponseWrapper<RetrieveSendingIpResponseResult>> Wrap(Task<Either<ErrorResponse, RetrieveSendingIpResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<RetrieveSendingIpResponseResult>);

    public static async Task<ResponseWrapper<UpdateSendingIpResponseResult>> Wrap(Task<Either<ErrorResponse, UpdateSendingIpResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<UpdateSendingIpResponseResult>);

    public static async Task<ResponseListResultWrapper<ListSendingIpsResponseResult>> Wrap(Task<Either<ErrorResponse, ListSendingIpsResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            ListSuccess,
            ListResultFail<ListSendingIpsResponseResult>);

    public static async Task<ResponseWrapper<BulkCreateOrUpdateSuppressionsResponseResult>> Wrap(Task<Either<ErrorResponse, BulkCreateOrUpdateSuppressionsResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<BulkCreateOrUpdateSuppressionsResponseResult>);

    public static async Task<ResponseWrapper<CreateOrUpdateSuppressionResponseResult>> Wrap(Task<Either<ErrorResponse, CreateOrUpdateSuppressionResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<CreateOrUpdateSuppressionResponseResult>);

    public static async Task<RetrieveSuppressionResponseWrapper> Wrap(Task<Either<ErrorResponse, RetrieveSuppressionResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            RetrieveSuppressionSuccess,
            RetrieveSuppressionFail);

    public static async Task<SearchSuppressionsResponseWrapper> Wrap(Task<Either<ErrorResponse, SearchSuppressionsResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            SearchSuppressionsSuccess,
            SearchSuppressionsFail);

    public static async Task<ResponseWrapper<RetrieveSuppressionSummaryResponseResult>> Wrap(Task<Either<ErrorResponse, RetrieveSuppressionSummaryResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<RetrieveSuppressionSummaryResponseResult>);

    public static async Task<ResponseWrapper<EmailAddressValidationResponseResult>> Wrap(Task<Either<ErrorResponse, EmailAddressValidationResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<EmailAddressValidationResponseResult>);

    public static async Task<CreateTemplateResponseWrapper> Wrap(Task<Either<TemplateErrorResponse, CreateTemplateResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            CreateTemplateSuccess,
            CreateTemplateFail);

    public static async Task<ResponseWrapper<CreateSnippetResponseResult>> Wrap(Task<Either<ErrorResponse, CreateSnippetResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<CreateSnippetResponseResult>);

    public static async Task<ResponseWrapper<RetrieveSnippetResponseResult>> Wrap(Task<Either<ErrorResponse, RetrieveSnippetResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<RetrieveSnippetResponseResult>);

    public static async Task<ResponseListResultWrapper<ListSnippetsResponseResult>> Wrap(Task<Either<ErrorResponse, ListSnippetsResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            ListSuccess,
            ListResultFail<ListSnippetsResponseResult>);

    public static async Task<ResponseWrapper<CreateRecipientListResponseResult>> Wrap(Task<Either<ErrorResponse, CreateRecipientListResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<CreateRecipientListResponseResult>);

    public static async Task<ResponseWrapper<RetrieveRecipientListResponseResult>> Wrap(Task<Either<ErrorResponse, RetrieveRecipientListResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<RetrieveRecipientListResponseResult>);

    public static async Task<ResponseWrapper<UpdateRecipientListResponseResult>> Wrap(Task<Either<ErrorResponse, UpdateRecipientListResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<UpdateRecipientListResponseResult>);

    public static async Task<ResponseListResultWrapper<ListRecipientListsResponseResult>> Wrap(Task<Either<ErrorResponse, ListRecipientListsResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            ListResultFail<ListRecipientListsResponseResult>);

    public static async Task<ResponseListResultWrapper<ListSendingDomainsResponseResult>> Wrap(Task<Either<ErrorResponse, ListSendingDomainsResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            ListSuccess,
            ListResultFail<ListSendingDomainsResponseResult>);

    public static async Task<ResponseWrapper<RetrieveSendingDomainResponseResult>> Wrap(Task<Either<ErrorResponse, RetrieveSendingDomainResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<RetrieveSendingDomainResponseResult>);

    public static async Task<ResponseWrapper<UpdateSendingDomainResponseResult>> Wrap(Task<Either<ErrorResponse, UpdateSendingDomainResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<UpdateSendingDomainResponseResult>);

    public static async Task<ResponseWrapper<VerifySendingDomainResponseResult>> Wrap(Task<Either<ErrorResponse, VerifySendingDomainResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<VerifySendingDomainResponseResult>);

    public static async Task<ResponseWrapper<CreateTrackingDomainResponseResult>> Wrap(Task<Either<ErrorResponse, CreateTrackingDomainResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<CreateTrackingDomainResponseResult>);

    public static async Task<ResponseListResultWrapper<ListTrackingDomainsResponseResult>> Wrap(Task<Either<ErrorResponse, ListTrackingDomainsResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            ListSuccess,
            ListResultFail<ListTrackingDomainsResponseResult>);

    public static async Task<ResponseListResultWrapper<ListTemplatesResponseResult>> Wrap(Task<Either<ErrorResponse, ListTemplatesResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            ListSuccess,
            ListResultFail<ListTemplatesResponseResult>);

    public static async Task<ResponseWrapper<RetrieveTrackingDomainResponseResult>> Wrap(Task<Either<ErrorResponse, RetrieveTrackingDomainResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<RetrieveTrackingDomainResponseResult>);

    public static async Task<ResponseWrapper<UpdateTrackingDomainResponseResult>> Wrap(Task<Either<ErrorResponse, UpdateTrackingDomainResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            UpdateTrackingDomainSuccess,
            Fail<UpdateTrackingDomainResponseResult>);

    public static async Task<ResponseWrapper<TemplateContent>> Wrap(Task<Either<ErrorResponse, PreviewTemplateResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<TemplateContent>);

    public static async Task<ResponseWrapper<IDictionary<string, string>>> Wrap(Task<Either<ErrorResponse, PreviewInlineTemplateResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<IDictionary<string, string>>);

    public static async Task<ResponseWrapper<VerifyTrackingDomainResponseResult>> Wrap(Task<Either<ErrorResponse, VerifyTrackingDomainResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<VerifyTrackingDomainResponseResult>);

    public static async Task<ResponseWrapper<CreateTransmissionResponseResult>> Wrap(Task<Either<ErrorResponse, CreateTransmissionResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<CreateTransmissionResponseResult>);

    public static async Task<ResponseWrapper<RetrieveAccountResponseResult>> Wrap(Task<Either<ErrorResponse, RetrieveAccountResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<RetrieveAccountResponseResult>);

    public static async Task<ResponseWrapper<UpdateAccountResponseResult>> Wrap(Task<Either<ErrorResponse, UpdateAccountResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<UpdateAccountResponseResult>);

    public static async Task<UnitResponseWrapper> Wrap(Task<Either<ErrorResponse, Unit>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            UnitSuccess,
            UnitFail);

    public static async Task<ResponseWrapper<CreateAbTestResponseResult>> Wrap(Task<Either<ErrorResponse, CreateAbTestResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<CreateAbTestResponseResult>);

    public static async Task<ResponseWrapper<RetrieveAbTestResponseResult>> Wrap(Task<Either<ErrorResponse, RetrieveAbTestResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<RetrieveAbTestResponseResult>);

    public static async Task<ResponseWrapper<UpdateAbTestResponseResult>> Wrap(Task<Either<ErrorResponse, UpdateAbTestResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<UpdateAbTestResponseResult>);

    public static async Task<ResponseListResultWrapper<ListAbTestResponseResult>> Wrap(Task<Either<ErrorResponse, ListAbTestsResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            ListResultFail<ListAbTestResponseResult>);

    public static async Task<ResponseWrapper<CreateAbTestDraftResponseResult>> Wrap(Task<Either<ErrorResponse, CreateAbTestDraftResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<CreateAbTestDraftResponseResult>);

    public static async Task<ResponseWrapper<RetrieveAbTestDraftResponseResult>> Wrap(Task<Either<ErrorResponse, RetrieveAbTestDraftResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<RetrieveAbTestDraftResponseResult>);

    public static async Task<ResponseWrapper<UpdateAbTestDraftResponseResult>> Wrap(Task<Either<ErrorResponse, UpdateAbTestDraftResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<UpdateAbTestDraftResponseResult>);

    public static async Task<ResponseWrapper<ScheduleAbTestDraftResponseResult>> Wrap(Task<Either<ErrorResponse, ScheduleAbTestDraftResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<ScheduleAbTestDraftResponseResult>);

    public static async Task<ResponseWrapper<RetrieveTemplateResponseResult>> Wrap(Task<Either<ErrorResponse, RetrieveTemplateResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<RetrieveTemplateResponseResult>);

    private static ResponseWrapper<TResult> Fail<TResult>(ErrorResponse response) where TResult : class => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static ResponseListResultWrapper<TResult> ListResultFail<TResult>(ErrorResponse response) where TResult : class => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };
    
    private static ResponseWrapper<RetrieveTemplateResponseResult> Success(RetrieveTemplateResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };
   
    private static AddDataPrivacyResponseWrapper AddDataPrivacyFail(DataPrivacyErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static AddDataPrivacyResponseWrapper AddDataPrivacySuccess(AddDataPrivacyResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<BulkCreateOrUpdateSuppressionsResponseResult> Success(BulkCreateOrUpdateSuppressionsResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<CreateAbTestDraftResponseResult> Success(CreateAbTestDraftResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<CreateAbTestResponseResult> Success(CreateAbTestResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<CreateIpPoolResponseResult> Success(CreateIpPoolResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<CreateOrUpdateSuppressionResponseResult> Success(CreateOrUpdateSuppressionResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<CreateRecipientListResponseResult> Success(CreateRecipientListResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<CreateSendingDomainResponseResult> Success(CreateSendingDomainResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<CreateSnippetResponseResult> Success(CreateSnippetResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static CreateSubaccountResponseWrapper CreateSubaccountFail(SubaccountErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static CreateSubaccountResponseWrapper CreateSubaccountSuccess(CreateSubaccountResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ListSubaccountsResponseWrapper ListSubaccountsSuccess(ListSubaccountsResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ListSubaccountsResponseWrapper ListSubaccountsFail(SubaccountErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static CreateTemplateResponseWrapper CreateTemplateSuccess(CreateTemplateResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static CreateTemplateResponseWrapper CreateTemplateFail(TemplateErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static ResponseWrapper<CreateTrackingDomainResponseResult> Success(CreateTrackingDomainResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<CreateTransmissionResponseResult> Success(CreateTransmissionResponse response) =>
        new()
        {
            Results = response.Results,
            Errors = response.Errors.Select(error => new Error
                {
                    Code = error.Code,
                    Message = error.Message
                })
                .ToList(),

            StatusCode = HttpStatusCode.OK
        };

    private static ResponseWrapper<EmailAddressValidationResponseResult> Success(EmailAddressValidationResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseListResultWrapper<ListAbTestResponseResult> Success(ListAbTestsResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseListResultWrapper<ListIpPoolsResponseResult> ListSuccess(ListIpPoolsResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseListResultWrapper<ListRecipientListsResponseResult> Success(ListRecipientListsResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseListResultWrapper<ListSendingDomainsResponseResult> ListSuccess(ListSendingDomainsResponse response) =>
        new()
        {
            Results = response.Results,
            StatusCode = HttpStatusCode.OK
        };

    private static ResponseListResultWrapper<ListSendingIpsResponseResult> ListSuccess(ListSendingIpsResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseListResultWrapper<ListSnippetsResponseResult> ListSuccess(ListSnippetsResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseListResultWrapper<ListTemplatesResponseResult> ListSuccess(ListTemplatesResponse response) =>
        new()
        {
            Results = response.Results,
            StatusCode = HttpStatusCode.OK
        };

    private static ResponseListResultWrapper<ListTrackingDomainsResponseResult> ListSuccess(ListTrackingDomainsResponse response) =>
        new()
        {
            Results = response.Results,
            StatusCode = HttpStatusCode.OK
        };

    private static ResponseWrapper<IDictionary<string, string>> Success(PreviewInlineTemplateResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<TemplateContent> Success(PreviewTemplateResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<RetrieveAbTestDraftResponseResult> Success(RetrieveAbTestDraftResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<RetrieveAbTestResponseResult> Success(RetrieveAbTestResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<RetrieveAccountResponseResult> Success(RetrieveAccountResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<RetrieveIpPoolResponseResult> Success(RetrieveIpPoolResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<RetrieveRecipientListResponseResult> Success(RetrieveRecipientListResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<RetrieveSendingDomainResponseResult> Success(RetrieveSendingDomainResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<RetrieveSendingIpResponseResult> Success(RetrieveSendingIpResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<RetrieveSnippetResponseResult> Success(RetrieveSnippetResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<RetrieveSubaccountsSummaryResponseResult> Success(RetrieveSubaccountsSummaryResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<RetrieveSubaccountResponseResult> Success(RetrieveSubaccountResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static RetrieveSuppressionResponseWrapper RetrieveSuppressionFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static RetrieveSuppressionResponseWrapper RetrieveSuppressionSuccess(RetrieveSuppressionResponse response) => new()
    {
        Results = response.Results,
        Links = response.Links,
        TotalCount = response.TotalCount,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<RetrieveSuppressionSummaryResponseResult> Success(RetrieveSuppressionSummaryResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<RetrieveTrackingDomainResponseResult> Success(
        RetrieveTrackingDomainResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<ScheduleAbTestDraftResponseResult> Success(ScheduleAbTestDraftResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static SearchSuppressionsResponseWrapper SearchSuppressionsFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static SearchSuppressionsResponseWrapper SearchSuppressionsSuccess(SearchSuppressionsResponse response) => new()
    {
        Results = response.Results,
        Links = response.Links,
        TotalCount = response.TotalCount,
        StatusCode = HttpStatusCode.OK
    };

    private static UnitResponseWrapper UnitFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static UnitResponseWrapper UnitSuccess(Unit unit) => new()
    {
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<UpdateAbTestDraftResponseResult> Success(UpdateAbTestDraftResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<UpdateAbTestResponseResult> Success(UpdateAbTestResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<UpdateAccountResponseResult> Success(UpdateAccountResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<UpdateIpPoolResponseResult> Success(UpdateIpPoolResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<UpdateRecipientListResponseResult> Success(UpdateRecipientListResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<UpdateSendingDomainResponseResult> Success(UpdateSendingDomainResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<UpdateSendingIpResponseResult> Success(UpdateSendingIpResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<UpdateSubaccountResponseResult> Success(UpdateSubaccountResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<UpdateTrackingDomainResponseResult> UpdateTrackingDomainSuccess(UpdateTrackingDomainResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<VerifySendingDomainResponseResult> Success(VerifySendingDomainResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<VerifyTrackingDomainResponseResult> Success(VerifyTrackingDomainResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };
}