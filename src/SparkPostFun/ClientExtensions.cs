using System.Diagnostics;
using System.Net.Http.Json;
using LanguageExt;
using static LanguageExt.Prelude;

namespace SparkPostFun
{
    public static class ClientExtensions
    {
        public static Client Client(string apiKey, string host) => new(apiKey, host);

        internal static Uri BuildBaseUri(string host)
        {
            var builder = new UriBuilder("https", host);
            return builder.Uri;
        }

        internal static Task<Either<ErrorResponse, TResponse>> ToResponse<TResponse>(HttpResponseMessage message) =>
            message.IsSuccessStatusCode
                ? ToValidResponse<TResponse>(message)
                : ToError<TResponse>(message);

        private static async Task<Either<ErrorResponse, TResponse>> ToError<TResponse>(HttpResponseMessage message)
        {
            var errorResponse = await message.Content.ReadFromJsonAsync<ErrorResponse>().ConfigureAwait(false);
            var error = Optional(errorResponse)
                .Map(e => e with { StatusCode = message.StatusCode })
                .Match(
                    Left,
                    () => Left(new ErrorResponse()));
            
            Trace.TraceError($"SparkPostSharp: {errorResponse}");
            
            return error;
        }

        private static async Task<Either<ErrorResponse, TResponse>> ToValidResponse<TResponse>(
            HttpResponseMessage message)
        {
            return (await message.Content.ReadFromJsonAsync<TResponse>().ConfigureAwait(false))
                .Apply(Right);
        }

        internal static Task<Either<TError, TResponse>> ToResponse<TError, TResponse>(HttpResponseMessage message) where TError : BaseErrorResponse =>
            message.IsSuccessStatusCode
                ? ToValidResponse<TError, TResponse>(message)
                : ToError<TError, TResponse>(message);

        private static async Task<Either<TError, TResponse>> ToError<TError, TResponse>(HttpResponseMessage message) where TError : BaseErrorResponse
        {
            /*
            var error = await message.Content.ReadFromJsonAsync<TError>().ConfigureAwait(false);
            error = error with { StatusCode = message.StatusCode };
            Trace.TraceError($"SparkPostSharp: {error}");
            return Left(error);
            */
            
            
            var errorResponse = await message.Content.ReadFromJsonAsync<TError>().ConfigureAwait(false);
            var error = Optional(errorResponse)
                .Map(e => e with { StatusCode = message.StatusCode })
                .Match(
                    Left,
                    () => Left(default(TError)));
            
            Trace.TraceError($"SparkPostSharp: {errorResponse}");
            
            return error;
            
        }

        private static async Task<Either<TError, TResponse>> ToValidResponse<TError, TResponse>(HttpResponseMessage message)
        {
            return (await message.Content.ReadFromJsonAsync<TResponse>().ConfigureAwait(false))
                .Apply(Right);
        }
    }
}