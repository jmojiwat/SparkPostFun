using LanguageExt;

namespace SparkPostFun.Analytics;

public static class ClientMetricsExtensions
{
    public static Task<Either<ErrorResponse, AdvancedQueryJsonSchemaResponse>> AdvancedQueryJsonSchema(this Client @this)
    {
        var requestUrl = $"/api/{@this.Version}/deliverability/query-filters-schema";
        return @this.Get<AdvancedQueryJsonSchemaResponse>(requestUrl);
    }
    
    public static Task<Either<ErrorResponse, DiscoverabilityLinksResponse>> DiscoverabilityLinks(this Client @this)
    {
        var requestUrl = $"/api/{@this.Version}/metrics";
        return @this.Get<DiscoverabilityLinksResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, DiscoverabilityLinksResponse>> MetricsSummary(this Client @this, DateTime from, IList<Metric> metrics)
    {
        var metricsList = string.Join(',', metrics);
        var requestUrl = $"/api/{@this.Version}/metrics/deliverability?from={from:yyyy-MM-dd}T{from:hh:mm}&metrics={metricsList}";
        return @this.Get<DiscoverabilityLinksResponse>(requestUrl);
    }
    
    public static Task<Either<ErrorResponse, DiscoverabilityLinksResponse>> MetricsSummary(this Client @this, DateTime from, IList<Metric> metrics, MetricsSummaryRequest request)
    {
        throw new NotImplementedException();
        var metricsList = string.Join(',', metrics);
        var requestUrl = $"/api/{@this.Version}/metrics/deliverability?from={from:yyyy-MM-dd}T{from:hh:mm}&metrics={metricsList}";
        return @this.Get<DiscoverabilityLinksResponse>(requestUrl);
    }
}