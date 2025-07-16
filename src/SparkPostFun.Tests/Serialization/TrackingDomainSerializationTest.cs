using System.Linq;
using System.Text.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using SparkPostFun.Infrastructure;
using SparkPostFun.Sending;
using Xunit;

namespace SparkPostFun.Tests.Serialization
{
    public class TrackingDomainSerializationTest
    {
        [Fact]
        public void CreateTrackingDomain_request_returns_expected_result()
        {
            var request = new CreateTrackingDomain("example.domain.com")
            {
                Secure = true
            };
        
            var json = JsonSerializer.Serialize(request, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
            /* expected
                {
                  "domain": "example.domain.com",
                  "secure": true
                }
            */
        
            var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        
            using var scope = new AssertionScope();
            obj.GetProperty("domain").GetString().Should().Be("example.domain.com");
            obj.GetProperty("secure").GetBoolean().Should().BeTrue();
        }


        [Fact]
        public void CreateTrackingDomain_response_returns_expected_result()
        {
            const string json = 
                """
                {
                  "results": {
                    "domain": "example.domain.com"
                  }
                }
                """;

            var response = JsonSerializer.Deserialize<CreateTrackingDomainResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.Domain.Should().Be("example.domain.com");
        }

        [Fact]
        public void VerifyTrackingDomain_response_returns_expected_result()
        {
            const string json = 
                """
                {
                  "results": {
                    "verified": true,
                    "cname_status": "pending",
                    "compliance_status": "valid"
                  }
                }
                """;

            var response = JsonSerializer.Deserialize<VerifyTrackingDomainResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.Verified.Should().Be(true);
        }

        [Fact]
        public void RetrieveTrackingDomain_response_returns_expected_result()
        {
            var json = 
                """
                {
                  "results": {
                    "port": 443,
                    "domain": "example.domain.com",
                    "secure": true,
                    "default": true,
                    "status": {
                      "verified": false,
                      "cname_status": "pending",
                      "compliance_status": "pending"
                    }
                  }
                }
                """;

            var response = JsonSerializer.Deserialize<RetrieveTrackingDomainResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.Port.Should().Be(443);
            response.Results.Status.Verified.Should().Be(false);
        }

        [Fact]
        public void UpdateTrackingDomain_request_returns_expected_result()
        {
            var request = new UpdateTrackingDomain
            {
                Secure = true,
                Default = true
            };
        
            var json = JsonSerializer.Serialize(request, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
            /* expected
                {
                  "secure": true,
                  "default": true
                }
            */
        
            var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        
            using var scope = new AssertionScope();
            obj.GetProperty("secure").GetBoolean().Should().BeTrue();
            obj.GetProperty("default").GetBoolean().Should().BeTrue();
        }

    
        [Fact]
        public void UpdateTrackingDomain_response_returns_expected_result()
        {
            var json = 
                """
                {
                  "results": {
                    "domain": "example.domain.com"
                  }
                }
                """;

            var response = JsonSerializer.Deserialize<UpdateTrackingDomainResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.Domain.Should().Be("example.domain.com");
        }

        [Fact]
        public void ListTrackingDomains_response_returns_expected_result()
        {
            var json = 
                """
                {
                  "results": [
                    {
                      "port": 443,
                      "domain": "example.domain.com",
                      "secure": true,
                      "default": true,
                      "status": {
                        "verified": false,
                        "cname_status": "pending",
                        "compliance_status": "pending"
                      }
                    },
                    {
                      "port": 80,
                      "domain": "example2.domain.com",
                      "secure": false,
                      "default": false,
                      "status": {
                        "verified": true,
                        "cname_status": "valid",
                        "compliance_status": "valid"
                      },
                      "subaccount_id": 215
                    }
                  ]
                }
                """;

            var response = JsonSerializer.Deserialize<ListTrackingDomainsResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.Count.Should().Be(2);
            response.Results.First().Port.Should().Be(443);
        }
    }
}