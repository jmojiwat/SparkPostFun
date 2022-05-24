using System.Net;
using LanguageExt;

namespace SparkPostFun.ResponseWrappers;

public static class ResponseExtensions
{
    public static ResponseWrapper<TResult> Fail<TResult>(ErrorResponse response) where TResult : class => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    public static ResponseListResultWrapper<TResult> ListResultFail<TResult>(ErrorResponse response) where TResult : class => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };


    public static async Task<UnitResponseWrapper> Wrap(Task<Either<ErrorResponse, Unit>> response) =>
        (await response.ConfigureAwait(false))
        .Match(
            UnitSuccess,
            UnitFail);


    private static UnitResponseWrapper UnitFail(ErrorResponse response) => new()
    {
        StatusCode = response.StatusCode,
        Errors = response.Errors
    };

    private static UnitResponseWrapper UnitSuccess(Unit unit) => new()
    {
        StatusCode = HttpStatusCode.OK
    };
}