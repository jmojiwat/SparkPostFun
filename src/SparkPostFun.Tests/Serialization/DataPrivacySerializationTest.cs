using System.Text.Json;
using FluentAssertions;
using SparkPostFun.Accounts;
using SparkPostFun.Infrastructure;
using Xunit;

namespace SparkPostFun.Tests.Serialization
{
    public class DataPrivacySerializationTest
    {
        [Fact]
        public void AddRequestToBeForgotten_response_returns_expected_result()
        {
            var json = "{                  " +
                       "  \"results\": {   " +
                       "    \"message\": \"Request saved.\" " +
                       "  }                " +
                       "}                  ";

            var response = JsonSerializer.Deserialize<DataPrivacyResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.Message.Should().Be("Request saved.");
        }
    }
}