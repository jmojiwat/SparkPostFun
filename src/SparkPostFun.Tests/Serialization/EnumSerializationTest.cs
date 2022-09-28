using System.Text.Json;
using FluentAssertions;
using SparkPostFun.Analytics;
using SparkPostFun.Infrastructure;
using SparkPostFun.Sending;
using Xunit;
using AuthenticationType = SparkPostFun.Receiving.AuthenticationType;
using Metric = SparkPostFun.Sending.Metric;

namespace SparkPostFun.Tests.Serialization
{
    public class EnumSerializationTest
    {
        [Fact]
        public void SuppressionType_returns_expected_result()
        {
            var value = SuppressionType.NonTransactional;
        
            var json = JsonSerializer.Serialize(value, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        
            json.Should().Contain("non_transactional");
        }

        [Fact]
        public void EventType_returns_expected_result()
        {
            var value = EventTypes.SpamComplaint;
        
            var json = JsonSerializer.Serialize(value, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        
            json.Should().Contain("spam_complaint");
        }

        [Fact]
        public void IndustryCategory_returns_expected_result()
        {
            var value = IndustryCategory.B2b;
        
            var json = JsonSerializer.Serialize(value, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        
            json.Should().Contain("b2b");
        }
    
        [Fact]
        public void MetricsSummaryPrecision_returns_expected_result()
        {
            var value = MetricsSummaryPrecision.OneMinute.ToString();
        
            var json = JsonSerializer.Serialize(value, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        
            json.Should().Contain("1min");
        }

        [Fact]
        public void AuthenticationType_returns_expected_result()
        {
            var value = AuthenticationType.Oauth2;
        
            var json = JsonSerializer.Serialize(value, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        
            json.Should().Contain("oauth2");
        }

        [Fact]
        public void Metric_returns_expected_result()
        {
            var value = Metric.CountUniqueClicked;
        
            var json = JsonSerializer.Serialize(value, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        
            json.Should().Contain("count_unique_clicked");
        }

        [Fact]
        public void RecipientValidationReason_returns_expected_result()
        {
            var value = RecipientValidationReason.InvalidSyntax;
        
            var json = JsonSerializer.Serialize(value, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        
            json.Should().Contain("invalid_syntax");
        }

    }
}