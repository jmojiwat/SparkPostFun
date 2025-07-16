using System.Text.Json;
using FluentAssertions;
using SparkPostFun.Infrastructure;
using SparkPostFun.Sending;
using Xunit;

namespace SparkPostFun.Tests.Serialization;

public class RecipientValidationSerializationTest
{
    [Fact]
    public void EmailAddressValidation_response_returns_expected_result()
    {
        const string json =
            """
            {
                "results": {
                    "result": "valid",
                    "valid": true,
                    "is_role": false,
                    "is_disposable": false,
                    "delivery_confidence": 85,
                    "is_free": true
                }
            }
            """;

        var response = JsonSerializer.Deserialize<EmailAddressValidationResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        response.Results.Result.Should().Be(RecipientValidationResult.Valid);
    }
}


/*
public bool Valid { get; init; }
public RecipientValidationResult? Result { get; init; }
public int DeliveryConfidence { get; init; }
public RecipientValidationReason? Reason { get; init; }
public bool IsRole { get; init; }
public bool IsDisposable { get; init; }
public bool IsFree { get; init; }
public string DidYouMean { get; init; }
*/
