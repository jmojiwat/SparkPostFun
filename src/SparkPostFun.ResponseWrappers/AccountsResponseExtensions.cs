using System.Net;
using LanguageExt;
using SparkPostFun.Accounts;
using static SparkPostFun.ResponseWrappers.ResponseExtensions;

namespace SparkPostFun.ResponseWrappers;

public static class AccountsResponseExtensions
{
    public static async Task<ResponseWrapper<RetrieveAccountResponseResult>> Wrap(Task<Either<ErrorResponse, RetrieveAccountResponse>> response) =>
        (await response.ConfigureAwait(false)).Match(
            Success,
            Fail<RetrieveAccountResponseResult>);

    public static async Task<ResponseWrapper<UpdateSubaccountResponseResult>> Wrap(Task<Either<ErrorResponse, UpdateSubaccountResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<UpdateSubaccountResponseResult>);

    public static async Task<ResponseWrapper<UpdateAccountResponseResult>> Wrap(Task<Either<ErrorResponse, UpdateAccountResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<UpdateAccountResponseResult>);

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


    public static async Task<ListSubaccountsResponseWrapper> Wrap(Task<Either<SubaccountErrorResponse, ListSubaccountsResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            ListSubaccountsSuccess,
            ListSubaccountsFail);

    public static async Task<ResponseWrapper<RetrieveSubaccountsSummaryResponseResult>> Wrap(
        Task<Either<ErrorResponse, RetrieveSubaccountsSummaryResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            Success,
            Fail<RetrieveSubaccountsSummaryResponseResult>);
    public static async Task<AddDataPrivacyResponseWrapper> Wrap(Task<Either<DataPrivacyErrorResponse, AddDataPrivacyResponse>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            AddDataPrivacySuccess,
            AddDataPrivacyFail);

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

    private static ResponseWrapper<RetrieveAccountResponseResult> Success(RetrieveAccountResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<UpdateSubaccountResponseResult> Success(UpdateSubaccountResponse response) => new()
    {
        Results = response.Results,
        StatusCode = HttpStatusCode.OK
    };

    private static ResponseWrapper<UpdateAccountResponseResult> Success(UpdateAccountResponse response) => new()
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
}