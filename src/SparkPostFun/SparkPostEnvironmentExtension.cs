using System.Net.Http;

namespace SparkPostFun;

public static class SparkPostEnvironmentExtension
{
    public static SparkPostEnvironment InitializeEnvironment(HttpClient httpClient, string apiKey, string host = Hosts.Host,
        string version = "v1")
    {
        var client = new Client(httpClient, apiKey, host, version);

        return new SparkPostEnvironment
        {
            Client = client,
            Version = version
        };
    }
}
