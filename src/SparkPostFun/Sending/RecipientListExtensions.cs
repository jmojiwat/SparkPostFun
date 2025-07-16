using System.Threading.Tasks;
using LanguageExt;
using static SparkPostFun.ClientExtensions;
using static LanguageExt.Prelude;

namespace SparkPostFun.Sending;

public static class RecipientListExtensions
{
    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, CreateRecipientListResponse>>>
        CreateRecipientList(CreateRecipientList request)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/recipient-lists"
            select env.Client.Post(requestUrl, request)
                .MapAsync(ToResponse<CreateRecipientListResponse>);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, CreateRecipientListResponse>>>
        CreateRecipientList(CreateRecipientList request,
            int numberOfRecipientErrors)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/recipient-lists?num_rcpt_errors={numberOfRecipientErrors}"
            select env.Client.Post(requestUrl, request)
                .MapAsync(ToResponse<CreateRecipientListResponse>);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, Unit>>> DeleteRecipientList(
        string id)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/recipient-lists/{id}"
            select env.Client.Delete(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, ListRecipientListsResponse>>>
        ListRecipientLists()
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/recipient-lists"
            select env.Client.Get<ListRecipientListsResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, RetrieveRecipientListResponse>>>
        RetrieveRecipientList(string id, bool showRecipients = false)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/recipient-lists/{id}?show_recipients={showRecipients}"
            select env.Client.Get<RetrieveRecipientListResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, UpdateRecipientListResponse>>>
        UpdateRecipientList(string id, UpdateRecipientList request)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/recipient-lists/{id}"
            select env.Client.Put(requestUrl, request)
                .MapAsync(ToResponse<UpdateRecipientListResponse>);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, UpdateRecipientListResponse>>>
        UpdateRecipientList(string id, UpdateRecipientList request, int numberOfRecipientErrors)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/recipient-lists/{id}?num_rcpt_errors={numberOfRecipientErrors}"
            select env.Client.Put(requestUrl, request)
                .MapAsync(ToResponse<UpdateRecipientListResponse>);
    }
}