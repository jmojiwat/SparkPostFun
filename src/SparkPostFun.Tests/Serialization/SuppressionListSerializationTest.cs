using System.Collections.Generic;
using System.Text.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using SparkPostFun.Infrastructure;
using SparkPostFun.Sending;
using Xunit;

namespace SparkPostFun.Tests.Serialization
{
    public class SuppressionListSerializationTest
    {
        [Fact]
        public void BulkCreateOrUpdateSuppressions_request_returns_expected_result()
        {
            var recipients = new List<CreateOrUpdateSuppressionRecipient>
            {
                new("rcpt_1@example.com", SuppressionType.Transactional) { 
                    Description = "User requested to not receive any transactional emails."
                },
                new("rcpt_2@example.com", SuppressionType.NonTransactional)
                {
                    Description = "User requested to not receive any non-transactional emails."
                }
            };
            var suppressions = new BulkCreateOrUpdateSuppressions(recipients);

            var json = JsonSerializer.Serialize(suppressions, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
            /* expected:
            {
                "recipients": [
                {
                    "recipient": "rcpt_1@example.com",
                    "type": "transactional",
                    "description": "User requested to not receive any transactional emails."
                },
                {
                    "recipient": "rcpt_2@example.com",
                    "type": "non_transactional",
                    "description": "User requested to not receive any non-transactional emails."
                }
                ]
            }
            */

            var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            using var scope = new AssertionScope();
            obj.GetProperty("recipients")[0].GetProperty("recipient").GetString().Should().Be("rcpt_1@example.com");
            obj.GetProperty("recipients")[0].GetProperty("type").GetString().Should().Be("transactional");
            obj.GetProperty("recipients")[0].GetProperty("description").GetString().Should().Be("User requested to not receive any transactional emails.");

            obj.GetProperty("recipients")[1].GetProperty("recipient").GetString().Should().Be("rcpt_2@example.com");
            obj.GetProperty("recipients")[1].GetProperty("type").GetString().Should().Be("non_transactional");
            obj.GetProperty("recipients")[1].GetProperty("description").GetString().Should().Be("User requested to not receive any non-transactional emails.");
        }

        [Fact]
        public void CreateOrUpdateSuppressions_request_returns_expected_result()
        {
            var suppressions = new CreateOrUpdateSuppression(SuppressionType.Transactional)
            {
                Description = "Unsubscribe from newsletter"
            };

            var json = JsonSerializer.Serialize(suppressions, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
            /* expected:
                {
                  "type": "transactional",
                  "description": "Unsubscribe from newsletter"
                }
            */

            var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            using var scope = new AssertionScope();
            obj.GetProperty("type").GetString().Should().Be("transactional");
            obj.GetProperty("description").GetString().Should().Be("Unsubscribe from newsletter");
        }

        [Fact]
        public void BulkCreateOrUpdateSuppressions_response_returns_expected_result()
        {
            var json =
                """
                {
                  "results": {
                    "message": "Suppression List successfully updated"
                  }
                }
                """;

            var response = JsonSerializer.Deserialize<BulkCreateOrUpdateSuppressionsResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.Message.Should().Be("Suppression List successfully updated");
        }

        [Fact]
        public void CreateOrUpdateSuppression_response_returns_expected_result()
        {
            var json = 
                """
                {
                  "results": {
                    "message": "Suppression list successfully updated"
                  }
                }
                """;

            var response = JsonSerializer.Deserialize<CreateOrUpdateSuppressionResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.Message.Should().Be("Suppression list successfully updated");
        }

        [Fact]
        public void RetrieveSuppression_response_returns_expected_result()
        {
            var json =
                """
                {
                  "results": [
                    {
                      "recipient": "rcpt@example.com",
                      "non_transactional": true,
                      "type": "non_transactional",
                      "source": "Manually Added",
                      "description": "User requested to not receive any non-transactional emails.",
                      "created": "2015-01-01T12:00:00+00:00",
                      "updated": "2015-01-01T12:00:00+00:00"
                    },
                    {
                      "recipient": "rcpt@example.com",
                      "non_transactional": true,
                      "type": "non_transactional",
                      "source": "Bounce Rule",
                      "description": "550: 550 - Domain has been disabled. #7",
                      "created": "2016-10-01T12:00:00+00:00",
                      "updated": "2016-10-01T12:00:00+00:00",
                      "subaccount_id": "146"
                    }
                  ],
                  "links": [],
                  "total_count": 2
                }
                """;

            var response = JsonSerializer.Deserialize<RetrieveSuppressionResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.TotalCount.Should().Be(2);
            response.Results.Count.Should().Be(2);
        }

        [Fact]
        public void SearchSuppressions_response_returns_expected_result()
        {
            var json = 
                """
                {
                  "results": [
                    {
                      "recipient": "test@example.com",
                      "source": "Bounce Rule",
                      "type": "transactional",
                      "created": "2017-02-01T01:01:01+00:00",
                      "updated": "2017-02-01T01:01:01+00:00",
                      "transactional": true
                    },
                    {
                      "recipient": "test2@example.com",
                      "description": "550: this email address does not exist #55",
                      "source": "Manually Added",
                      "type": "transactional",
                      "created": "2018-01-01T01:01:01+00:00",
                      "updated": "2018-01-01T01:01:01+00:00",
                      "non_transactional": true
                    },
                    {
                      "recipient": "test3@example.com",
                      "description": "Recipient unsubscribed",
                      "source": "Bounce Rule",
                      "type": "transactional",
                      "created": "2018-01-01T01:01:01+00:00",
                      "updated": "2018-01-01T01:01:01+00:00",
                      "transactional": true
                    }
                  ],
                  "links": [],
                  "total_count": 3
                }
                """;

            var response = JsonSerializer.Deserialize<SearchSuppressionsResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.TotalCount.Should().Be(3);
            response.Results.Count.Should().Be(3);
        }

        [Fact]
        public void RetrieveSuppressionSummary_response_returns_expected_result()
        {
            var json =
                """
                {
                  "results": {
                    "compliance": 1,
                    "manually_added": 1542,
                    "unsubscribe_link": 1,
                    "bounce_rule": 3891,
                    "list_unsubscribe": 1,
                    "spam_complaint": 1,
                    "total": 5437
                  }
                }
                """;

            var response = JsonSerializer.Deserialize<RetrieveSuppressionSummaryResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.Compliance.Should().Be(1);
            response.Results.Total.Should().Be(5437);
        }
    }
}