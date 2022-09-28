using System.Text.Json;
using FluentAssertions;
using SparkPostFun.Infrastructure;
using SparkPostFun.Sending;
using Xunit;

namespace SparkPostFun.Tests.Serialization
{
    public class RecipientValidationSerializationTest
    {
        [Fact]
        public void EmailAddressValidation_response_returns_expected_result()
        {
            const string json = "{                                      " +
                                "      \"results\": {                   " +
                                "          \"result\": \"valid\",       " +
                                "          \"valid\": true,             " +
                                "          \"is_role\": false,          " +
                                "          \"is_disposable\": false,    " +
                                "          \"delivery_confidence\": 85, " +
                                "          \"is_free\": true            " +
                                "      }                                " +
                                "}                                      ";

            var response = JsonSerializer.Deserialize<EmailAddressValidationResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            response.Results.Result.Should().Be(RecipientValidationResult.Valid);
        }
    }
}