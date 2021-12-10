using System.Net;
using LanguageExt;
using SparkPostFun.Accounts;
using SparkPostFun.Sending;

namespace SparkPostFun.ResponseWrappers;

public static class ResponseExtensions
{
    public static async Task<CreateSendingDomainResponseWrapper> Wrap(
        Task<Either<ErrorResponse, CreateSendingDomainResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                CreateSendingDomainSuccess,
                CreateSendingDomainFail);
    }

    public static async Task<CreateIpPoolResponseWrapper> Wrap(
        Task<Either<ErrorResponse, CreateIpPoolResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                CreateIpPoolSuccess,
                CreateIpPoolFail);
    }

    public static async Task<RetrieveIpPoolResponseWrapper> Wrap(
        Task<Either<ErrorResponse, RetrieveIpPoolResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                RetrieveIpPoolSuccess,
                RetrieveIpPoolFail);
    }

    public static async Task<UpdateIpPoolResponseWrapper> Wrap(
        Task<Either<ErrorResponse, UpdateIpPoolResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                UpdateIpPoolSuccess,
                UpdateIpPoolFail);
    }

    public static async Task<ListIpPoolsResponseWrapper> Wrap(
        Task<Either<ErrorResponse, ListIpPoolsResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                ListIpPoolsSuccess,
                ListIpPoolsFail);
    }

    public static async Task<RetrieveSendingIpResponseWrapper> Wrap(
        Task<Either<ErrorResponse, RetrieveSendingIpResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                RetrieveSendingIpSuccess,
                RetrieveSendingIpFail);
    }

    public static async Task<UpdateSendingIpResponseWrapper> Wrap(
        Task<Either<ErrorResponse, UpdateSendingIpResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                UpdateSendingIpSuccess,
                UpdateSendingIpFail);
    }

    public static async Task<ListSendingIpsResponseWrapper> Wrap(
        Task<Either<ErrorResponse, ListSendingIpsResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                ListSendingIpsSuccess,
                ListSendingIpsFail);
    }

    public static async Task<BulkCreateOrUpdateSuppressionsResponseWrapper> Wrap(
        Task<Either<ErrorResponse, BulkCreateOrUpdateSuppressionsResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                BulkCreateOrUpdateSuppressionsSuccess,
                BulkCreateOrUpdateSuppressionsFail);
    }

    public static async Task<CreateOrUpdateSuppressionResponseWrapper> Wrap(
        Task<Either<ErrorResponse, CreateOrUpdateSuppressionResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                CreateOrUpdateSuppressionSuccess,
                CreateOrUpdateSuppressionFail);
    }

    public static async Task<RetrieveSuppressionResponseWrapper> Wrap(
        Task<Either<ErrorResponse, RetrieveSuppressionResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                RetrieveSuppressionSuccess,
                RetrieveSuppressionFail);
    }

    public static async Task<SearchSuppressionsResponseWrapper> Wrap(
        Task<Either<ErrorResponse, SearchSuppressionsResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                SearchSuppressionsSuccess,
                SearchSuppressionsFail);
    }

    public static async Task<RetrieveSuppressionSummaryResponseWrapper> Wrap(
        Task<Either<ErrorResponse, RetrieveSuppressionSummaryResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                RetrieveSuppressionSummarySuccess,
                RetrieveSuppressionSummaryFail);
    }

    public static async Task<EmailAddressValidationResponseWrapper> Wrap(
        Task<Either<ErrorResponse, EmailAddressValidationResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                EmailAddressValidationSuccess,
                EmailAddressValidationFail);
    }

    public static async Task<CreateTemplateResponseWrapper> Wrap(
        Task<Either<ErrorResponse, CreateTemplateResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                CreateTemplateSuccess,
                CreateTemplateFail);
    }

    public static async Task<CreateSnippetResponseWrapper> Wrap(
        Task<Either<ErrorResponse, CreateSnippetResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                CreateSnippetSuccess,
                CreateSnippetFail);
    }

    public static async Task<RetrieveSnippetResponseWrapper> Wrap(
        Task<Either<ErrorResponse, RetrieveSnippetResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                RetrieveSnippetSuccess,
                RetrieveSnippetFail);
    }

    public static async Task<ListSnippetsResponseWrapper> Wrap(
        Task<Either<ErrorResponse, ListSnippetsResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                ListSnippetsSuccess,
                ListSnippetsFail);
    }

    public static async Task<CreateRecipientListResponseWrapper> Wrap(
        Task<Either<ErrorResponse, CreateRecipientListResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                CreateRecipientListSuccess,
                CreateRecipientListFail);
    }

    public static async Task<RetrieveRecipientListResponseWrapper> Wrap(
        Task<Either<ErrorResponse, RetrieveRecipientListResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                RetrieveRecipientListSuccess,
                RetrieveRecipientListFail);
    }

    public static async Task<UpdateRecipientListResponseWrapper> Wrap(
        Task<Either<ErrorResponse, UpdateRecipientListResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                UpdateRecipientListSuccess,
                UpdateRecipientListFail);
    }

    public static async Task<ListRecipientListsResponseWrapper> Wrap(
        Task<Either<ErrorResponse, ListRecipientListsResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                ListRecipientListsSuccess,
                ListRecipientListsFail);
    }

    public static async Task<ListSendingDomainsResponseWrapper> Wrap(
        Task<Either<ErrorResponse, ListSendingDomainsResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                ListSendingDomainsSuccess,
                ListSendingDomainsFail);
    }

    public static async Task<RetrieveSendingDomainResponseWrapper> Wrap(
        Task<Either<ErrorResponse, RetrieveSendingDomainResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                RetrieveSendingDomainSuccess,
                RetrieveSendingDomainFail);
    }

    public static async Task<UpdateSendingDomainResponseWrapper> Wrap(
        Task<Either<ErrorResponse, UpdateSendingDomainResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                UpdateSendingDomainSuccess,
                UpdateSendingDomainFail);
    }

    public static async Task<VerifySendingDomainResponseWrapper> Wrap(
        Task<Either<ErrorResponse, VerifySendingDomainResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                VerifySendingDomainSuccess,
                VerifySendingDomainFail);
    }

    public static async Task<CreateTrackingDomainResponseWrapper> Wrap(
        Task<Either<ErrorResponse, CreateTrackingDomainResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                CreateTrackingDomainSuccess,
                CreateTrackingDomainFail);
    }

    public static async Task<ListTrackingDomainsResponseWrapper> Wrap(
        Task<Either<ErrorResponse, ListTrackingDomainsResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                ListTrackingDomainsSuccess,
                ListTrackingDomainsFail);
    }

    public static async Task<ListTemplatesResponseWrapper> Wrap(
        Task<Either<ErrorResponse, ListTemplatesResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                ListTemplatesSuccess,
                ListTemplatesFail);
    }

    public static async Task<RetrieveTrackingDomainResponseWrapper> Wrap(
        Task<Either<ErrorResponse, RetrieveTrackingDomainResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                RetrieveTrackingDomainSuccess,
                RetrieveTrackingDomainFail);
    }

    public static async Task<UpdateTrackingDomainResponseWrapper> Wrap(
        Task<Either<ErrorResponse, UpdateTrackingDomainResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                UpdateTrackingDomainSuccess,
                UpdateTrackingDomainFail);
    }

    public static async Task<PreviewTemplateResponseWrapper> Wrap(
        Task<Either<ErrorResponse, PreviewTemplateResponse>> response)
    {
        throw new NotImplementedException();
        return (await response.ConfigureAwait(false))
            .Match(
                PreviewTemplateSuccess,
                PreviewTemplateFail);
    }

    public static async Task<PreviewInlineTemplateResponseWrapper> Wrap(
        Task<Either<ErrorResponse, PreviewInlineTemplateResponse>> response)
    {
        throw new NotImplementedException();
        return (await response.ConfigureAwait(false))
            .Match(
                PreviewInlineTemplateSuccess,
                PreviewInlineTemplateFail);
    }

    public static async Task<VerifyTrackingDomainResponseWrapper> Wrap(
        Task<Either<ErrorResponse, VerifyTrackingDomainResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                VerifyTrackingDomainSuccess,
                VerifyTrackingDomainFail);
    }

    public static async Task<CreateTransmissionResponseWrapper> Wrap(
        Task<Either<ErrorResponse, CreateTransmissionResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                CreateTransmissionSuccess,
                CreateTransmissionFail);
    }

    public static async Task<RetrieveAccountResponseWrapper> Wrap(
        Task<Either<ErrorResponse, RetrieveAccountResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                RetrieveAccountSuccess,
                RetrieveAccountFail);
    }

    public static async Task<UnitResponseWrapper> Wrap(Task<Either<ErrorResponse, Unit>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                UnitSuccess,
                UnitFail);
    }

    public static async Task<CreateAbTestResponseWrapper> Wrap(
        Task<Either<ErrorResponse, CreateAbTestResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                CreateAbTestSuccess,
                CreateAbTestFail);
    }

    public static async Task<RetrieveAbTestResponseWrapper> Wrap(
        Task<Either<ErrorResponse, RetrieveAbTestResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                RetrieveAbTestSuccess,
                RetrieveAbTestFail);
    }

    public static async Task<UpdateAbTestResponseWrapper> Wrap(
        Task<Either<ErrorResponse, UpdateAbTestResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                UpdateAbTestSuccess,
                UpdateAbTestFail);
    }

    public static async Task<ListAbTestsResponseWrapper> Wrap(
        Task<Either<ErrorResponse, ListAbTestsResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                ListAbTestsSuccess,
                ListAbTestsFail);
    }

    public static async Task<CreateAbTestDraftResponseWrapper> Wrap(
        Task<Either<ErrorResponse, CreateAbTestDraftResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                CreateAbTestDraftSuccess,
                CreateAbTestDraftFail);
    }

    public static async Task<RetrieveAbTestDraftResponseWrapper> Wrap(
        Task<Either<ErrorResponse, RetrieveAbTestDraftResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                RetrieveAbTestDraftSuccess,
                RetrieveAbTestDraftFail);
    }

    public static async Task<UpdateAbTestDraftResponseWrapper> Wrap(
        Task<Either<ErrorResponse, UpdateAbTestDraftResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                UpdateAbTestDraftSuccess,
                UpdateAbTestDraftFail);
    }

    public static async Task<ScheduleAbTestDraftResponseWrapper> Wrap(
        Task<Either<ErrorResponse, ScheduleAbTestDraftResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                ScheduleAbTestDraftSuccess,
                ScheduleAbTestDraftFail);
    }

    public static async Task<RetrieveTemplateResponseWrapper> Wrap(
        Task<Either<ErrorResponse, RetrieveTemplateResponse>> response)
    {
        return (await response.ConfigureAwait(false))
            .Match(
                RetrieveTemplateSuccess,
                RetrieveTemplateFail);
    }

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

    private static CreateRecipientListResponseWrapper
        CreateRecipientListSuccess(CreateRecipientListResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static CreateSendingDomainResponseWrapper CreateSendingDomainFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static CreateSendingDomainResponseWrapper
        CreateSendingDomainSuccess(CreateSendingDomainResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static CreateSnippetResponseWrapper CreateSnippetFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static CreateSnippetResponseWrapper
        CreateSnippetSuccess(CreateSnippetResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static CreateTemplateResponseWrapper CreateTemplateFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static CreateTemplateResponseWrapper
        CreateTemplateSuccess(CreateTemplateResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static CreateTrackingDomainResponseWrapper CreateTrackingDomainFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static CreateTrackingDomainResponseWrapper
        CreateTrackingDomainSuccess(CreateTrackingDomainResponse response) => new()
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

    private static ListIpPoolsResponseWrapper
        ListIpPoolsSuccess(ListIpPoolsResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ListRecipientListsResponseWrapper ListRecipientListsFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static ListRecipientListsResponseWrapper
        ListRecipientListsSuccess(ListRecipientListsResponse response) => new()
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

    private static ListSnippetsResponseWrapper
        ListSnippetsSuccess(ListSnippetsResponse response) => new()
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

    private static ListTrackingDomainsResponseWrapper
        ListTrackingDomainsSuccess(ListTrackingDomainsResponse response) =>
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

    private static RetrieveIpPoolResponseWrapper
        RetrieveIpPoolSuccess(RetrieveIpPoolResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static RetrieveRecipientListResponseWrapper RetrieveRecipientListFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static RetrieveRecipientListResponseWrapper
        RetrieveRecipientListSuccess(RetrieveRecipientListResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static RetrieveSendingDomainResponseWrapper RetrieveSendingDomainFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static RetrieveSendingDomainResponseWrapper RetrieveSendingDomainSuccess(
        RetrieveSendingDomainResponse response) => new()
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

    private static RetrieveSnippetResponseWrapper
        RetrieveSnippetSuccess(RetrieveSnippetResponse response) => new()
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

    private static UpdateIpPoolResponseWrapper UpdateIpPoolFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static UpdateIpPoolResponseWrapper
        UpdateIpPoolSuccess(UpdateIpPoolResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static UpdateRecipientListResponseWrapper UpdateRecipientListFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static UpdateRecipientListResponseWrapper
        UpdateRecipientListSuccess(UpdateRecipientListResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static UpdateSendingDomainResponseWrapper UpdateSendingDomainFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static UpdateSendingDomainResponseWrapper
        UpdateSendingDomainSuccess(UpdateSendingDomainResponse response) => new()
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

    private static UpdateTrackingDomainResponseWrapper UpdateTrackingDomainFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static UpdateTrackingDomainResponseWrapper
        UpdateTrackingDomainSuccess(UpdateTrackingDomainResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static VerifySendingDomainResponseWrapper VerifySendingDomainFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static VerifySendingDomainResponseWrapper
        VerifySendingDomainSuccess(VerifySendingDomainResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static VerifyTrackingDomainResponseWrapper VerifyTrackingDomainFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static VerifyTrackingDomainResponseWrapper
        VerifyTrackingDomainSuccess(VerifyTrackingDomainResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };
}