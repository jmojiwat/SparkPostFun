using System.Linq;
using System.Text.Json;
using FluentAssertions;
using SparkPostFun.Infrastructure;
using SparkPostFun.Receiving;
using Xunit;

namespace SparkPostFun.Tests.Serialization
{
    public class InboundDomainSerializationTest
    {
        [Fact]
        public void Example1_request_returns_expected_result()
        {
            var inboundDomain = new InboundDomain
            {
                Domain = "indbound.example.com"
            };

            var json = "{                                      " +
                       "  \"domain\": \"indbound.example.com\" " +
                       "}                                      ";

            var response = JsonSerializer.Deserialize<InboundDomain>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Should().BeEquivalentTo(inboundDomain);
        }

        [Fact]
        public void RetrieveSendingDomain_response_returns_expected_result()
        {
            var json = "{                                        " +
                       "  \"results\": {                         " +
                       "    \"domain\": \"indbound.example.com\" " +
                       "  }                                      " +
                       "}                                        ";

            var response = JsonSerializer.Deserialize<RetrieveInboundDomainResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.Domain.Should().Be("indbound.example.com");
        }

        [Fact]
        public void ListTrackingDomains_response_returns_expected_result()
        {
            var json = "{                                             " +
                       "  \"results\": [                              " +
                       "    {                                         " +
                       "      \"domain\": \"indbound.example.com\"    " +
                       "    },                                        " +
                       "    {                                         " +
                       "      \"domain\": \"inbounddomain2.test.com\" " +
                       "    }                                         " +
                       "  ]                                           " +
                       "}                                             ";

            var response = JsonSerializer.Deserialize<ListInboundDomainsResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.Count.Should().Be(2);
            response.Results.First().Domain.Should().Be("indbound.example.com");
        }
    }
}