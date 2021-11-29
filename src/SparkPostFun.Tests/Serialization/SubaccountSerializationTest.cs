using System.Linq;
using System.Text.Json;
using FluentAssertions;
using SparkPostFun.Accounts;
using SparkPostFun.Infrastructure;
using SparkPostFun.Sending;
using Xunit;

namespace SparkPostFun.Tests.Serialization
{
    public class SubaccountSerializationTest
    {
        [Fact]
        public void Account_request_returns_expected_result()
        {
            var subaccount = new Subaccount
            {
                Id = 123,
                Name = "Joes Garage",
                Status = SubaccountStatus.active,
                ComplianceStatus = "active",
                IpPool = "assigned_ip_pool",
                Options = new SubaccountOptions
                {
                    Deliverability = false
                }
            };

            var json = "{                                      " +
                       "    \"id\": 123,                       " +
                       "    \"name\": \"Joes Garage\",         " +
                       "    \"status\": \"active\",            " +
                       "    \"compliance_status\": \"active\", " +
                       "    \"ip_pool\": \"assigned_ip_pool\", " +
                       "    \"options\": {                      " +
                       "        \"deliverability\": false      " +
                       "    }                                  " +
                       "}                                      ";

            var response = JsonSerializer.Deserialize<Subaccount>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Should().BeEquivalentTo(subaccount);
        }

        [Fact]
        public void CreateSubaccount_response_returns_expected_result()
        {
            var json = "{                                                          " +
                       "  \"results\": {                                           " +
                       "    \"subaccount_id\": 888,                                " +
                       "    \"key\": \"cf806c8c472562ab98ad5acac1d1b06cbd1fb438\", " +
                       "    \"label\": \"API Key for Sparkle Ponies Subaccount\",  " +
                       "    \"short_key\": \"cf80\"                                " +
                       "  }                                                        " +
                       "}                                                          ";

            var response = JsonSerializer.Deserialize<CreateSubaccountResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.SubaccountId.Should().Be(888);
            response.Results.Key.Should().Be("cf806c8c472562ab98ad5acac1d1b06cbd1fb438");
            response.Results.Label.Should().Be("API Key for Sparkle Ponies Subaccount");
            response.Results.ShortKey.Should().Be("cf80");

        }

        [Fact]
        public void RetrieveSubaccount_response_returns_expected_result()
        {
            var json = "{                                      " +
                       "  \"results\": {                       " +
                       "    \"id\": 123,                       " +
                       "    \"name\": \"Joes Garage\",         " +
                       "    \"status\": \"active\",            " +
                       "    \"compliance_status\": \"active\", " +
                       "    \"ip_pool\": \"assigned_ip_pool\", " +
                       "    \"options\": {                     " +
                       "      \"deliverability\": false        " +
                       "    }                                  " +
                       "  }                                    " +
                       "}                                      ";

            var response = JsonSerializer.Deserialize<RetrieveSubaccountResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.Id.Should().Be(123);
            response.Results.Name.Should().Be("Joes Garage");
            response.Results.Status.Should().Be(SubaccountStatus.active);
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

            response.Results.Message.Should().Be("Successfully updated subaccount information");
        }

        [Fact]
        public void ListSubaccounts_response_returns_expected_result()
        {
            var json = "{                                         " +
                       "  \"results\": [                          " +
                       "    {                                     " +
                       "      \"id\": 123,                        " +
                       "      \"name\": \"Joe's Garage\",         " +
                       "      \"status\": \"active\",             " +
                       "      \"ip_pool\": \"my_ip_pool\",        " +
                       "      \"compliance_status\": \"active\",  " +
                       "      \"options\": {                      " +
                       "        \"deliverability\": true          " +
                       "      }                                   " +
                       "    },                                    " +
                       "    {                                     " +
                       "      \"id\": 456,                        " +
                       "      \"name\": \"SharkPost\",            " +
                       "      \"status\": \"active\",             " +
                       "      \"compliance_status\": \"active\",  " +
                       "      \"options\": {                      " +
                       "        \"deliverability\": true          " +
                       "      }                                   " +
                       "    },                                    " +
                       "    {                                     " +
                       "      \"id\": 789,                        " +
                       "      \"name\": \"Dev Avocado\",          " +
                       "      \"status\": \"suspended\",          " +
                       "      \"compliance_status\": \"active\",  " +
                       "      \"options\": {                      " +
                       "        \"deliverability\": true          " +
                       "      }                                   " +
                       "    }                                     " +
                       "  ]                                       " +
                       "}                                         ";

            var response = JsonSerializer.Deserialize<ListSubaccountsResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.First().Id.Should().Be(123);
            response.Results.First().Name.Should().Be("Joe's Garage");
            response.Results.First().Status.Should().Be(SubaccountStatus.active);
            response.Results.First().Options.Deliverability.Should().Be(true);
        }

        [Fact]
        public void RetrieveSubaccountSummary_response_returns_expected_result()
        {
            var json = "{                 " +
                       "  \"results\": {  " +
                       "    \"total\": 46 " +
                       "  }               " +
                       "}                 ";

            var response = JsonSerializer.Deserialize<RetrieveSubaccountsSummaryResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.Total.Should().Be(46);
        }
    }
}