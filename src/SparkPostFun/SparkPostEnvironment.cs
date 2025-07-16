namespace SparkPostFun;

public record SparkPostEnvironment
{
    public Client Client { get; init; }
    public string Version { get; init; }
};

/*
public Task<HttpResponseMessage> Post<TRequest>(string requestUri, TRequest request)
{
    return httpClient.PostAsJsonAsync(requestUri, request, JsonSerializerOptions1, CancellationToken.None);
}
*/
