using System.Collections.Generic;
using System.Text.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using SparkPostFun.Accounts;
using SparkPostFun.Infrastructure;
using Xunit;

namespace SparkPostFun.Tests.Serialization
{
    public class DataPrivacySerializationTest
    {
        [Fact]
        public void AddRequestToBeForgotten_request_returns_expected_result()
        {
            var recipients = new List<string>
            {
                "email@example.com",
                "email2@example.com"
            };
            var request = new AddDataPrivacy(recipients)
            {
                IncludeSubaccounts = false
            };

            var json = JsonSerializer.Serialize(request, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
            /* expected
                {
                  "recipients": [
                    "email@example.com",
                    "email2@example.com"
                  ],
                  "include_subaccounts": false
                }
            */

            var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            using var scope = new AssertionScope();
            obj.GetProperty("recipients")[0].GetString().Should().Be("email@example.com");
            obj.GetProperty("recipients")[1].GetString().Should().Be("email2@example.com");
            obj.GetProperty("include_subaccounts").GetBoolean().Should().BeFalse();
        }

        [Fact]
        public void AddRequestToBeForgotten_response_returns_expected_result()
        {
            var json = "{                  " +
                       "  \"results\": {   " +
                       "    \"message\": \"Request saved.\" " +
                       "  }                " +
                       "}                  ";

            var response = JsonSerializer.Deserialize<DataPrivacyResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response!.Results.Message.Should().Be("Request saved.");
        }
    }
}