using System.Text.Json;
using FluentAssertions;
using LanguageExt;
using SparkPostFun.Infrastructure;
using SparkPostFun.Sending;
using Xunit;

namespace SparkPostFun.Tests.Serialization
{
    public class SnippetSerializationTest
    {
        [Fact]
        public void CreateSnippet_response_returns_expected_result()
        {
            var json = "{                      " +
                       "  \"results\": {       " +
                       "    \"id\": \"header\" " +
                       "  }                    " +
                       "}                      ";

            var response = JsonSerializer.Deserialize<CreateSnippetResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.Id.Should().Be("header");
        }

        [Fact]
        public void RetrieveSnippet_response_returns_expected_result()
        {
            var json = "{                                                  " +
                       "  \"results\": {                                   " +
                       "    \"id\": \"ourfooter\",                         " +
                       "    \"name\": \"Footer\",                          " +
                       "    \"content\": {                                 " +
                       "      \"html\": \"<b>Our standard footer</b>\",    " +
                       "      \"text\": \"Our standard footer\",           " +
                       "      \"amp_html\": \"<b>Our standard footer</b>\" " +
                       "    },                                             " +
                       "    \"created_at\": \"2018-10-11T19:13:29.548Z\",  " +
                       "    \"updated_at\": \"2018-10-11T19:14:50.181Z\",  " +
                       "    \"subaccount_id\": 273                         " +
                       "  }                                                " +
                       "}                                                  ";

            var response = JsonSerializer.Deserialize<RetrieveSnippetResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.Id.Should().Be("ourfooter");
        }

        [Fact]
        public void UpdateSnippet_response_returns_expected_result()
        {
            var json = "{ }";

            var response = JsonSerializer.Deserialize<Unit>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        }

        [Fact]
        public void ListSnippets_response_returns_expected_result()
        {
            var json = "{                                                   " +
                       "  \"results\": [                                    " +
                       "    {                                               " +
                       "      \"id\": \"header\",                           " +
                       "      \"name\": \"Header\",                         " +
                       "      \"shared_with_subaccount\": false,            " +
                       "      \"created_at\": \"2018-10-11T19:13:29.548Z\", " +
                       "      \"updated_at\": \"2018-10-11T19:14:50.181Z\"  " +
                       "    },                                              " +
                       "    {                                               " +
                       "      \"id\": \"footer\",                           " +
                       "      \"name\": \"Footer\",                         " +
                       "      \"shared_with_subaccount\": true,             " +
                       "      \"created_at\": \"2018-10-05T20:21:04.853Z\", " +
                       "      \"updated_at\": \"2018-10-09T19:23:53.022Z\"  " +
                       "    }                                               " +
                       "  ]                                                 " +
                       "}                                                   ";

            var response = JsonSerializer.Deserialize<ListSnippetsResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.Count.Should().Be(2);
        }
    }
}