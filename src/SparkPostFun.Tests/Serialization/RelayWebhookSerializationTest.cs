using System.Linq;
using System.Text.Json;
using FluentAssertions;
using SparkPostFun.Infrastructure;
using SparkPostFun.Receiving;
using Xunit;

namespace SparkPostFun.Tests.Serialization;

public class RelayWebhookSerializationTest
{
    [Fact]
    public void Example1_request_returns_expected_result()
    {
        var relayWebhook = new RelayWebhook
        {
            Id = "12013026328707075",
            Name = "Inbound Customer Replies",
            Target = "https://webhooks.customer.example/replies",
            AuthenticationToken = "5ebe2294ecd0e0f08eab7690d2a6ee69",
            Match = new RelayWebhookMatch
            {
                Domain = "example.com"
            }
        };

        var json = "{                                                            " +
                   "  \"id\": \"12013026328707075\",                             " +
                   "  \"name\": \"Inbound Customer Replies\",                    " +
                   "  \"target\": \"https://webhooks.customer.example/replies\", " +
                   "  \"auth_token\": \"5ebe2294ecd0e0f08eab7690d2a6ee69\",      " +
                   "  \"match\": {                                               " +
                   "    \"protocol\": \"SMTP\",                                  " +
                   "    \"domain\": \"example.com\"                              " +
                   "  }                                                          " +
                   "}                                                            ";

        var response = JsonSerializer.Deserialize<RelayWebhook>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        response.Should().BeEquivalentTo(relayWebhook);
    }

    [Fact]
    public void CreateRelayWebhook_response_returns_expected_result()
    {
        var json = "{                                 " +
                   "  \"results\": {                  " +
                   "    \"id\": \"12013026328707075\" " +
                   "  }                               " +
                   "}                                 ";

        var response = JsonSerializer.Deserialize<CreateRelayWebhookResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        response.Results.Id.Should().Be("12013026328707075");
    }

    [Fact]
    public void ValidateRelayWebhook_response_returns_expected_result()
    {
        var json = "{                                                 " +
                   "  \"results\": {                                  " +
                   "    \"msg\": \"Test POST to endpoint succeeded\", " +
                   "    \"response\": {                               " +
                   "      \"status\": 200,                            " +
                   "      \"headers\": {                              " +
                   "        \"Content-Type\": \"text/plain\"          " +
                   "      },                                          " +
                   "      \"body\": \"OK\"                            " +
                   "    }                                             " +
                   "  }                                               " +
                   "}                                                 ";

        var response = JsonSerializer.Deserialize<ValidateRelayWebhookResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        response.Results.Message.Should().Be("Test POST to endpoint succeeded");
        response.Results.Response.Status.Should().Be(200);
        response.Results.Response.Headers.ContainsKey("Content-Type");
        response.Results.Response.Body.Should().Be("OK");
    }

    [Fact]
    public void RetrieveRelayWebhook_response_returns_expected_result()
    {
        var json = "{                                                              " +
                   "  \"results\": {                                               " +
                   "    \"name\": \"Replies Webhook\",                             " +
                   "    \"target\": \"https://webhooks.customer.example/replies\", " +
                   "    \"auth_token\": \"5ebe2294ecd0e0f08eab7690d2a6ee69\",      " +
                   "    \"auth_type\": \"oauth2\",                                 " +
                   "    \"auth_request_details\": {                                " +
                   "      \"url\": \"https://oauth.myurl.com/tokens\",             " +
                   "      \"body\": {                                              " +
                   "        \"client_id\": \"<oauth client id>\",                  " +
                   "        \"client_secret\": \"<oauth client secret>\"           " +
                   "      }                                                        " +
                   "    },                                                         " +
                   "    \"custom_headers\": {                                      " +
                   "      \"x-api-key\": \"abcd\"                                  " +
                   "    },                                                         " +
                   "    \"match\": {                                               " +
                   "      \"protocol\": \"SMTP\",                                  " +
                   "      \"domain\": \"email.example.com\"                        " +
                   "    }                                                          " +
                   "  }                                                            " +
                   "}                                                              ";

        var response = JsonSerializer.Deserialize<RetrieveRelayWebhookResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        response.Results.Name.Should().Be("Replies Webhook");
    }

    [Fact]
    public void UpdateRelayWebhook_response_returns_expected_result()
    {
        var json = "{                                 " +
                   "  \"results\": {                  " +
                   "    \"id\": \"12013026328707075\" " +
                   "  }                               " +
                   "}                                 ";

        var response = JsonSerializer.Deserialize<UpdateRelayWebhookResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        response.Results.Id.Should().Be("12013026328707075");
    }

    [Fact]
    public void ListTrackingDomains_response_returns_expected_result()
    {
        var json = "{                                                                " +
                   "  \"results\": [                                                 " +
                   "    {                                                            " +
                   "      \"id\": \"12013026328707075\",                             " +
                   "      \"name\": \"Replies Webhook\",                             " +
                   "      \"target\": \"https://webhooks.customer.example/replies\", " +
                   "      \"auth_token\": \"5ebe2294ecd0e0f08eab7690d2a6ee69\",      " +
                   "      \"auth_type\": \"oauth2\",                                 " +
                   "      \"auth_request_details\": {                                " +
                   "        \"url\": \"https://oauth.myurl.com/tokens\",             " +
                   "        \"body\": {                                              " +
                   "          \"client_id\": \"<oauth client id>\",                  " +
                   "          \"client_secret\": \"<oauth client secret>\"           " +
                   "        }                                                        " +
                   "      },                                                         " +
                   "      \"custom_headers\": {                                      " +
                   "        \"x-webhook-source\": \"sparkpost\"                      " +
                   "      },                                                         " +
                   "      \"match\": {                                               " +
                   "        \"protocol\": \"SMTP\",                                  " +
                   "        \"domain\": \"email.example.com\"                        " +
                   "      }                                                          " +
                   "    }                                                            " +
                   "  ]                                                              " +
                   "}                                                                ";

        var response = JsonSerializer.Deserialize<ListRelayWebhooksResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        response.Results.First().Id.Should().Be("12013026328707075");
    }
}