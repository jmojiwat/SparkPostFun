using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using SparkPostFun.Infrastructure;
using SparkPostFun.Receiving;
using Xunit;

namespace SparkPostFun.Tests.Serialization
{
    public class RelayWebhookSerializationTest
    {
        [Fact]
        public void CreateRelayWebhook_request_returns_expected_result()
        {
            var request = new CreateRelayWebhook("https://webhooks.customer.example/replies", new RelayWebhookMatch("email.example.com"))
            {
                Name = "Replies Webhook",
                AuthenticationToken = "5ebe2294ecd0e0f08eab7690d2a6ee69",
                AuthenticationType = AuthenticationType.Oauth2,
                AuthorizationRequestDetails = new AuthorizationRequestDetails(
                    "http://client.example.com/tokens",
                    new Dictionary<string, object>
                    {
                        { "client_id", "CLIENT123" },
                        { "client_secret", "9sdfj791d2bsbf" }
                    }),
                CustomHeaders = new Dictionary<string, object>
                {
                    { "x-api-key", "abcd" }
                }
            };

            var json = JsonSerializer.Serialize(request, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            using var scope = new AssertionScope();
            obj.GetProperty("name").GetString().Should().Be("Replies Webhook");
            obj.GetProperty("target").GetString().Should().Be("https://webhooks.customer.example/replies");
            obj.GetProperty("auth_token").GetString().Should().Be("5ebe2294ecd0e0f08eab7690d2a6ee69");
            obj.GetProperty("auth_type").GetString().Should().Be("oauth2");
            obj.GetProperty("auth_request_details").GetProperty("url").GetString().Should().Be("http://client.example.com/tokens");
            obj.GetProperty("auth_request_details").GetProperty("body").GetProperty("client_id").GetString().Should().Be("CLIENT123");
            obj.GetProperty("auth_request_details").GetProperty("body").GetProperty("client_secret").GetString().Should().Be("9sdfj791d2bsbf");

            obj.GetProperty("custom_headers").GetProperty("x-api-key").GetString().Should().Be("abcd");
            obj.GetProperty("match").GetProperty("domain").GetString().Should().Be("email.example.com");
        }

        [Fact]
        public void CreateRelayWebhook_response_returns_expected_result()
        {
            const string json = 
                """
                {
                  "results": {
                    "id": "12013026328707075"
                  }
                }
                """;

            var response = JsonSerializer.Deserialize<CreateRelayWebhookResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response!.Results.Id.Should().Be("12013026328707075");
        }

        [Fact]
        public void Example1_request_returns_expected_result()
        {
            var relayWebhook = new RelayWebhook
            {
                Id = "12013026328707075",
                Name = "Inbound Customer Replies",
                Target = "https://webhooks.customer.example/replies",
                AuthenticationToken = "5ebe2294ecd0e0f08eab7690d2a6ee69",
                Match = new RelayWebhookMatch("example.com")
            };

            const string json =
                """
                {
                  "id": "12013026328707075",
                  "name": "Inbound Customer Replies",
                  "target": "https://webhooks.customer.example/replies",
                  "auth_token": "5ebe2294ecd0e0f08eab7690d2a6ee69",
                  "match": {
                    "protocol": "SMTP",
                    "domain": "example.com"
                  }
                }
                """;

            var response = JsonSerializer.Deserialize<RelayWebhook>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Should().BeEquivalentTo(relayWebhook);
        }

        [Fact]
        public void Example2_request_returns_expected_result()
        {
            var relayWebhookPayload = new RelayWebhookPayload
            {
                Content = new RelayWebhookPayloadContent
                {
                    EmailRfc822 =
                        "Return-Path: <me@here.com>\r\nMIME-Version: 1.0\r\nFrom: me@here.com\r\nReceived: by 10.114.82.10 with HTTP; Mon, 4 Jul 2016 07:53:14 -0700 (PDT)\r\nDate: Mon, 4 Jul 2016 15:53:14 +0100\r\nMessage-ID: <484810298443-112311-xqxbby@mail.there.com>\r\nSubject: Relay webhooks rawk!\r\nTo: you@there.com\r\nContent-Type: multipart/alternative; boundary=deaddeaffeedf00fall45dbhail980dhypnot0ad\r\n\r\n--deaddeaffeedf00fall45dbhail980dhypnot0ad\r\nContent-Type: text/plain; charset=UTF-8\r\nHi there SparkPostians.\r\n\r\n--deaddeaffeedf00fall45dbhail980dhypnot0ad\r\nContent-Type: text/html; charset=UTF-8\r\n\r\n<p>Hi there <strong>SparkPostians</strong></p>\r\n\r\n--deaddeaffeedf00fall45dbhail980dhypnot0ad--\r\n",
                    EmailRfc822IsBase64 = false,
                    Headers = new Dictionary<string, object>
                    {
                        {
                            "Return-Path", "<me@here.com>"
                        },
                        {
                            "MIME-Version", "1.0"
                        },
                        {
                            "From", "me@here.com"
                        },
                        {
                            "Received", "by 10.114.82.10 with HTTP; Mon, 4 Jul 2016 07:53:14 -0700 (PDT)"
                        },
                        {
                            "Date", "Mon, 4 Jul 2016 15:53:14 +0100"
                        },
                        {
                            "Message-ID", "<484810298443-112311-xqxbby@mail.there.com>"
                        },
                        {
                            "Subject", "Relay webhooks rawk!"
                        },
                        {
                            "To", "you@there.com"
                        }
                    },
                    Html = "<p>Hi there <strong>SparkPostians</strong>.</p>",
                    Subject = "We come in peace",
                    Text = "Hi there SparkPostians.",
                    To = new List<string>
                    {
                        "your@yourdomain.com"
                    }
                },
                CustomerId = "1337",
                FriendlyFrom = "me@here.com",
                MessageFrom = "me@here.com",
                ReceiptTo = "you@there.com",
                WebhookId = "4839201967643219"
            };

            const string
                json =
                    """
                    [
                      {
                        "msys": {
                          "relay_message": {
                            "content": {
                              "email_rfc822": "Return-Path: <me@here.com>\r\nMIME-Version: 1.0\r\nFrom: me@here.com\r\nReceived: by 10.114.82.10 with HTTP; Mon, 4 Jul 2016 07:53:14 -0700 (PDT)\r\nDate: Mon, 4 Jul 2016 15:53:14 +0100\r\nMessage-ID: <484810298443-112311-xqxbby@mail.there.com>\r\nSubject: Relay webhooks rawk!\r\nTo: you@there.com\r\nContent-Type: multipart/alternative; boundary=deaddeaffeedf00fall45dbhail980dhypnot0ad\r\n\r\n--deaddeaffeedf00fall45dbhail980dhypnot0ad\r\nContent-Type: text/plain; charset=UTF-8\r\n\r\nHi there SparkPostians.\r\n\r\n--deaddeaffeedf00fall45dbhail980dhypnot0ad\r\nContent-Type: text/html; charset=UTF-8\r\n\r\n<p>Hi there <strong>SparkPostians</strong></p>\r\n\r\n--deaddeaffeedf00fall45dbhail980dhypnot0ad--\r\n",
                              "email_rfc822_is_base64": false,
                              "headers": [
                                {
                                  "Return-Path": "<me@here.com>"
                                },
                                {
                                  "MIME-Version": "1.0"
                                },
                                {
                                  "From": "me@here.com"
                                },
                                {
                                  "Received": "by 10.114.82.10 with HTTP; Mon, 4 Jul 2016 07:53:14 -0700 (PDT)"
                                },
                                {
                                  "Date": "Mon, 4 Jul 2016 15:53:14 +0100"
                                },
                                {
                                  "Message-ID": "<484810298443-112311-xqxbby@mail.there.com>"
                                },
                                {
                                  "Subject": "Relay webhooks rawk!"
                                },
                                {
                                  "To": "you@there.com"
                                }
                              ],
                              "html": "<p>Hi there <strong>SparkPostians</strong>.</p>",
                              "subject": "We come in peace",
                              "text": "Hi there SparkPostians.",
                              "to": [
                                "your@yourdomain.com"
                              ]
                            },
                            "customer_id": "1337",
                            "friendly_from": "me@here.com",
                            "msg_from": "me@here.com",
                            "rcpt_to": "you@there.com",
                            "webhook_id": "4839201967643219"
                          }
                        }
                      }
                    ]
                    """;

            var response = JsonSerializer.Deserialize<RelayWebhookPayload>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Should().BeEquivalentTo(relayWebhookPayload);
        }

        [Fact]
        public void ListTrackingDomains_response_returns_expected_result()
        {
            const string json = 
                """
                {
                  "results": [
                    {
                      "id": "12013026328707075",
                      "name": "Replies Webhook",
                      "target": "https://webhooks.customer.example/replies",
                      "auth_token": "5ebe2294ecd0e0f08eab7690d2a6ee69",
                      "auth_type": "oauth2",
                      "auth_request_details": {
                        "url": "https://oauth.myurl.com/tokens",
                        "body": {
                          "client_id": "<oauth client id>",
                          "client_secret": "<oauth client secret>"
                        }
                      },
                      "custom_headers": {
                        "x-webhook-source": "sparkpost"
                      },
                      "match": {
                        "protocol": "SMTP",
                        "domain": "email.example.com"
                      }
                    }
                  ]
                }
                """;

            var response = JsonSerializer.Deserialize<ListRelayWebhooksResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response!.Results.First().Id.Should().Be("12013026328707075");
        }

        [Fact]
        public void RetrieveRelayWebhook_response_returns_expected_result()
        {
            const string json = 
                """
                {
                  "results": {
                    "name": "Replies Webhook",
                    "target": "https://webhooks.customer.example/replies",
                    "auth_token": "5ebe2294ecd0e0f08eab7690d2a6ee69",
                    "auth_type": "oauth2",
                    "auth_request_details": {
                      "url": "https://oauth.myurl.com/tokens",
                      "body": {
                        "client_id": "<oauth client id>",
                        "client_secret": "<oauth client secret>"
                      }
                    },
                    "custom_headers": {
                      "x-api-key": "abcd"
                    },
                    "match": {
                      "protocol": "SMTP",
                      "domain": "email.example.com"
                    }
                  }
                }
                """;

            var response = JsonSerializer.Deserialize<RetrieveRelayWebhookResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response!.Results.Name.Should().Be("Replies Webhook");
        }

        [Fact]
        public void UpdateRelayWebhook_request_returns_expected_result()
        {
            var request = new UpdateRelayWebhookRequest
            {
                Name = "New Replies Webhook",
                Target = "https://webhook.customer.example/replies",
                AuthenticationToken = "A different auth token",
                AuthorizationType = AuthenticationType.None,
                CustomHeaders = new Dictionary<string, object>
                {
                    { "x-api-key", "abcd" }
                },
                Match = new RelayWebhookMatch("email.a-different-domain.com")
            };

            var json = JsonSerializer.Serialize(request, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            using var scope = new AssertionScope();
            obj.GetProperty("name").GetString().Should().Be("New Replies Webhook");
            obj.GetProperty("target").GetString().Should().Be("https://webhook.customer.example/replies");
            obj.GetProperty("auth_token").GetString().Should().Be("A different auth token");
            obj.GetProperty("auth_type").GetString().Should().Be("none");
            obj.GetProperty("custom_headers").GetProperty("x-api-key").GetString().Should().Be("abcd");
            obj.GetProperty("match").GetProperty("domain").GetString().Should().Be("email.a-different-domain.com");
        }

        [Fact]
        public void UpdateRelayWebhook_response_returns_expected_result()
        {
            var json = 
                """
                {
                  "results": {
                    "id": "12013026328707075"
                  }
                }
                """;

            var response = JsonSerializer.Deserialize<UpdateRelayWebhookResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response!.Results.Id.Should().Be("12013026328707075");
        }

        [Fact(Skip = "Validate a Relay Webhook documentation unclear.")]
        public void ValidateRelayWebhook_request_returns_expected_result()
        {
            var request = new ValidateRelayWebhook();

            var json = JsonSerializer.Serialize(request, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
            /* expected
            */

            var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        }

        [Fact]
        public void ValidateRelayWebhook_response_returns_expected_result()
        {
            const string json = 
                """
                {
                  "results": {
                    "msg": "Test POST to endpoint succeeded",
                    "response": {
                      "status": 200,
                      "headers": {
                        "Content-Type": "text/plain"
                      },
                      "body": "OK"
                    }
                  }
                }
                """;

            var response = JsonSerializer.Deserialize<ValidateRelayWebhookResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response!.Results.Message.Should().Be("Test POST to endpoint succeeded");
            response.Results.Response.Status.Should().Be(200);
            response.Results.Response.Headers["Content-Type"].Should().Be("text/plain");
            response.Results.Response.Body.Should().Be("OK");
        }
    }
}