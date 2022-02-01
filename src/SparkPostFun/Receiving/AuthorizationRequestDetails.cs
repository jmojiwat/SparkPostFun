namespace SparkPostFun.Receiving;

public record AuthorizationRequestDetails(string Url, IDictionary<string, object> Body);