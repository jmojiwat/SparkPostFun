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
        var address = new Address("wilma@flintstone.com") { Name = "Wilma Flintstone" };
        var recipients = new List<Recipient>
        {
            new(address) {
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

        var content = new InlineContent(new SenderAddress(string.Empty), string.Empty);
        var transmission = TransmissionExtensions.CreateTransmission(recipients, content)
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

        using var scope = new AssertionScope();
        json.Should().Contain("\"user_type\": \"students\"");
        json.Should().Contain("\"education_level\": \"college\"");
        json.Should().Contain("\"sender\": \"Big Store Team\"");
        json.Should().Contain("\"holiday_name\": \"Christmas\"");
    }

    [Fact]
    public void DocumentationExample2_returns_expected_result()
    {
        var sender = new SenderAddress("deals@example.com") { Name = "Our Store" };
        const string subject = "Big Christmas savings!";
        var content = new InlineContent(sender, subject)
        {
            Text = "Hi {{name}} \nSave big this Christmas in your area {{place}}! \nClick http://www.mysite.com and get huge discount\n Hurry, this offer is only to {{user_type}}\n {{sender}}",
            Html = "<p>Hi {{name}} \nSave big this Christmas in your area {{place}}! \nClick http://www.mysite.com and get huge discount\n</p><p>Hurry, this offer is only to {{user_type}}\n</p><p>{{sender}}</p>"
        };

        var storedRecipientList = new StoredRecipientList("christmas_sales_2013");
        
        var transmission = TransmissionExtensions.CreateTransmission(storedRecipientList, content);

        var json = JsonSerializer.Serialize(transmission,
            JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        json.Should().Contain("\"list_id\": \"christmas_sales_2013\"");
        json.Should().Contain("\"name\": \"Our Store\"");
        json.Should().Contain("\"email\": \"deals@example.com\"");
        json.Should().Contain("\"subject\": \"Big Christmas savings!\"");
//        json.Should().Contain("\"text\": \"Hi {{name}} \nSave big this Christmas in your area {{place}}! \nClick http://www.mysite.com and get huge discount\n Hurry, this offer is only to {{user_type}}\n {{sender}}\"");
//        json.Should().Contain("\"html\": \"<p>Hi {{name}} \nSave big this Christmas in your area {{place}}! \nClick http://www.mysite.com and get huge discount\n</p><p>Hurry, this offer is only to {{user_type}}\n</p><p>{{sender}}</p>\"");
    }

    [Fact]
    public void SendInlineContent_response_returns_expected_result()
    {
        const string json = "{                                     " +
                            "  \"results\": {                      " +
                            "    \"total_rejected_recipients\": 0, " +
                            "    \"total_accepted_recipients\": 1, " +
                            "    \"id\": \"11668787484950529\"     " +
                            "  }                                   " +
                            "}                                     ";

        var response = JsonSerializer.Deserialize<CreateTransmissionResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        response!.Results.TotalRejectedRecipients.Should().Be(0);
        response.Results.TotalAcceptedRecipients.Should().Be(1);
        response.Results.Id.Should().Be("11668787484950529");
    }

    [Fact]
    public void SendTemplateContent_response_returns_expected_result()
    {
        const string json = "{                                                                          " +
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

        using var scope = new AssertionScope();
        response!.Errors.First().Message.Should().Be("transmission created, but with validation errors");
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
        const string json = "{                                     " +
                            "  \"results\": {                      " +
                            "    \"total_rejected_recipients\": 0, " +
                            "    \"total_accepted_recipients\": 1, " +
                            "    \"id\": \"11668787493850529\"     " +
                            "  }                                   " +
                            "}                                     ";

        var response = JsonSerializer.Deserialize<CreateTransmissionResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        response!.Results.TotalRejectedRecipients.Should().Be(0);
        response.Results.TotalAcceptedRecipients.Should().Be(1);
        response.Results.Id.Should().Be("11668787493850529");
    }

    [Fact]
    public void SendRfc822Content_response_returns_expected_result()
    {
        const string json = "{                                     " +
                            "  \"results\": {                      " +
                            "    \"total_rejected_recipients\": 0, " +
                            "    \"total_accepted_recipients\": 1, " +
                            "    \"id\": \"11668787493850529\"     " +
                            "  }                                   " +
                            "}                                     ";

        var response = JsonSerializer.Deserialize<CreateTransmissionResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        response!.Results.TotalRejectedRecipients.Should().Be(0);
        response.Results.TotalAcceptedRecipients.Should().Be(1);
        response.Results.Id.Should().Be("11668787493850529");
    }

    [Fact]
    public void ScheduleTransmission_response_returns_expected_result()
    {
        const string json = "{                                        " +
                            "  \"results\": {                         " +
                            "    \"total_rejected_recipients\": 1000, " +
                            "    \"total_accepted_recipients\": 0,    " +
                            "    \"id\": \"11668787493850529\"        " +
                            "  }                                      " +
                            "}                                        ";

        var response = JsonSerializer.Deserialize<CreateTransmissionResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        response!.Results.TotalRejectedRecipients.Should().Be(1000);
        response.Results.TotalAcceptedRecipients.Should().Be(0);
        response.Results.Id.Should().Be("11668787493850529");
    }

    [Fact]
    public void ParseTransmission_with_cc_request_returns_expected_result()
    {
        var recipients = new List<Recipient>
        {
            new(new Address("to1@gmail.com") { Name = "To Gmail" }),
            new(new Address("to2@gmail.com") { Name = "To Gmail" }),
            new(new Address("cc1@gmail.com") { Name = "Cc Gmail" }) { Type = RecipientType.Cc },
            new(new Address("cc2@gmail.com") { Name = "Cc Gmail" }) { Type = RecipientType.Cc }
        };

        var sender = new SenderAddress("from@gmail.com") { Name = "From Gmail" };
        var content = new InlineContent(sender, string.Empty);
        var transmission = TransmissionExtensions.CreateTransmission(recipients, content);

        var parsedTransmission = TransmissionExtensions.ParseTransmission(transmission);

        var json = JsonSerializer.Serialize(parsedTransmission,
            JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        
        var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        obj.GetProperty("recipients")[0].GetProperty("address").GetProperty("email").GetString().Should().Be("to1@gmail.com");
        obj.GetProperty("recipients")[0].GetProperty("address").GetProperty("name").GetString().Should().Be("To Gmail");
        obj.GetProperty("recipients")[1].GetProperty("address").GetProperty("email").GetString().Should().Be("to2@gmail.com");
        obj.GetProperty("recipients")[1].GetProperty("address").GetProperty("name").GetString().Should().Be("To Gmail");
        obj.GetProperty("recipients")[2].GetProperty("address").GetProperty("email").GetString().Should().Be("cc1@gmail.com");
        obj.GetProperty("recipients")[2].GetProperty("address").GetProperty("name").GetString().Should().Be("Cc Gmail");
        obj.GetProperty("recipients")[2].GetProperty("address").GetProperty("header_to").GetString().Should().Be("to1@gmail.com");
        obj.GetProperty("recipients")[3].GetProperty("address").GetProperty("email").GetString().Should().Be("cc2@gmail.com");
        obj.GetProperty("recipients")[3].GetProperty("address").GetProperty("name").GetString().Should().Be("Cc Gmail");
        obj.GetProperty("recipients")[3].GetProperty("address").GetProperty("header_to").GetString().Should().Be("to1@gmail.com");
        
        obj.GetProperty("content").GetProperty("from").GetProperty("email").GetString().Should().Be("from@gmail.com");
        obj.GetProperty("content").GetProperty("from").GetProperty("name").GetString().Should().Be("From Gmail");
        obj.GetProperty("content").GetProperty("subject").GetString().Should().Be("");
        obj.GetProperty("content").GetProperty("headers").GetProperty("cc").GetString().Should().Be("cc1@gmail.com,cc2@gmail.com");
        obj.GetProperty("content").GetProperty("attachments").GetArrayLength().Should().Be(0);
        obj.GetProperty("content").GetProperty("inline_images").GetArrayLength().Should().Be(0);
        
        obj.GetProperty("metadata").ValueKind.Should().Be(JsonValueKind.Object);
        obj.GetProperty("substitution_data").ValueKind.Should().Be(JsonValueKind.Object);
    }

    [Fact]
    public void ParseTransmission_with_bcc_request_returns_expected_result()
    {
        var recipients = new List<Recipient>
        {
            new(new Address("to@gmail.com") { Name = "To Gmail" }),
            new(new Address("bcc@gmail.com") { Name = "Bcc Gmail" }) { Type = RecipientType.Bcc }
        };

        var content = new InlineContent(new SenderAddress("from@gmail.com") { Name = "From Gmail" }, string.Empty);
        var transmission = TransmissionExtensions.CreateTransmission(recipients, content);

        var parsedTransmission = TransmissionExtensions.ParseTransmission(transmission);

        var json = JsonSerializer.Serialize(parsedTransmission,
            JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        json.Should().Contain("\"header_to\": \"to@gmail.com\"");
    }
}