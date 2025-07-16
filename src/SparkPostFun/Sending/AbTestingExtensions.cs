using System.Threading.Tasks;
using LanguageExt;
using static SparkPostFun.ClientExtensions;
using static LanguageExt.Prelude;

namespace SparkPostFun.Sending;

public static class AbTestingExtensions
{
    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, Unit>>> CancelAbTest(string id)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/ab-test/{id}/cancel"
            select env.Client.Post(requestUrl, new CancelAbTest())
                .MapAsync(ToResponse<Unit>);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, CreateAbTestResponse>>> CreateAbTest(CreateAbTest request)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/ab-test"
            select env.Client.Post(requestUrl, request)
                .MapAsync(ToResponse<CreateAbTestResponse>);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, CreateAbTestDraftResponse>>> CreateAbTestDraft(CreateAbTestDraft request)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/ab-test/draft"
            select env.Client.Post(requestUrl, request)
                .MapAsync(ToResponse<CreateAbTestDraftResponse>);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, Unit>>> DeleteAbTest(string id)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/ab-test/{id}"
            select env.Client.Delete(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, Unit>>> DeleteAbTestDraft(string id)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/ab-test/draft/{id}"
            select env.Client.Delete(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, ListAbTestsResponse>>> ListAbTests()
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/ab-test"
            select env.Client.Get<ListAbTestsResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, ListAbTestsResponse>>> ListAbTests(AbTestingStatus status)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/ab-test?status={status}"
            select env.Client.Get<ListAbTestsResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, RetrieveAbTestResponse>>> RetrieveAbTest(string id)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/ab-test/{id}"
            select env.Client.Get<RetrieveAbTestResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, RetrieveAbTestResponse>>> RetrieveAbTest(string id, int version)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/ab-test/{id}?{version}"
            select env.Client.Get<RetrieveAbTestResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, RetrieveAbTestDraftResponse>>> RetrieveAbTestDraft(string id)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/ab-test/draft/{id}"
            select env.Client.Get<RetrieveAbTestDraftResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, ScheduleAbTestDraftResponse>>> ScheduleAbTestDraft(string id, ScheduleAbTestDraft request)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/ab-test/draft/{id}/schedule"
            select env.Client.Post(requestUrl, request)
                .MapAsync(ToResponse<ScheduleAbTestDraftResponse>);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, UpdateAbTestResponse>>> UpdateAbTest(string id, UpdateAbTest request)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/ab-test/{id}"
            select env.Client.Put(requestUrl, request)
                .MapAsync(ToResponse<UpdateAbTestResponse>);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, UpdateAbTestResponse>>> UpdateAbTestDraft(string id, UpdateAbTest request)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/ab-test/draft/{id}"
            select env.Client.Put(requestUrl, request)
                .MapAsync(ToResponse<UpdateAbTestResponse>);
    }
}