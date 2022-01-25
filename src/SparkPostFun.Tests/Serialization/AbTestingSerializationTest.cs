using System;
using System.Collections.Generic;
using System.Text.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using SparkPostFun.Infrastructure;
using SparkPostFun.Sending;
using Xunit;

namespace SparkPostFun.Tests.Serialization;

public class AbTestingSerializationTest
{
    [Fact]
    public void CancelAbTest_response_returns_expected_result()
    {
        var json = "{                  " +
                   "  \"results\": {   " +
                   "    \"status\": \"cancelled\" " +
                   "  }                " +
                   "}                  ";

        var response = JsonSerializer.Deserialize<CancelAbTestResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        response.Results.Status.Should().Be("cancelled");
    }

    [Fact]
    public void CreateAbTest_request_returns_expected_result()
    {
        var defaultTemplate = new AbTestingTemplate("default_payment_confirmation_template") { Percent = 50 };
        var variant1 = new AbTestingTemplate("payment_confirmation_variant1") { Percent = 25 };
        var variant2 = new AbTestingTemplate("payment_confirmation_variant2") { Percent = 25 };
        var request = new CreateAbTest(
            "Payment Confirmation",
            defaultTemplate,
            new List<AbTestingTemplate> { variant1, variant2 },
            Metric.CountUniqueConfirmedOpened,
            AudienceSelection.Percent,
            TestMode.Bayesian,
            new DateTimeOffset(2018, 4, 3, 22, 8, 33, TimeSpan.Zero)
        )
        {
            Id = "payment-confirmation",
            ConfidenceLevel = 0.99f
        };

        var json = JsonSerializer.Serialize(request, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        /* expected
            {
              "id": "payment-confirmation",
              "name": "Payment Confirmation",
              "metric": "count_unique_confirmed_opened",
              "audience_selection": "percent",
              "start_time": "2018-04-03T22:08:33Z",
              "test_mode": "bayesian",
              "confidence_level": 0.99,
              "default_template": {
                "template_id": "default_payment_confirmation_template",
                "percent": 50
              },
              "variants": [
                {
                  "template_id": "payment_confirmation_variant1",
                  "percent": 25
                },
                {
                  "template_id": "payment_confirmation_variant2",
                  "percent": 25
                }
              ]
            }
        */

        var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        obj.GetProperty("id").GetString().Should().Be("payment-confirmation");
        obj.GetProperty("name").GetString().Should().Be("Payment Confirmation");
        obj.GetProperty("metric").GetString().Should().Be("count_unique_confirmed_opened");
        obj.GetProperty("audience_selection").GetString().Should().Be("percent");
        obj.GetProperty("start_time").GetDateTimeOffset().Should().Be(new DateTimeOffset(2018, 4, 3, 22, 8, 22, TimeSpan.Zero));
        obj.GetProperty("test_mode").GetString().Should().Be("bayesian");
        obj.GetProperty("confidence_level").GetDouble().Should().Be(0.99);

        obj.GetProperty("default_template").GetProperty("template_id").GetString().Should().Be("default_payment_confirmation_template");
        obj.GetProperty("default_template").GetProperty("percent").GetInt32().Should().Be(50);

        obj.GetProperty("variants")[0].GetProperty("template_id").GetString().Should().Be("payment_confirmation_variant1");
        obj.GetProperty("variants")[0].GetProperty("percent").GetInt32().Should().Be(25);
        obj.GetProperty("variants")[1].GetProperty("template_id").GetString().Should().Be("payment_confirmation_variant2");
        obj.GetProperty("variants")[1].GetProperty("percent").GetInt32().Should().Be(25);
    }

    [Fact]
    public void CreateAbTest_response_returns_expected_result()
    {
        var json = "{                                    " +
                   "  \"results\": {                     " +
                   "    \"id\": \"payment-confirmation\" " +
                   "  }                                  " +
                   "}                                    ";

        var response = JsonSerializer.Deserialize<CreateAbTestResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        response!.Results.Id.Should().Be("payment-confirmation");
    }

    [Fact]
    public void CreateAbTest1_request_returns_expected_result()
    {
        var defaultTemplate = new AbTestingTemplate("default_payment_confirmation_template") { SampleSize = 40000 };
        var variant1 = new AbTestingTemplate("payment_confirmation_variant1") { SampleSize = 10000 };
        var variant2 = new AbTestingTemplate("payment_confirmation_variant2") { SampleSize = 10000 };
        var request = new CreateAbTest(
            "Payment Confirmation",
            defaultTemplate,
            new List<AbTestingTemplate> { variant1, variant2 },
            Metric.CountUniqueConfirmedOpened,
            AudienceSelection.SampleSize,
            TestMode.Learning,
            new DateTimeOffset(2018, 4, 3, 22, 8, 33, TimeSpan.Zero)
        )
        {
            Id = "payment-confirmation",
            TotalSampleSize = 60000
        };

        var json = JsonSerializer.Serialize(request, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        /* expected
            {
              "id": "payment-confirmation",
              "name": "Payment Confirmation",
              "metric": "count_unique_confirmed_opened",
              "audience_selection": "sample_size",
              "start_time": "2018-04-03T22:08:33+00:00",
              "test_mode": "learning",
              "total_sample_size": 60000,
              "default_template": {
                "template_id": "default_payment_confirmation_template",
                "sample_size": 40000
              },
              "variants": [
                {
                  "template_id": "payment_confirmation_variant1",
                  "sample_size": 10000
                },
                {
                  "template_id": "payment_confirmation_variant2",
                  "sample_size": 10000
                }
              ]
            }
        */

        var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        obj.GetProperty("id").GetString().Should().Be("payment-confirmation");
        obj.GetProperty("name").GetString().Should().Be("Payment Confirmation");
        obj.GetProperty("metric").GetString().Should().Be("count_unique_confirmed_opened");
        obj.GetProperty("audience_selection").GetString().Should().Be("sample_size");
        obj.GetProperty("start_time").GetDateTimeOffset().Should().Be(new DateTimeOffset(2018, 4, 3, 22, 8, 33, TimeSpan.Zero));
        obj.GetProperty("test_mode").GetString().Should().Be("learning");
        obj.GetProperty("total_sample_size").GetInt32().Should().Be(60000);

        obj.GetProperty("default_template").GetProperty("template_id").GetString().Should().Be("default_payment_confirmation_template");
        obj.GetProperty("default_template").GetProperty("sample_size").GetInt32().Should().Be(40000);

        obj.GetProperty("variants")[0].GetProperty("template_id").GetString().Should().Be("payment_confirmation_variant1");
        obj.GetProperty("variants")[0].GetProperty("sample_size").GetInt32().Should().Be(10000);
        obj.GetProperty("variants")[1].GetProperty("template_id").GetString().Should().Be("payment_confirmation_variant2");
        obj.GetProperty("variants")[1].GetProperty("sample_size").GetInt32().Should().Be(10000);
    }

    [Fact]
    public void CreateAbTestDraft_request_returns_expected_result()
    {
        var defaultTemplate = new AbTestingTemplate("default_payment_confirmation_template") { Percent = 50 };
        var request = new CreateAbTestDraft(
            "Payment Confirmation",
            defaultTemplate)
        {
            Id = "payment-confirmation"
        };

        var json = JsonSerializer.Serialize(request, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        /* expected
            {
              "id": "payment-confirmation",
              "name": "Payment Confirmation",
              "default_template": {
                "template_id": "default_payment_confirmation_template",
                "percent": 50
              }
            }
        */

        var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        obj.GetProperty("id").GetString().Should().Be("payment-confirmation");
        obj.GetProperty("name").GetString().Should().Be("Payment Confirmation");

        obj.GetProperty("default_template").GetProperty("template_id").GetString().Should().Be("default_payment_confirmation_template");
        obj.GetProperty("default_template").GetProperty("percent").GetInt32().Should().Be(50);
    }

    [Fact]
    public void CreateAbTestDraft_response_returns_expected_result()
    {
        var json = "{                                    " +
                   "  \"results\": {                     " +
                   "    \"id\": \"payment-confirmation\" " +
                   "  }                                  " +
                   "}                                    ";

        var response = JsonSerializer.Deserialize<CreateAbTestDraftResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        response.Results.Id.Should().Be("payment-confirmation");
    }

    [Fact]
    public void ListAbTests_response_returns_expected_result()
    {
        var json = "{                                                                   " +
                   "  \"results\": [                                                    " +
                   "    {                                                               " +
                   "      \"id\": \"payment-confirmation\",                             " +
                   "      \"name\": \"Payment Confirmation\",                           " +
                   "      \"version\": 2,                                               " +
                   "      \"status\": \"running\",                                      " +
                   "      \"metric\": \"count_unique_confirmed_opened\",                " +
                   "      \"audience_selection\": \"percent\",                          " +
                   "      \"start_time\": \"2018-04-03T22:08:33+00:00\",                " +
                   "      \"test_mode\": \"bayesian\",                                  " +
                   "      \"confidence_level\": 0.99,                                   " +
                   "      \"engagement_timeout\": 24,                                   " +
                   "      \"default_template\": {                                       " +
                   "        \"template_id\": \"default_payment_confirmation_template\", " +
                   "        \"percent\": 60,                                            " +
                   "        \"count_unique_confirmed_opened\": 1000,                    " +
                   "        \"count_accepted\": 100000,                                 " +
                   "        \"engagement_rate\": 0.01                                   " +
                   "      },                                                            " +
                   "      \"variants\": [                                               " +
                   "        {                                                           " +
                   "          \"template_id\": \"payment_confirmation_variant1\",       " +
                   "          \"percent\": 10,                                          " +
                   "          \"count_unique_confirmed_opened\": 489,                   " +
                   "          \"count_accepted\": 9000,                                 " +
                   "          \"engagement_rate\": 0.054333                             " +
                   "        },                                                          " +
                   "        {                                                           " +
                   "          \"template_id\": \"payment_confirmation_variant2\",       " +
                   "          \"percent\": 30,                                          " +
                   "          \"count_unique_confirmed_opened\": 320,                   " +
                   "          \"count_accepted\": 68933,                                " +
                   "          \"engagement_rate\": 0.004642                             " +
                   "        }                                                           " +
                   "      ],                                                            " +
                   "      \"created_at\": \"2018-04-02T22:08:33+00:00\",                " +
                   "      \"updated_at\": \"2018-04-02T22:08:33+00:00\"                 " +
                   "    },                                                              " +
                   "    {                                                               " +
                   "      \"id\": \"password-reset\",                                   " +
                   "      \"name\": \"Password Reset\",                                 " +
                   "      \"version\": 2,                                               " +
                   "      \"status\": \"completed\",                                    " +
                   "      \"winning_template_id\": \"password_reset_variant2\",         " +
                   "      \"metric\": \"count_unique_clicked\",                         " +
                   "      \"audience_selection\": \"percent\",                          " +
                   "      \"start_time\": \"2018-04-03T22:08:33+00:00\",                " +
                   "      \"test_mode\": \"bayesian\",                                  " +
                   "      \"confidence_level\": 0.99,                                   " +
                   "      \"engagement_timeout\": 24,                                   " +
                   "      \"default_template\": {                                       " +
                   "        \"template_id\": \"default_password_reset_template\",       " +
                   "        \"percent\": 70,                                            " +
                   "        \"count_unique_clicked\": 8909,                             " +
                   "        \"count_accepted\": 3423230,                                " +
                   "        \"engagement_rate\": 0.002602                               " +
                   "      },                                                            " +
                   "      \"variants\": [                                               " +
                   "        {                                                           " +
                   "          \"template_id\": \"password_reset_variant1\",             " +
                   "          \"percent\": 15,                                          " +
                   "          \"count_unique_clicked\": 398,                            " +
                   "          \"count_accepted\": 90302,                                " +
                   "          \"engagement_rate\": 0.004407                             " +
                   "        },                                                          " +
                   "        {                                                           " +
                   "          \"template_id\": \"password_reset_variant2\",             " +
                   "          \"percent\": 15,                                          " +
                   "          \"count_unique_clicked\": 231,                            " +
                   "          \"count_accepted\": 73039,                                " +
                   "          \"engagement_rate\": 0.003162                             " +
                   "        }                                                           " +
                   "      ],                                                            " +
                   "      \"created_at\": \"2018-04-02T22:08:33+00:00\",                " +
                   "      \"updated_at\": \"2018-04-02T22:08:33+00:00\"                 " +
                   "    }                                                               " +
                   "  ]                                                                 " +
                   "}                                                                   ";

        var response = JsonSerializer.Deserialize<ListAbTestsResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        response.Results.Count.Should().Be(2);
    }

    [Fact]
    public void RetrieveAbTest_response_returns_expected_result()
    {
        var json = "{                                                           " +
                   "  \"results\": {                                            " +
                   "    \"id\": \"password-reset\",                             " +
                   "    \"name\": \"Password Reset\",                           " +
                   "    \"version\": 2,                                         " +
                   "    \"status\": \"scheduled\",                              " +
                   "    \"metric\": \"count_unique_confirmed_opened\",          " +
                   "    \"audience_selection\": \"sample_size\",                " +
                   "    \"start_time\": \"2018-04-03T22:08:33+00:00\",          " +
                   "    \"test_mode\": \"bayesian\",                            " +
                   "    \"confidence_level\": 0.99,                             " +
                   "    \"total_sample_size\": 60000,                           " +
                   "    \"engagement_timeout\": 24,                             " +
                   "    \"default_template\": {                                 " +
                   "      \"template_id\": \"default_password_reset_template\", " +
                   "      \"sample_size\": 20000,                               " +
                   "      \"count_unique_confirmed_opened\": 1398,              " +
                   "      \"count_accepted\": 20321,                            " +
                   "      \"engagement_rate\": 0.068795                         " +
                   "    },                                                      " +
                   "    \"variants\": [                                         " +
                   "      {                                                     " +
                   "        \"template_id\": \"password_reset_variant1\",       " +
                   "        \"sample_size\": 20000,                             " +
                   "        \"count_unique_confirmed_opened\": 343,             " +
                   "        \"count_accepted\": 18908,                          " +
                   "        \"engagement_rate\": 0.01814                        " +
                   "      },                                                    " +
                   "      {                                                     " +
                   "        \"template_id\": \"password_reset_variant2\",       " +
                   "        \"sample_size\": 20000,                             " +
                   "        \"count_unique_confirmed_opened\": 890,             " +
                   "        \"count_accepted\": 22987,                          " +
                   "        \"engagement_rate\": 0.038717                       " +
                   "      }                                                     " +
                   "    ],                                                      " +
                   "    \"created_at\": \"2018-04-02T22:08:33+00:00\",          " +
                   "    \"updated_at\": \"2018-04-02T22:08:33+00:00\"           " +
                   "  }                                                         " +
                   "}                                                           ";

        var response = JsonSerializer.Deserialize<RetrieveAbTestResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        response.Results.Id.Should().Be("password-reset");
    }

    [Fact]
    public void RetrieveAbTestDraft_response_returns_expected_result()
    {
        var json = "{                                                 " +
                   "  \"results\": {                                  " +
                   "    \"id\": \"my-draft-test\",                    " +
                   "    \"name\": \"my draft\",                       " +
                   "    \"version\": 1,                               " +
                   "    \"status\": \"draft\",                        " +
                   "    \"default_template\": {                       " +
                   "      \"template_id\": \"my-test-temp\",          " +
                   "      \"percent\": 50                             " +
                   "    },                                            " +
                   "    \"created_at\": \"2018-07-10T21:55:34.960Z\", " +
                   "    \"updated_at\": \"2018-07-11T21:55:47.176Z\"  " +
                   "  }                                               " +
                   "}                                                 ";

        var response = JsonSerializer.Deserialize<RetrieveAbTestDraftResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        response.Results.Id.Should().Be("my-draft-test");
    }

    [Fact]
    public void ScheduleAbTestDraft_request_returns_expected_result()
    {
        var request = new ScheduleAbTestDraft(new DateTimeOffset(2018, 4, 3, 22, 8, 33, TimeSpan.Zero))
        {
            EndTime = new DateTimeOffset(2018, 4, 15, 22, 8, 33, TimeSpan.Zero),
            EngagementTimeout = 4
        };

        var json = JsonSerializer.Serialize(request, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        /* expected
            {
              "start_time": "2018-04-03T22:08:33+00:00",
              "end_time": "2018-04-15T22:08:33+00:00",
              "engagement_timeout": 4
            }
        */

        var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        obj.GetProperty("start_time").GetDateTimeOffset().Should().Be(new DateTimeOffset(2018, 4, 3, 22, 8, 33, TimeSpan.Zero));
        obj.GetProperty("end_time").GetDateTimeOffset().Should().Be(new DateTimeOffset(2018, 4, 15, 22, 8, 33, TimeSpan.Zero));
        obj.GetProperty("engagement_timeout").GetInt32().Should().Be(4);
    }

    [Fact]
    public void ScheduleAbTestDraft_response_returns_expected_result()
    {
        var json = "{                                    " +
                   "  \"results\": {                     " +
                   "    \"id\": \"payment-confirmation\" " +
                   "  }                                  " +
                   "}                                    ";

        var response = JsonSerializer.Deserialize<ScheduleAbTestDraftResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        response.Results.Id.Should().Be("payment-confirmation");
    }

    [Fact]
    public void UpdateAbTest_request_returns_expected_result()
    {
        var request = new UpdateAbTest
        {
            TotalSampleSize = 100000,
            DefaultTemplate = new AbTestingTemplate("default_password_reset_template") { SampleSize = 70000 },
            Variants = new List<AbTestingTemplate>
            {
                new AbTestingTemplate("password_reset_variant1") { SampleSize = 10000 },
                new AbTestingTemplate("password_reset_variant2") { SampleSize = 20000 }
            }
        };

        var json = JsonSerializer.Serialize(request, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        /* expected
            {
              "total_sample_size": 100000,
              "default_template": {
                "template_id": "default_password_reset_template",
                "sample_size": 70000
              },
              "variants": [
                {
                  "template_id": "password_reset_variant1",
                  "sample_size": 10000
                },
                {
                  "template_id": "password_reset_variant2",
                  "sample_size": 20000
                }
              ]
            }
        */

        var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        obj.GetProperty("total_sample_size").GetInt32().Should().Be(100000);

        obj.GetProperty("default_template").GetProperty("template_id").GetString().Should().Be("default_password_reset_template");
        obj.GetProperty("default_template").GetProperty("sample_size").GetInt32().Should().Be(70000);

        obj.GetProperty("variants")[0].GetProperty("template_id").GetString().Should().Be("password_reset_variant1");
        obj.GetProperty("variants")[0].GetProperty("sample_size").GetInt32().Should().Be(10000);
        obj.GetProperty("variants")[1].GetProperty("template_id").GetString().Should().Be("password_reset_variant2");
        obj.GetProperty("variants")[1].GetProperty("sample_size").GetInt32().Should().Be(20000);
    }

    [Fact]
    public void UpdateAbTest_response_returns_expected_result()
    {
        var json = "{                  " +
                   "  \"results\": {   " +
                   "    \"version\": 2 " +
                   "  }                " +
                   "}                  ";

        var response = JsonSerializer.Deserialize<UpdateAbTestResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        response.Results.Version.Should().Be(2);
    }

    [Fact]
    public void UpdateAbTestDraft_request_returns_expected_result()
    {
        var request = new UpdateAbTest
        {
            Metric = Metric.CountUniqueConfirmedOpened,
            AudienceSelection = AudienceSelection.Percent,
            TestMode = TestMode.Bayesian,
            ConfidenceLevel = 0.99f,
            Variants = new List<AbTestingTemplate>
            {
                new AbTestingTemplate("payment_confirmation_variant1") { Percent = 25 },
                new AbTestingTemplate("payment_confirmation_variant2") { Percent = 25 },
            }
        };

        var json = JsonSerializer.Serialize(request, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        /* expected
            {
              "metric": "count_unique_confirmed_opened",
              "audience_selection": "percent",
              "test_mode": "bayesian",
              "confidence_level": 0.99,
              "variants": [
                {
                  "template_id": "payment_confirmation_variant1",
                  "percent": 25
                },
                {
                  "template_id": "payment_confirmation_variant2",
                  "percent": 25
                }
              ]
            }
        */

        var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        obj.GetProperty("metric").GetString().Should().Be("count_unique_confirmed_opened");
        obj.GetProperty("audience_selection").GetString().Should().Be("percent");
        obj.GetProperty("test_mode").GetString().Should().Be("bayesian");
        obj.GetProperty("confidence_level").GetDouble().Should().Be(0.99);

        obj.GetProperty("variants")[0].GetProperty("template_id").GetString().Should().Be("payment_confirmation_variant1");
        obj.GetProperty("variants")[0].GetProperty("percent").GetInt32().Should().Be(25);
        obj.GetProperty("variants")[1].GetProperty("template_id").GetString().Should().Be("payment_confirmation_variant2");
        obj.GetProperty("variants")[1].GetProperty("percent").GetInt32().Should().Be(25);
    }

    [Fact]
    public void UpdateAbTestDraft_response_returns_expected_result()
    {
        var json = "{                                    " +
                   "  \"results\": {                     " +
                   "    \"id\": \"payment-confirmation\" " +
                   "  }                                  " +
                   "}                                    ";

        var response = JsonSerializer.Deserialize<UpdateAbTestDraftResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        response.Results.Id.Should().Be("payment-confirmation");
    }
}