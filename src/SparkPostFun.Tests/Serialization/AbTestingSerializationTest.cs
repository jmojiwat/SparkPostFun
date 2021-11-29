using System.Text.Json;
using FluentAssertions;
using SparkPostFun.Infrastructure;
using SparkPostFun.Sending;
using Xunit;

namespace SparkPostFun.Tests.Serialization
{
    public class AbTestingSerializationTest
    {
        [Fact]
        public void CreateAbTest_response_returns_expected_result()
        {
            var json = "{                                    " +
                       "  \"results\": {                     " +
                       "    \"id\": \"payment-confirmation\" " +
                       "  }                                  " +
                       "}                                    ";

            var response = JsonSerializer.Deserialize<CreateAbTestResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.Id.Should().Be("payment-confirmation");
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

            var response = JsonSerializer.Deserialize<ListAbTestResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.Count.Should().Be(2);
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

    }
}