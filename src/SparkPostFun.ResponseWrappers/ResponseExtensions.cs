using System.Net;
using LanguageExt;
using SparkPostFun.Accounts;
using SparkPostFun.Sending;

namespace SparkPostFun.ResponseWrappers;

public static class ResponseExtensions
{
    public static async Task<CreateSendingDomainResponseWrapper> Wrap(Task<Either<ErrorResponse, CreateSendingDomainResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            CreateSendingDomainSuccess,
            CreateSendingDomainFail);

    public static async Task<DataPrivacyResponseWrapper> Wrap(Task<Either<DataPrivacyErrorResponse, AddDataPrivacyResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            AddDataPrivacySuccess,
            AddDataPrivacyFail);

    public static async Task<CreateSubaccountResponseWrapper> Wrap(Task<Either<SubaccountErrorResponse, CreateSubaccountResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            CreateSubaccountSuccess,
            CreateSubaccountFail);

    public static async Task<RetrieveSubaccountResponseWrapper> Wrap(Task<Either<ErrorResponse, RetrieveSubaccountResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            RetrieveSubaccountSuccess,
            RetrieveSubaccountFail);

    public static async Task<UpdateSubaccountResponseWrapper> Wrap(Task<Either<ErrorResponse, UpdateSubaccountResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            UpdateSubaccountSuccess,
            UpdateSubaccountFail);

    public static async Task<ListSubaccountsResponseWrapper> Wrap(Task<Either<SubaccountErrorResponse, ListSubaccountsResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            ListSubaccountsSuccess,
            ListSubaccountsFail);

    public static async Task<RetrieveSubaccountsSummaryResponseWrapper> Wrap(Task<Either<ErrorResponse, RetrieveSubaccountsSummaryResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            RetrieveSubaccountsSummarySuccess,
            RetrieveSubaccountsSummaryFail);

    public static async Task<CreateIpPoolResponseWrapper> Wrap(Task<Either<ErrorResponse, CreateIpPoolResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            CreateIpPoolSuccess,
            CreateIpPoolFail);

    public static async Task<RetrieveIpPoolResponseWrapper> Wrap(Task<Either<ErrorResponse, RetrieveIpPoolResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            RetrieveIpPoolSuccess,
            RetrieveIpPoolFail);

    public static async Task<UpdateIpPoolResponseWrapper> Wrap(Task<Either<ErrorResponse, UpdateIpPoolResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            UpdateIpPoolSuccess,
            UpdateIpPoolFail);

    public static async Task<ListIpPoolsResponseWrapper> Wrap(Task<Either<ErrorResponse, ListIpPoolsResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            ListIpPoolsSuccess,
            ListIpPoolsFail);

    public static async Task<RetrieveSendingIpResponseWrapper> Wrap(Task<Either<ErrorResponse, RetrieveSendingIpResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            RetrieveSendingIpSuccess,
            RetrieveSendingIpFail);

    public static async Task<UpdateSendingIpResponseWrapper> Wrap(Task<Either<ErrorResponse, UpdateSendingIpResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            UpdateSendingIpSuccess,
            UpdateSendingIpFail);

    public static async Task<ListSendingIpsResponseWrapper> Wrap(Task<Either<ErrorResponse, ListSendingIpsResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            ListSendingIpsSuccess,
            ListSendingIpsFail);

    public static async Task<BulkCreateOrUpdateSuppressionsResponseWrapper> Wrap(Task<Either<ErrorResponse, BulkCreateOrUpdateSuppressionsResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            BulkCreateOrUpdateSuppressionsSuccess,
            BulkCreateOrUpdateSuppressionsFail);

    public static async Task<CreateOrUpdateSuppressionResponseWrapper> Wrap(Task<Either<ErrorResponse, CreateOrUpdateSuppressionResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            CreateOrUpdateSuppressionSuccess,
            CreateOrUpdateSuppressionFail);

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

    public static async Task<RetrieveSuppressionSummaryResponseWrapper> Wrap(Task<Either<ErrorResponse, RetrieveSuppressionSummaryResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            RetrieveSuppressionSummarySuccess,
            RetrieveSuppressionSummaryFail);

    public static async Task<EmailAddressValidationResponseWrapper> Wrap(Task<Either<ErrorResponse, EmailAddressValidationResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            EmailAddressValidationSuccess,
            EmailAddressValidationFail);

    public static async Task<CreateTemplateResponseWrapper> Wrap(Task<Either<TemplateErrorResponse, CreateTemplateResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            CreateTemplateSuccess,
            CreateTemplateFail);

    public static async Task<CreateSnippetResponseWrapper> Wrap(Task<Either<ErrorResponse, CreateSnippetResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            CreateSnippetSuccess,
            CreateSnippetFail);

    public static async Task<RetrieveSnippetResponseWrapper> Wrap(Task<Either<ErrorResponse, RetrieveSnippetResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            RetrieveSnippetSuccess,
            RetrieveSnippetFail);

    public static async Task<ListSnippetsResponseWrapper> Wrap(Task<Either<ErrorResponse, ListSnippetsResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            ListSnippetsSuccess,
            ListSnippetsFail);

    public static async Task<CreateRecipientListResponseWrapper> Wrap(Task<Either<ErrorResponse, CreateRecipientListResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            CreateRecipientListSuccess,
            CreateRecipientListFail);

    public static async Task<RetrieveRecipientListResponseWrapper> Wrap(Task<Either<ErrorResponse, RetrieveRecipientListResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            RetrieveRecipientListSuccess,
            RetrieveRecipientListFail);

    public static async Task<UpdateRecipientListResponseWrapper> Wrap(Task<Either<ErrorResponse, UpdateRecipientListResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            UpdateRecipientListSuccess,
            UpdateRecipientListFail);

    public static async Task<ListRecipientListsResponseWrapper> Wrap(Task<Either<ErrorResponse, ListRecipientListsResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            ListRecipientListsSuccess,
            ListRecipientListsFail);

    public static async Task<ListSendingDomainsResponseWrapper> Wrap(Task<Either<ErrorResponse, ListSendingDomainsResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            ListSendingDomainsSuccess,
            ListSendingDomainsFail);

    public static async Task<RetrieveSendingDomainResponseWrapper> Wrap(Task<Either<ErrorResponse, RetrieveSendingDomainResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            RetrieveSendingDomainSuccess,
            RetrieveSendingDomainFail);

    public static async Task<UpdateSendingDomainResponseWrapper> Wrap(Task<Either<ErrorResponse, UpdateSendingDomainResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            UpdateSendingDomainSuccess,
            UpdateSendingDomainFail);

    public static async Task<VerifySendingDomainResponseWrapper> Wrap(Task<Either<ErrorResponse, VerifySendingDomainResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            VerifySendingDomainSuccess,
            VerifySendingDomainFail);

    public static async Task<CreateTrackingDomainResponseWrapper> Wrap(Task<Either<ErrorResponse, CreateTrackingDomainResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            CreateTrackingDomainSuccess,
            CreateTrackingDomainFail);

    public static async Task<ListTrackingDomainsResponseWrapper> Wrap(Task<Either<ErrorResponse, ListTrackingDomainsResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            ListTrackingDomainsSuccess,
            ListTrackingDomainsFail);

    public static async Task<ListTemplatesResponseWrapper> Wrap(Task<Either<ErrorResponse, ListTemplatesResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            ListTemplatesSuccess,
            ListTemplatesFail);

    public static async Task<RetrieveTrackingDomainResponseWrapper> Wrap(Task<Either<ErrorResponse, RetrieveTrackingDomainResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            RetrieveTrackingDomainSuccess,
            RetrieveTrackingDomainFail);

    public static async Task<UpdateTrackingDomainResponseWrapper> Wrap(Task<Either<ErrorResponse, UpdateTrackingDomainResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            UpdateTrackingDomainSuccess,
            UpdateTrackingDomainFail);

    public static async Task<PreviewTemplateResponseWrapper> Wrap(Task<Either<ErrorResponse, PreviewTemplateResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            PreviewTemplateSuccess,
            PreviewTemplateFail);

    public static async Task<PreviewInlineTemplateResponseWrapper> Wrap(Task<Either<ErrorResponse, PreviewInlineTemplateResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            PreviewInlineTemplateSuccess,
            PreviewInlineTemplateFail);

    public static async Task<VerifyTrackingDomainResponseWrapper> Wrap(Task<Either<ErrorResponse, VerifyTrackingDomainResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            VerifyTrackingDomainSuccess,
            VerifyTrackingDomainFail);

    public static async Task<CreateTransmissionResponseWrapper> Wrap(Task<Either<ErrorResponse, CreateTransmissionResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            CreateTransmissionSuccess,
            CreateTransmissionFail);

    public static async Task<RetrieveAccountResponseWrapper> Wrap(Task<Either<ErrorResponse, RetrieveAccountResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            RetrieveAccountSuccess,
            RetrieveAccountFail);

    public static async Task<UpdateAccountResponseWrapper> Wrap(Task<Either<ErrorResponse, UpdateAccountResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            UpdateAccountSuccess,
            UpdateAccountFail);

    public static async Task<UnitResponseWrapper> Wrap(Task<Either<ErrorResponse, Unit>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            UnitSuccess,
            UnitFail);

    public static async Task<CreateAbTestResponseWrapper> Wrap(Task<Either<ErrorResponse, CreateAbTestResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            CreateAbTestSuccess,
            CreateAbTestFail);

    public static async Task<RetrieveAbTestResponseWrapper> Wrap(Task<Either<ErrorResponse, RetrieveAbTestResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            RetrieveAbTestSuccess,
            RetrieveAbTestFail);

    public static async Task<UpdateAbTestResponseWrapper> Wrap(Task<Either<ErrorResponse, UpdateAbTestResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            UpdateAbTestSuccess,
            UpdateAbTestFail);

    public static async Task<ListAbTestsResponseWrapper> Wrap(Task<Either<ErrorResponse, ListAbTestsResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            ListAbTestsSuccess,
            ListAbTestsFail);

    public static async Task<CreateAbTestDraftResponseWrapper> Wrap(Task<Either<ErrorResponse, CreateAbTestDraftResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            CreateAbTestDraftSuccess,
            CreateAbTestDraftFail);

    public static async Task<RetrieveAbTestDraftResponseWrapper> Wrap(Task<Either<ErrorResponse, RetrieveAbTestDraftResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            RetrieveAbTestDraftSuccess,
            RetrieveAbTestDraftFail);

    public static async Task<UpdateAbTestDraftResponseWrapper> Wrap(Task<Either<ErrorResponse, UpdateAbTestDraftResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            UpdateAbTestDraftSuccess,
            UpdateAbTestDraftFail);

    public static async Task<ScheduleAbTestDraftResponseWrapper> Wrap(Task<Either<ErrorResponse, ScheduleAbTestDraftResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            ScheduleAbTestDraftSuccess,
            ScheduleAbTestDraftFail);

    public static async Task<RetrieveTemplateResponseWrapper> Wrap(Task<Either<ErrorResponse, RetrieveTemplateResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            RetrieveTemplateSuccess,
            RetrieveTemplateFail);

    private static DataPrivacyResponseWrapper AddDataPrivacyFail(DataPrivacyErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static DataPrivacyResponseWrapper AddDataPrivacySuccess(AddDataPrivacyResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static BulkCreateOrUpdateSuppressionsResponseWrapper BulkCreateOrUpdateSuppressionsFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static BulkCreateOrUpdateSuppressionsResponseWrapper BulkCreateOrUpdateSuppressionsSuccess(BulkCreateOrUpdateSuppressionsResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static CreateAbTestDraftResponseWrapper CreateAbTestDraftFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static CreateAbTestDraftResponseWrapper CreateAbTestDraftSuccess(CreateAbTestDraftResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static CreateAbTestResponseWrapper CreateAbTestFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static CreateAbTestResponseWrapper CreateAbTestSuccess(CreateAbTestResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static CreateIpPoolResponseWrapper CreateIpPoolFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static CreateIpPoolResponseWrapper
        CreateIpPoolSuccess(CreateIpPoolResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static CreateOrUpdateSuppressionResponseWrapper CreateOrUpdateSuppressionFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static CreateOrUpdateSuppressionResponseWrapper CreateOrUpdateSuppressionSuccess(CreateOrUpdateSuppressionResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static CreateRecipientListResponseWrapper CreateRecipientListFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static CreateRecipientListResponseWrapper CreateRecipientListSuccess(CreateRecipientListResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static CreateSendingDomainResponseWrapper CreateSendingDomainFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static CreateSendingDomainResponseWrapper CreateSendingDomainSuccess(CreateSendingDomainResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static CreateSnippetResponseWrapper CreateSnippetFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static CreateSnippetResponseWrapper CreateSnippetSuccess(CreateSnippetResponse response) => new()
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

    private static CreateTemplateResponseWrapper CreateTemplateFail(TemplateErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static CreateTemplateResponseWrapper CreateTemplateSuccess(CreateTemplateResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static CreateTrackingDomainResponseWrapper CreateTrackingDomainFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static CreateTrackingDomainResponseWrapper CreateTrackingDomainSuccess(CreateTrackingDomainResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static CreateTransmissionResponseWrapper CreateTransmissionFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static CreateTransmissionResponseWrapper CreateTransmissionSuccess(CreateTransmissionResponse response) =>
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

    private static EmailAddressValidationResponseWrapper EmailAddressValidationFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static EmailAddressValidationResponseWrapper EmailAddressValidationSuccess(EmailAddressValidationResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ListAbTestsResponseWrapper ListAbTestsFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static ListAbTestsResponseWrapper ListAbTestsSuccess(ListAbTestsResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ListIpPoolsResponseWrapper ListIpPoolsFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static ListIpPoolsResponseWrapper ListIpPoolsSuccess(ListIpPoolsResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ListRecipientListsResponseWrapper ListRecipientListsFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static ListRecipientListsResponseWrapper ListRecipientListsSuccess(ListRecipientListsResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ListSendingDomainsResponseWrapper ListSendingDomainsFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static ListSendingDomainsResponseWrapper ListSendingDomainsSuccess(ListSendingDomainsResponse response) =>
        new()
        {
            Results = response.Results,
            StatusCode = HttpStatusCode.OK
        };

    private static ListSendingIpsResponseWrapper ListSendingIpsFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static ListSendingIpsResponseWrapper ListSendingIpsSuccess(ListSendingIpsResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ListSnippetsResponseWrapper ListSnippetsFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static ListSnippetsResponseWrapper ListSnippetsSuccess(ListSnippetsResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ListSubaccountsResponseWrapper ListSubaccountsFail(SubaccountErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static ListSubaccountsResponseWrapper ListSubaccountsSuccess(ListSubaccountsResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ListTemplatesResponseWrapper ListTemplatesFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static ListTemplatesResponseWrapper ListTemplatesSuccess(ListTemplatesResponse response) =>
        new()
        {
            Results = response.Results,
            StatusCode = HttpStatusCode.OK
        };

    private static ListTrackingDomainsResponseWrapper ListTrackingDomainsFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static ListTrackingDomainsResponseWrapper ListTrackingDomainsSuccess(ListTrackingDomainsResponse response) =>
        new()
        {
            Results = response.Results,
            StatusCode = HttpStatusCode.OK
        };

    private static PreviewInlineTemplateResponseWrapper PreviewInlineTemplateFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static PreviewInlineTemplateResponseWrapper PreviewInlineTemplateSuccess(PreviewInlineTemplateResponse response) => new()
    {
//        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static PreviewTemplateResponseWrapper PreviewTemplateFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static PreviewTemplateResponseWrapper PreviewTemplateSuccess(PreviewTemplateResponse response) => new()
    {
//        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static RetrieveAbTestDraftResponseWrapper RetrieveAbTestDraftFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static RetrieveAbTestDraftResponseWrapper RetrieveAbTestDraftSuccess(RetrieveAbTestDraftResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static RetrieveAbTestResponseWrapper RetrieveAbTestFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static RetrieveAbTestResponseWrapper RetrieveAbTestSuccess(RetrieveAbTestResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static RetrieveAccountResponseWrapper RetrieveAccountFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static RetrieveAccountResponseWrapper RetrieveAccountSuccess(RetrieveAccountResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static RetrieveIpPoolResponseWrapper RetrieveIpPoolFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static RetrieveIpPoolResponseWrapper RetrieveIpPoolSuccess(RetrieveIpPoolResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static RetrieveRecipientListResponseWrapper RetrieveRecipientListFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static RetrieveRecipientListResponseWrapper RetrieveRecipientListSuccess(RetrieveRecipientListResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static RetrieveSendingDomainResponseWrapper RetrieveSendingDomainFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static RetrieveSendingDomainResponseWrapper RetrieveSendingDomainSuccess(RetrieveSendingDomainResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static RetrieveSendingIpResponseWrapper RetrieveSendingIpFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static RetrieveSendingIpResponseWrapper RetrieveSendingIpSuccess(RetrieveSendingIpResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static RetrieveSnippetResponseWrapper RetrieveSnippetFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static RetrieveSnippetResponseWrapper RetrieveSnippetSuccess(RetrieveSnippetResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static RetrieveSubaccountResponseWrapper RetrieveSubaccountFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static RetrieveSubaccountsSummaryResponseWrapper RetrieveSubaccountsSummaryFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static RetrieveSubaccountsSummaryResponseWrapper RetrieveSubaccountsSummarySuccess(RetrieveSubaccountsSummaryResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static RetrieveSubaccountResponseWrapper RetrieveSubaccountSuccess(RetrieveSubaccountResponse response) => new()
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

    private static RetrieveSuppressionSummaryResponseWrapper RetrieveSuppressionSummaryFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static RetrieveSuppressionSummaryResponseWrapper RetrieveSuppressionSummarySuccess(RetrieveSuppressionSummaryResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static RetrieveTemplateResponseWrapper RetrieveTemplateFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static RetrieveTemplateResponseWrapper RetrieveTemplateSuccess(RetrieveTemplateResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static RetrieveTrackingDomainResponseWrapper RetrieveTrackingDomainFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static RetrieveTrackingDomainResponseWrapper RetrieveTrackingDomainSuccess(
        RetrieveTrackingDomainResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ScheduleAbTestDraftResponseWrapper ScheduleAbTestDraftFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static ScheduleAbTestDraftResponseWrapper ScheduleAbTestDraftSuccess(ScheduleAbTestDraftResponse response) => new()
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

    private static UpdateAbTestDraftResponseWrapper UpdateAbTestDraftFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static UpdateAbTestDraftResponseWrapper UpdateAbTestDraftSuccess(UpdateAbTestDraftResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static UpdateAbTestResponseWrapper UpdateAbTestFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static UpdateAbTestResponseWrapper UpdateAbTestSuccess(UpdateAbTestResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static UpdateAccountResponseWrapper UpdateAccountFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static UpdateAccountResponseWrapper UpdateAccountSuccess(UpdateAccountResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static UpdateIpPoolResponseWrapper UpdateIpPoolFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static UpdateIpPoolResponseWrapper UpdateIpPoolSuccess(UpdateIpPoolResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static UpdateRecipientListResponseWrapper UpdateRecipientListFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static UpdateRecipientListResponseWrapper UpdateRecipientListSuccess(UpdateRecipientListResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static UpdateSendingDomainResponseWrapper UpdateSendingDomainFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static UpdateSendingDomainResponseWrapper UpdateSendingDomainSuccess(UpdateSendingDomainResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static UpdateSendingIpResponseWrapper UpdateSendingIpFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static UpdateSendingIpResponseWrapper UpdateSendingIpSuccess(UpdateSendingIpResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static UpdateSubaccountResponseWrapper UpdateSubaccountFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static UpdateSubaccountResponseWrapper UpdateSubaccountSuccess(UpdateSubaccountResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static UpdateTrackingDomainResponseWrapper UpdateTrackingDomainFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static UpdateTrackingDomainResponseWrapper UpdateTrackingDomainSuccess(UpdateTrackingDomainResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static VerifySendingDomainResponseWrapper VerifySendingDomainFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static VerifySendingDomainResponseWrapper VerifySendingDomainSuccess(VerifySendingDomainResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static VerifyTrackingDomainResponseWrapper VerifyTrackingDomainFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static VerifyTrackingDomainResponseWrapper VerifyTrackingDomainSuccess(VerifyTrackingDomainResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };
}