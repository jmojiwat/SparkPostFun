namespace SparkPostFun.Analytics;

public record AuthorizationCredentials
{
    public string Username { get; init; }
    public string Password { get; init; }
}