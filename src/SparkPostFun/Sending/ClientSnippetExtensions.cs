using LanguageExt;
using static SparkPostFun.ClientExtensions;

namespace SparkPostFun.Sending;

public static class ClientSnippetExtensions
{
    public static Task<Either<ErrorResponse, CreateSnippetResponse>> CreateSnippet(this Client @this, CreateSnippet request)
    {
        const string requestUrl = "/api/labs/snippets";
        return @this.Post(requestUrl, request)
            .MapAsync(ToResponse<CreateSnippetResponse>);
    }

    public static Task<Either<ErrorResponse, Unit>> DeleteSnippet(this Client @this, string id)
    {
        var requestUrl = $"/api/labs/snippets/{id}";
        return @this.Delete(requestUrl);
    }

    public static Task<Either<ErrorResponse, ListSnippetsResponse>> ListSnippets(this Client @this)
    {
        const string requestUrl = "/api/labs/snippets";
        return @this.Get<ListSnippetsResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, RetrieveSnippetResponse>> RetrieveSnippet(this Client @this, string id)
    {
        var requestUrl = $"/api/labs/snippets/{id}";
        return @this.Get<RetrieveSnippetResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, Unit>> UpdateSnippet(this Client @this, string id, UpdateSnippet request)
    {
        var requestUrl = $"/api/labs/snippets/{id}";
        return @this.Put(requestUrl, request)
            .MapAsync(ToResponse<Unit>);
    }
}