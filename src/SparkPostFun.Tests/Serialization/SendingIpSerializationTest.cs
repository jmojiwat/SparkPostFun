using System.Text.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using SparkPostFun.Infrastructure;
using SparkPostFun.Sending;
using Xunit;

namespace SparkPostFun.Tests.Serialization
{
    public class SendingIpSerializationTest
    {
        [Fact]
        public void ListSendingIp_response_returns_expected_result()
        {
            var json = "{                                                  " +
                       "  \"results\": [                                   " +
                       "    {                                              " +
                       "      \"external_ip\": \"123.45.67.89\",           " +
                       "      \"hostname\": \"mta472a.sparkpostmail.com\", " +
                       "      \"ip_pool\": \"marketing\",                  " +
                       "      \"customer_provided\": false,                " +
                       "      \"auto_warmup_enabled\": true,               " +
                       "      \"auto_warmup_stage\": 5                     " +
                       "    },                                             " +
                       "    {                                              " +
                       "      \"external_ip\": \"123.45.67.80\",           " +
                       "      \"hostname\": \"mta474a.sparkpostmail.com\", " +
                       "      \"ip_pool\": \"default\",                    " +
                       "      \"customer_provided\": false,                " +
                       "      \"auto_warmup_enabled\": false               " +
                       "    }                                              " +
                       "  ]                                                " +
                       "}                                                  ";

            var response = JsonSerializer.Deserialize<ListSendingIpsResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.Count.Should().Be(2);
        }

        [Fact]
        public void RetrieveSendingIp_response_returns_expected_result()
        {
            const string json = "{                                                " +
                                "  \"results\": {                                 " +
                                "    \"external_ip\": \"123.45.67.89\",           " +
                                "    \"hostname\": \"mta472a.sparkpostmail.com\", " +
                                "    \"ip_pool\": \"cool_kids\",                  " +
                                "    \"customer_provided\": false,                " +
                                "    \"auto_warmup_enabled\": true,               " +
                                "    \"auto_warmup_stage\": 5                     " +
                                "  }                                              " +
                                "}                                                ";

            var response = JsonSerializer.Deserialize<RetrieveSendingIpResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response!.Results.ExternalIp.Should().Be("123.45.67.89");
        }

        [Fact]
        public void UpdateSendingIp_request_returns_expected_result()
        {
            var request = new UpdateSendingIp
            {
                IpPool = "too_cool_for_pool"
            };

            var json = JsonSerializer.Serialize(request, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
            /* expected
                {
                  "ip_pool": "too_cool_for_pool"
                }
            */

            var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            using var scope = new AssertionScope();
            obj.GetProperty("ip_pool").GetString().Should().Be("too_cool_for_pool");
        }

        [Fact]
        public void UpdateSendingIp_response_returns_expected_result()
        {
            const string json = "{                                        " +
                                "  \"results\": {                         " +
                                "    \"message\": \"Updated Sending IP.\" " +
                                "  }                                      " +
                                "}                                        ";

            var response = JsonSerializer.Deserialize<UpdateSendingIpResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response!.Results.Message.Should().Be("Updated Sending IP.");
        }
    }
}