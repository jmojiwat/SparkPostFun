using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using SparkPostFun.Infrastructure;
using SparkPostFun.Sending;
using Xunit;

namespace SparkPostFun.Tests.Serialization;

public class TransmissionSerializationTest
{
    [Fact]
    public void DocumentationExample1_returns_expected_result()
    {
        var recipients = new List<Recipient>
        {
            new() {
                Address = new Address
                {
                    Email = "wilma@flintstone.com",
                    Name = "Wilma Flintstone"
                },
                Tags = new List<string> { "prehistoric" },
                Metadata = new Dictionary<string, object>
                {
                    { "age", "24" },
                    { "place", "Bedrock" }
                },
                SubstitutionData = new Dictionary<string, object>
                {
                    { "customer_type", "Platinum" },
                    { "year", "Freshman" }
                }
            }
        };

        var transmission = TransmissionExtensions.CreateTransmission()
            .WithOptions(new TransmissionOptions
            {
                ClickTracking = false,
                Transactional = true,
                IpPool = "my_ip_pool",
                InlineCss = true
            })
            .WithDescription("Christmas Campaign Email")
            .WithCampaignId("christmas_campaign")
            .WithMetadata(new Dictionary<string, object>
            {
                { "user_type", "students" },
                { "education_level", "college" }
            })
            .WithSubstitutionData(new Dictionary<string, object>
            {
                { "sender", "Big Store Team" },
                { "holiday_name", "Christmas" }
            })
            .WithRecipients(recipients);


        var json = JsonSerializer.Serialize(transmission,
            JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        json.Should().Contain("\"user_type\": \"students\"");
        json.Should().Contain("\"education_level\": \"college\"");
        json.Should().Contain("\"sender\": \"Big Store Team\"");
        json.Should().Contain("\"holiday_name\": \"Christmas\"");
    }

    [Fact]
    public void DocumentationExample2_returns_expected_result()
    {
        var transmission = TransmissionExtensions.CreateTransmission()
            .WithContent(new TransmissionInlineContent
            {
                From = new SenderAddress { Name = "Our Store", Email = "deals@example.com" },
                Subject = "Big Christmas savings!",
                Text = "Hi {{name}} \nSave big this Christmas in your area {{place}}! \nClick http://www.mysite.com and get huge discount\n Hurry, this offer is only to {{user_type}}\n {{sender}}",
                Html = "<p>Hi {{name}} \nSave big this Christmas in your area {{place}}! \nClick http://www.mysite.com and get huge discount\n</p><p>Hurry, this offer is only to {{user_type}}\n</p><p>{{sender}}</p>"
            })
            .WithStoredRecipientList(new StoredRecipientList { ListId = "christmas_sales_2013" });


        var json = JsonSerializer.Serialize(transmission,
            JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        json.Should().Contain("list_id");
        json.Should().Contain("christmas_sales_2013");
    }

    [Fact]
    public void SendInlineContent_response_returns_expected_result()
    {
        var json = "{                                     " +
                   "  \"results\": {                      " +
                   "    \"total_rejected_recipients\": 0, " +
                   "    \"total_accepted_recipients\": 1, " +
                   "    \"id\": \"11668787484950529\"     " +
                   "  }                                   " +
                   "}                                     ";

        var response = JsonSerializer.Deserialize<CreateTransmissionResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        response.Results.TotalRejectedRecipients.Should().Be(0);
        response.Results.TotalAcceptedRecipients.Should().Be(1);
        response.Results.Id.Should().Be("11668787484950529");
    }

    [Fact]
    public void SendTemplateContent_response_returns_expected_result()
    {
        var json = "{                                                                          " +
                   "  \"errors\": [                                                            " +
                   "    {                                                                      " +
                   "      \"message\": \"transmission created, but with validation errors\",   " +
                   "      \"code\": \"2000\"                                                   " +
                   "    }                                                                      " +
                   "  ],                                                                       " +
                   "  \"results\": {                                                           " +
                   "    \"rcpt_to_errors\": [                                                  " +
                   "      {                                                                    " +
                   "        \"message\": \"required field is missing\",                        " +
                   "        \"description\": \"address.email is required for each recipient\", " +
                   "        \"code\": \"1400\"                                                 " +
                   "      }                                                                    " +
                   "    ],                                                                     " +
                   "    \"total_rejected_recipients\": 1,                                      " +
                   "    \"total_accepted_recipients\": 1,                                      " +
                   "    \"id\": \"11668787484950530\"                                          " +
                   "  }                                                                        " +
                   "}                                                                          ";

        var response = JsonSerializer.Deserialize<CreateTransmissionResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        response.Errors.First().Message.Should().Be("transmission created, but with validation errors");
        response.Errors.First().Code.Should().Be("2000");

        response.Results.RecipientToErrors.First().Message.Should().Be("required field is missing");
        response.Results.RecipientToErrors.First().Description.Should().Be("address.email is required for each recipient");
        response.Results.RecipientToErrors.First().Code.Should().Be("1400");
        response.Results.TotalRejectedRecipients.Should().Be(1);
        response.Results.TotalAcceptedRecipients.Should().Be(1);
        response.Results.Id.Should().Be("11668787484950530");
    }

    [Fact]
    public void SendAbTestContent_response_returns_expected_result()
    {
        var json = "{                                     " +
                   "  \"results\": {                      " +
                   "    \"total_rejected_recipients\": 0, " +
                   "    \"total_accepted_recipients\": 1, " +
                   "    \"id\": \"11668787493850529\"     " +
                   "  }                                   " +
                   "}                                     ";

        var response = JsonSerializer.Deserialize<CreateTransmissionResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        response.Results.TotalRejectedRecipients.Should().Be(0);
        response.Results.TotalAcceptedRecipients.Should().Be(1);
        response.Results.Id.Should().Be("11668787493850529");
    }

    [Fact]
    public void SendRfc822Content_response_returns_expected_result()
    {
        var json = "{                                     " +
                   "  \"results\": {                      " +
                   "    \"total_rejected_recipients\": 0, " +
                   "    \"total_accepted_recipients\": 1, " +
                   "    \"id\": \"11668787493850529\"     " +
                   "  }                                   " +
                   "}                                     ";

        var response = JsonSerializer.Deserialize<CreateTransmissionResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        response.Results.TotalRejectedRecipients.Should().Be(0);
        response.Results.TotalAcceptedRecipients.Should().Be(1);
        response.Results.Id.Should().Be("11668787493850529");
    }

    [Fact]
    public void ScheduleTransmission_response_returns_expected_result()
    {
        var json = "{                                        " +
                   "  \"results\": {                         " +
                   "    \"total_rejected_recipients\": 1000, " +
                   "    \"total_accepted_recipients\": 0,    " +
                   "    \"id\": \"11668787493850529\"        " +
                   "  }                                      " +
                   "}                                        ";

        var response = JsonSerializer.Deserialize<CreateTransmissionResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        response.Results.TotalRejectedRecipients.Should().Be(1000);
        response.Results.TotalAcceptedRecipients.Should().Be(0);
        response.Results.Id.Should().Be("11668787493850529");
    }

    [Fact]
    public void ParseTransmission_with_cc_request_returns_expected_result()
    {
        var recipients = new List<Recipient>
        {
            new() {
                Address = new()
                {
                    Email = "to1@gmail.com",
                    Name = "To Gmail"
                }
            },
            new() {
                Address = new()
                {
                    Email = "to2@gmail.com",
                    Name = "To Gmail"
                }
            },
            new()
            {
                Address = new()
                {
                    Email = "cc1@gmail.com",
                    Name = "Cc Gmail",
                },
                Type = RecipientType.Cc
            },
            new()
            {
                Address = new()
                {
                    Email = "cc2@gmail.com",
                    Name = "Cc Gmail",
                },
                Type = RecipientType.Cc
            }
        };

        var transmission = TransmissionExtensions.CreateTransmission()
            .WithContent(new TransmissionInlineContent
            {
                From = new SenderAddress
                {
                    Email = "from@gmail.com",
                    Name = "From Gmail"
                }
            })
            .WithRecipients(recipients);

        var parsedTransmission = TransmissionExtensions.ParseTransmission(transmission);

        var json = JsonSerializer.Serialize(parsedTransmission,
            JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        json.Should().Contain("\"header_to\": \"to1@gmail.com\"");
    }

    [Fact]
    public void ParseTransmission_with_bcc_request_returns_expected_result()
    {
        var recipients = new List<Recipient>
        {
            new() {
                Address = new()
                {
                    Email = "to@gmail.com",
                    Name = "To Gmail"
                }
            },
            new()
            {
                Address = new()
                {
                    Email = "bcc@gmail.com",
                    Name = "Bcc Gmail",
                },
                Type = RecipientType.Bcc
            }
        };

        var transmission = TransmissionExtensions.CreateTransmission()
            .WithContent(new TransmissionInlineContent
            {
                From = new SenderAddress
                {
                    Email = "from@gmail.com",
                    Name = "From Gmail"
                }
            })
            .WithRecipients(recipients);

        var parsedTransmission = TransmissionExtensions.ParseTransmission(transmission);

        var json = JsonSerializer.Serialize(parsedTransmission,
            JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        json.Should().Contain("\"header_to\": \"to@gmail.com\"");
    }
}