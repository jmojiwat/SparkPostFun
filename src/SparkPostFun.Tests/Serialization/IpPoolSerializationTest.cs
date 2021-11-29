using System.Text.Json;
using FluentAssertions;
using SparkPostFun.Infrastructure;
using SparkPostFun.Sending;
using Xunit;

namespace SparkPostFun.Tests.Serialization
{
    public class IpPoolSerializationTest
    {
        [Fact]
        public void CreateIpPool_response_returns_expected_result()
        {
            var json = "{                                 " +
                       "  \"results\": {                  " +
                       "    \"id\": \"marketing_ip_pool\" " +
                       "  }                               " +
                       "}                                 ";

            var response = JsonSerializer.Deserialize<CreateIpPoolResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.Id.Should().Be("marketing_ip_pool");
        }

        [Fact]
        public void RetrieveIpPool_response_returns_expected_result()
        {
            var json = "{                                                    " +
                       "  \"results\": {                                     " +
                       "    \"id\": \"marketing_ip_pool\",                   " +
                       "    \"name\": \"Marketing IP Pool\",                 " +
                       "    \"fbl_signing_domain\": \"sparkpostmail.com\",   " +
                       "    \"ips\": [                                       " +
                       "      {                                              " +
                       "        \"external_ip\": \"54.244.54.135\",          " +
                       "        \"hostname\": \"mta472a.sparkpostmail.com\", " +
                       "        \"auto_warmup_enabled\": true,               " +
                       "        \"auto_warmup_stage\": 5                     " +
                       "      },                                             " +
                       "      {                                              " +
                       "        \"external_ip\": \"54.244.54.137\",          " +
                       "        \"hostname\": \"mta474a.sparkpostmail.com\", " +
                       "        \"auto_warmup_enabled\": false               " +
                       "      }                                              " +
                       "    ],                                               " +
                       "    \"signing_domain\": \"example.com\",             " +
                       "    \"auto_warmup_overflow_pool\": \"overflow_pool\" " +
                       "  }                                                  " +
                       "}                                                    ";

            var response = JsonSerializer.Deserialize<RetrieveIpPoolResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.Id.Should().Be("marketing_ip_pool");
            response.Results.Ips.Count.Should().Be(2);
        }

        [Fact]
        public void UpdateIpPool_response_returns_expected_result()
        {
            var json = "{                                                    " +
                       "  \"results\": {                                     " +
                       "    \"name\": \"Updated Marketing Pool\",            " +
                       "    \"fbl_signing_domain\": \"sparkpostmail.com\",   " +
                       "    \"id\": \"marketing\",                           " +
                       "    \"auto_warmup_overflow_pool\": \"overflow_pool\" " +
                       "  }                                                  " +
                       "}                                                    ";

            var response = JsonSerializer.Deserialize<UpdateIpPoolResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.Name.Should().Be("Updated Marketing Pool");
        }

        [Fact]
        public void List_response_returns_expected_result()
        {
            var json = "{                                                      " +
                       "  \"results\": [                                       " +
                       "    {                                                  " +
                       "      \"id\": \"marketing_ip_pool\",                   " +
                       "      \"name\": \"Marketing IP Pool\",                 " +
                       "      \"ips\": [],                                     " +
                       "      \"signing_domain\": \"example.com\",             " +
                       "      \"fbl_signing_domain\": \"sparkpostmail.com\",   " +
                       "      \"auto_warmup_overflow_pool\": \"overflow_pool\" " +
                       "    },                                                 " +
                       "    {                                                  " +
                       "      \"id\": \"default\",                             " +
                       "      \"name\": \"Default\",                           " +
                       "      \"ips\": [                                       " +
                       "        {                                              " +
                       "          \"external_ip\": \"54.244.54.135\",          " +
                       "          \"hostname\": \"mta472a.sparkpostmail.com\", " +
                       "          \"auto_warmup_enabled\": true,               " +
                       "          \"auto_warmup_stage\": 5                     " +
                       "        }                                              " +
                       "      ]                                                " +
                       "    }                                                  " +
                       "  ]                                                    " +
                       "}                                                      ";

            var response = JsonSerializer.Deserialize<ListIpPoolsResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.Count.Should().Be(2);
        }
    }
}