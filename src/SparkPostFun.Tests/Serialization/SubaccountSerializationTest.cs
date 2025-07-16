using System.Collections.Generic;
using System.Text.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using SparkPostFun.Accounts;
using SparkPostFun.Infrastructure;
using Xunit;

namespace SparkPostFun.Tests.Serialization
{
    public class SubaccountSerializationTest
    {
           [Fact]
    public void CreateSubaccount_request_returns_expected_result()
    {
        var request = new CreateSubaccount("Sparkle Ponies")
        {
            KeyLabel = "API Key for Sparkle Ponies Subaccount",
            KeyGrants = new List<string>
            {
                "smtp/inject",
                "sending_domains/manage",
                "message_events/view",
                "suppression_lists/manage",
                "tracking_domains/view",
                "tracking_domains/manage",
                "webhooks/modify",
                "webhooks/view"
            },
            KeyValidIps = new List<string>(),
            IpPool = string.Empty,
            Options = new SubaccountOptions
            {
                Deliverability = true
            }
        };

        var json = JsonSerializer.Serialize(request, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        /* expected
            {
              "name": "Sparkle Ponies",
              "key_label": "API Key for Sparkle Ponies Subaccount",
              "key_grants": [
                "smtp/inject",
                "sending_domains/manage",
                "message_events/view",
                "suppression_lists/manage",
                "tracking_domains/view",
                "tracking_domains/manage",
                "webhooks/modify",
                "webhooks/view"
              ],
              "key_valid_ips": [],
              "ip_pool": "",
              "options": {
                "deliverability": true
              }
            }
        */

        var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        obj.GetProperty("name").GetString().Should().Be("Sparkle Ponies");
        obj.GetProperty("key_label").GetString().Should().Be("API Key for Sparkle Ponies Subaccount");
        obj.GetProperty("key_grants")[0].GetString().Should().Be("smtp/inject");
        obj.GetProperty("key_grants")[1].GetString().Should().Be("sending_domains/manage");
        obj.GetProperty("key_grants")[2].GetString().Should().Be("message_events/view");
        obj.GetProperty("key_grants")[3].GetString().Should().Be("suppression_lists/manage");
        obj.GetProperty("key_grants")[4].GetString().Should().Be("tracking_domains/view");
        obj.GetProperty("key_grants")[5].GetString().Should().Be("tracking_domains/manage");
        obj.GetProperty("key_grants")[6].GetString().Should().Be("webhooks/modify");
        obj.GetProperty("key_grants")[7].GetString().Should().Be("webhooks/view");
        
        obj.GetProperty("key_valid_ips").GetArrayLength().Should().Be(0);
        obj.GetProperty("ip_pool").GetString().Should().BeEmpty();
        obj.GetProperty("options").GetProperty("deliverability").GetBoolean().Should().BeTrue();
    }

    [Fact]
    public void UpdateSubaccount_request_returns_expected_result()
    {
        var request = new UpdateSubaccount
        {
            Name = "Hey Joe! Garrage and Parts",
            Status = SubaccountStatus.Suspended,
            IpPool = string.Empty
        };

        var json = JsonSerializer.Serialize(request, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        /* expected
            {
              "name": "Hey Joe! Garage and Parts",
              "status": "suspended",
              "ip_pool": ""
            }
        */

        var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        obj.GetProperty("name").GetString().Should().Be("Hey Joe! Garrage and Parts");
        obj.GetProperty("status").GetString().Should().Be("suspended");
        obj.GetProperty("ip_pool").GetString().Should().BeEmpty();
    }

    [Fact]
    public void UpdateSubaccount_request2_returns_expected_result()
    {
        var request = new UpdateSubaccount
        {
            Options = new SubaccountOptions
            {
                Deliverability = true
            }
        };

        var json = JsonSerializer.Serialize(request, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        /* expected
            {
              "options": {
                "deliverability": true
              }
            }
        */

        var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        obj.GetProperty("options").GetProperty("deliverability").GetBoolean().Should().BeTrue();
    }

        [Fact]
        public void Account_request_returns_expected_result()
        {
            var subaccount = new Subaccount
            {
                Id = 123,
                Name = "Joes Garage",
                Status = SubaccountStatus.Active,
                ComplianceStatus = "active",
                IpPool = "assigned_ip_pool",
                Options = new SubaccountOptions
                {
                    Deliverability = false
                }
            };

            const string json = 
                """
                {
                    "id": 123,
                    "name": "Joes Garage",
                    "status": "active",
                    "compliance_status": "active",
                    "ip_pool": "assigned_ip_pool",
                    "options": {
                        "deliverability": false
                    }
                }
                """;

            var response = JsonSerializer.Deserialize<Subaccount>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Should().BeEquivalentTo(subaccount);
        }

        [Fact]
        public void CreateSubaccount_response_returns_expected_result()
        {
            const string json = 
                """
                {
                  "results": {
                    "subaccount_id": 888,
                    "key": "cf806c8c472562ab98ad5acac1d1b06cbd1fb438",
                    "label": "API Key for Sparkle Ponies Subaccount",
                    "short_key": "cf80"
                  }
                }
                """;

            var response = JsonSerializer.Deserialize<CreateSubaccountResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response!.Results.SubaccountId.Should().Be(888);
            response.Results.Key.Should().Be("cf806c8c472562ab98ad5acac1d1b06cbd1fb438");
            response.Results.Label.Should().Be("API Key for Sparkle Ponies Subaccount");
            response.Results.ShortKey.Should().Be("cf80");

        }

        [Fact]
        public void RetrieveSubaccount_response_returns_expected_result()
        {
            const string json = 
                """
                {
                  "results": {
                    "id": 123,
                    "name": "Joes Garage",
                    "status": "active",
                    "compliance_status": "active",
                    "ip_pool": "assigned_ip_pool",
                    "options": {
                      "deliverability": false
                    }
                  }
                }
                """;

            var response = JsonSerializer.Deserialize<RetrieveSubaccountResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response!.Results.Id.Should().Be(123);
            response.Results.Name.Should().Be("Joes Garage");
            response.Results.Status.Should().Be(SubaccountStatus.Active);
            response.Results.ComplianceStatus.Should().Be("active");
            response.Results.IpPool.Should().Be("assigned_ip_pool");
            response.Results.Options.Deliverability.Should().Be(false);
        }

        [Fact]
        public void UpdateSubaccount_response_returns_expected_result()
        {
            var json = "{                  " +
                       "  \"results\": {   " +
                       "    \"message\": \"Successfully updated subaccount information\" " +
                       "  }                " +
                       "}                  ";

            var response = JsonSerializer.Deserialize<UpdateSubaccountResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response!.Results.Message.Should().Be("Successfully updated subaccount information");
        }

        [Fact]
        public void ListSubaccounts_response_returns_expected_result()
        {
            const string json =
                """
                {
                  "results": [
                    {
                      "id": 123,
                      "name": "Joe's Garage",
                      "status": "active",
                      "ip_pool": "my_ip_pool",
                      "compliance_status": "active",
                      "options": {
                        "deliverability": true
                      }
                    },
                    {
                      "id": 456,
                      "name": "SharkPost",
                      "status": "active",
                      "compliance_status": "active",
                      "options": {
                        "deliverability": true
                      }
                    },
                    {
                      "id": 789,
                      "name": "Dev Avocado",
                      "status": "suspended",
                      "compliance_status": "active",
                      "options": {
                        "deliverability": true
                      }
                    }
                  ]
                }
                """;

            var response = JsonSerializer.Deserialize<ListSubaccountsResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response!.Results[0].Id.Should().Be(123);
            response.Results[0].Name.Should().Be("Joe's Garage");
            response.Results[0].Status.Should().Be(SubaccountStatus.Active);
            response.Results[0].Options.Deliverability.Should().BeTrue();

            response.Results[1].Id.Should().Be(456);
            response.Results[1].Name.Should().Be("SharkPost");
            response.Results[1].Status.Should().Be(SubaccountStatus.Active);
            response.Results[1].Options.Deliverability.Should().BeTrue();

            response.Results[2].Id.Should().Be(789);
            response.Results[2].Name.Should().Be("Dev Avocado");
            response.Results[2].Status.Should().Be(SubaccountStatus.Suspended);
            response.Results[2].Options.Deliverability.Should().BeTrue();
        }

        [Fact]
        public void RetrieveSubaccountSummary_response_returns_expected_result()
        {
            const string json =
                """
                {
                  "results": {
                    "total": 46
                  }
                }
                """;

            var response = JsonSerializer.Deserialize<RetrieveSubaccountsSummaryResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response!.Results.Total.Should().Be(46);
        }
    }
}