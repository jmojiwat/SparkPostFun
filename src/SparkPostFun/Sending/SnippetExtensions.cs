using System.Threading.Tasks;
using LanguageExt;
using static SparkPostFun.ClientExtensions;
using static LanguageExt.Prelude;

namespace SparkPostFun.Sending;

public static class SnippetExtensions
{
    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, CreateSnippetResponse>>> CreateSnippet(CreateSnippet request)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = "/api/labs/snippets"
            select env.Client.Post(requestUrl, request)
                .MapAsync(ToResponse<CreateSnippetResponse>);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, Unit>>> DeleteSnippet(string id)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/labs/snippets/{id}"
            select env.Client.Delete(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, ListSnippetsResponse>>> ListSnippets()
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = "/api/labs/snippets"
            select env.Client.Get<ListSnippetsResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, RetrieveSnippetResponse>>> RetrieveSnippet(string id)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/labs/snippets/{id}"
            select env.Client.Get<RetrieveSnippetResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, Unit>>> UpdateSnippet(string id, UpdateSnippet request)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/labs/snippets/{id}"
            select env.Client.Put(requestUrl, request)
                .MapAsync(ToResponse<Unit>);
    }
}