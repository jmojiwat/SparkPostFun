namespace SparkPostFun.Analytics;

public record GeoIp
{
    public string country { get; init; }
    public string region { get; init; }
    public string city { get; init; }
    public decimal latitude { get; init; }
    public decimal longitude { get; init; }
    
}