using System.Linq;
using System.Text.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using SparkPostFun.Infrastructure;
using SparkPostFun.Receiving;
using Xunit;

namespace SparkPostFun.Tests.Serialization;

public class InboundDomainsSerializationTest
{
    [Fact]
    public void Example1_request_returns_expected_result()
    {
        var request = new InboundDomain
        {
            Domain = "indbound.example.com"
        };

        const string json = "{                                      " +
                            "  \"domain\": \"indbound.example.com\" " +
                            "}                                      ";

        var response = JsonSerializer.Deserialize<InboundDomain>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        response.Should().BeEquivalentTo(request);
    }

    [Fact]
    public void RetrieveSendingDomain_response_returns_expected_result()
    {
        const string json = "{                                        " +
                            "  \"results\": {                         " +
                            "    \"domain\": \"indbound.example.com\" " +
                            "  }                                      " +
                            "}                                        ";

        var response = JsonSerializer.Deserialize<RetrieveInboundDomainResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        response!.Results.Domain.Should().Be("indbound.example.com");
    }

    [Fact]
    public void ListTrackingDomains_response_returns_expected_result()
    {
        const string json = "{                                             " +
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

        response!.Results.Count.Should().Be(2);
        response.Results.First().Domain.Should().Be("indbound.example.com");
    }
    
        [Fact]
    public void CreateInboundDomain_request_returns_expected_result()
    {
        var request = new CreateInboundDomain("indbound.example.com");

        var json = JsonSerializer.Serialize(request, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        /* expected
            {
              "domain": "indbound.example.com"
            }
        */

        var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        obj.GetProperty("domain").GetString().Should().Be("indbound.example.com");
    }

}