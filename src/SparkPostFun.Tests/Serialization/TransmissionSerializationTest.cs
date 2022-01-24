using System;
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
        
        var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        obj.GetProperty("options").GetProperty("click_tracking").GetBoolean().Should().BeFalse();
        obj.GetProperty("options").GetProperty("transactional").GetBoolean().Should().BeTrue();
        obj.GetProperty("options").GetProperty("ip_pool").GetString().Should().Be("my_ip_pool");
        obj.GetProperty("options").GetProperty("inline_css").GetBoolean().Should().BeTrue();
        
        obj.GetProperty("description").GetString().Should().Be("Christmas Campaign Email");
        obj.GetProperty("campaign_id").GetString().Should().Be("christmas_campaign");

        obj.GetProperty("metadata").GetProperty("user_type").GetString().Should().Be("students");
        obj.GetProperty("metadata").GetProperty("education_level").GetString().Should().Be("college");

        obj.GetProperty("substitution_data").GetProperty("sender").GetString().Should().Be("Big Store Team");
        obj.GetProperty("substitution_data").GetProperty("holiday_name").GetString().Should().Be("Christmas");
        
        obj.GetProperty("recipients")[0].GetProperty("address").GetProperty("email").GetString().Should().Be("wilma@flintstone.com");
        obj.GetProperty("recipients")[0].GetProperty("address").GetProperty("name").GetString().Should().Be("Wilma Flintstone");
        obj.GetProperty("recipients")[0].GetProperty("tags")[0].GetString().Should().Be("prehistoric");

        obj.GetProperty("recipients")[0].GetProperty("metadata").GetProperty("age").GetString().Should().Be("24");
        obj.GetProperty("recipients")[0].GetProperty("metadata").GetProperty("place").GetString().Should().Be("Bedrock");

        obj.GetProperty("recipients")[0].GetProperty("substitution_data").GetProperty("customer_type").GetString().Should().Be("Platinum");
        obj.GetProperty("recipients")[0].GetProperty("substitution_data").GetProperty("year").GetString().Should().Be("Freshman");

        obj.GetProperty("content").ValueKind.Should().Be(JsonValueKind.Object);
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

        var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        
        using var scope = new AssertionScope();
        obj.GetProperty("recipients").GetProperty("list_id").GetString().Should().Be("christmas_sales_2013");
        
        obj.GetProperty("content").GetProperty("from").GetProperty("name").GetString().Should().Be("Our Store");
        obj.GetProperty("content").GetProperty("from").GetProperty("email").GetString().Should().Be("deals@example.com");
        obj.GetProperty("content").GetProperty("subject").GetString().Should().Be("Big Christmas savings!");
        obj.GetProperty("content").GetProperty("text").GetString().Should().Be("Hi {{name}} \nSave big this Christmas in your area {{place}}! \nClick http://www.mysite.com and get huge discount\n Hurry, this offer is only to {{user_type}}\n {{sender}}");
        obj.GetProperty("content").GetProperty("html").GetString().Should().Be("<p>Hi {{name}} \nSave big this Christmas in your area {{place}}! \nClick http://www.mysite.com and get huge discount\n</p><p>Hurry, this offer is only to {{user_type}}\n</p><p>{{sender}}</p>");
    }

    [Fact]
    public void SendInlineContent_request_returns_expected_result()
    {
        var recipient = new Recipient(new Address("wilma@flintstone.com") { Name = "Wilma Flintstone" })
        {
            SubstitutionData = new Dictionary<string, object>
            {
                { "customer_type", "Platinum" }
            }
        };
        var sender = new SenderAddress("fred@flintstone.com") { Name = "Fred Flintstone" };
        var content = new InlineContent(sender, "Big Christmas savings!")
        {
            ReplyTo = "Christmas Sales <sales@flintstone.com>",
            Headers = new Dictionary<string, string>
            {
                { "X-Customer-Campaign-ID", "christmas_campaign" }
            },
            Html = "<p>Hi {{address.name}} \nSave big this Christmas in your area {{place}}! \nClick http://www.mysite.com and get a {{discount}}% discount\n</p><p>Hurry, this offer is only to {{user_type}}\n</p>" 
        };
        
        var request = TransmissionExtensions.CreateTransmission(recipient, content)
            .WithOptions(new TransmissionOptions
            {
                OpenTracking = true,
                ClickTracking = true
            })
            .WithMetadata(new Dictionary<string, object>
            {
                { "user_type", "students" },
                { "education_level", "college" }
            })
            .WithSubstitutionData(new Dictionary<string, object>
            {
                { "discount", "25" }
            });
        
        var json = JsonSerializer.Serialize(request, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        /*
        {
            "options": {
                "open_tracking": true,
                "click_tracking": true
            },
            "metadata": {
                "user_type": "students",
                "education_level": "college"
            },
            "substitution_data": {
                "discount": "25"
            },
            "recipients": [
            {
                "address": {
                    "email": "wilma@flintstone.com",
                    "name": "Wilma Flintstone"
                },
                "substitution_data": {
                    "customer_type": "Platinum",
                }
            }
            ],
            "content": {
                "from": {
                    "name": "Fred Flintstone",
                    "email": "fred@flintstone.com"
                },
                "subject": "Big Christmas savings!",
                "reply_to": "Christmas Sales <sales@flintstone.com>",
                "headers": {
                    "X-Customer-Campaign-ID": "christmas_campaign"
                },
                "html": "<p>Hi {{address.name}} \nSave big this Christmas in your area {{place}}! \nClick http://www.mysite.com and get a {{discount}}% discount\n</p><p>Hurry, this offer is only to {{user_type}}\n</p>"
            }
        }
        */
        var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        
        using var scope = new AssertionScope();
        obj.GetProperty("options").GetProperty("open_tracking").GetBoolean().Should().BeTrue();
        obj.GetProperty("options").GetProperty("click_tracking").GetBoolean().Should().BeTrue();

        obj.GetProperty("metadata").GetProperty("user_type").GetString().Should().Be("students");
        obj.GetProperty("metadata").GetProperty("education_level").GetString().Should().Be("college");

        obj.GetProperty("substitution_data").GetProperty("discount").GetString().Should().Be("25");
        
        obj.GetProperty("recipients")[0].GetProperty("address").GetProperty("email").GetString().Should().Be("wilma@flintstone.com");
        obj.GetProperty("recipients")[0].GetProperty("address").GetProperty("name").GetString().Should().Be("Wilma Flintstone");
        obj.GetProperty("recipients")[0].GetProperty("substitution_data").GetProperty("customer_type").GetString().Should().Be("Platinum");
        
        obj.GetProperty("content").GetProperty("from").GetProperty("name").GetString().Should().Be("Fred Flintstone");
        obj.GetProperty("content").GetProperty("from").GetProperty("email").GetString().Should().Be("fred@flintstone.com");
        
        obj.GetProperty("content").GetProperty("subject").GetString().Should().Be("Big Christmas savings!");
        obj.GetProperty("content").GetProperty("reply_to").GetString().Should().Be("Christmas Sales <sales@flintstone.com>");
        obj.GetProperty("content").GetProperty("headers").GetProperty("X-Customer-Campaign-ID").GetString().Should().Be("christmas_campaign");
        obj.GetProperty("content").GetProperty("html").GetString().Should().Be("<p>Hi {{address.name}} \nSave big this Christmas in your area {{place}}! \nClick http://www.mysite.com and get a {{discount}}% discount\n</p><p>Hurry, this offer is only to {{user_type}}\n</p>");
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
    public void SendTemplateContent_request_returns_expected_result()
    {
        var recipient = new Recipient(new Address("wilma@flintstone.com") { Name = "Wilma Flintstone" })
        {
            SubstitutionData = new Dictionary<string, object>
            {
                { "first_name", "Wilma" },
                { "last_name", "Flintstone" }
            }
        };
        var content = new StoredTemplateContent("black_friday") { UseDraftTemplate = true };
        var transmission = TransmissionExtensions.CreateTransmission(recipient, content)
            .WithSubstitutionData(new Dictionary<string, object>
            {
                { "discount", "25%" }
            });
        
        var json = JsonSerializer.Serialize(transmission, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        /* expected:
        {
            "content": {
                "template_id": "black_friday",
                "use_draft_template": true
            },
            "substitution_data": {
                "discount": "25%"
            },
            "recipients": [
            {
                "address": {
                    "email": "wilma@flintstone.com",
                    "name": "Wilma Flintstone"
                },
                "substitution_data": {
                    "first_name": "Wilma",
                    "last_name": "Flintstone"
                }
            }
            ]
        }        
        */
        
        var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        
        using var scope = new AssertionScope();
        obj.GetProperty("content").GetProperty("template_id").GetString().Should().Be("black_friday");
        obj.GetProperty("content").GetProperty("use_draft_template").GetBoolean().Should().BeTrue();

        obj.GetProperty("substitution_data").GetProperty("discount").GetString().Should().Be("25%");
        
        obj.GetProperty("recipients")[0].GetProperty("address").GetProperty("email").GetString().Should().Be("wilma@flintstone.com");
        obj.GetProperty("recipients")[0].GetProperty("address").GetProperty("name").GetString().Should().Be("Wilma Flintstone");
        obj.GetProperty("recipients")[0].GetProperty("substitution_data").GetProperty("first_name").GetString().Should().Be("Wilma");
        obj.GetProperty("recipients")[0].GetProperty("substitution_data").GetProperty("last_name").GetString().Should().Be("Flintstone");
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
    public void SendTemplateContent_error_response_returns_expected_result()
    {
        const string json = "{                                                                      " +
                            "  \"errors\": [                                                        " +
                            "    {                                                                  " +
                            "      \"message\": \"Subresource not found\",                          " +
                            "      \"description\": \"template 'christmas_offer' does not exist\",  " +
                            "      \"code\": \"1603\"                                               " +
                            "    }                                                                  " +
                            "  ]                                                                    " +
                            "}                                                                      ";
        
        var response = JsonSerializer.Deserialize<ErrorResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        response!.Errors.First().Message.Should().Be("Subresource not found");
        response!.Errors.First().Description.Should().Be("template 'christmas_offer' does not exist");
        response!.Errors.First().Code.Should().Be("1603");
    }

    [Fact]
    public void SendAbTestContent_request_returns_expected_result()
    {
        var content = new AbTestContent("password_reset");
        var recipient = new Recipient(new Address("wilma@flintstone.com") { Name = "Wilma Flintstone" })
        {
            SubstitutionData = new Dictionary<string, object>
            {
                { "first_name", "Wilma" },
                { "last_name", "Flintstone" }
            }
        };
        var transmission = TransmissionExtensions.CreateTransmission(recipient, content);
        
        var json = JsonSerializer.Serialize(transmission, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        /* expected:
        {
            "content": {
                "ab_test_id": "password_reset"
            },
            "recipients": [
            {
                "address": {
                    "email": "wilma@flintstone.com",
                    "name": "Wilma Flintstone"
                },
                "substitution_data": {
                    "first_name": "Wilma",
                    "last_name": "Flintstone"
                }
            }
            ]
        }        
        */
        var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        
        using var scope = new AssertionScope();
        obj.GetProperty("content").GetProperty("ab_test_id").GetString().Should().Be("password_reset");

        obj.GetProperty("recipients")[0].GetProperty("address").GetProperty("email").GetString().Should().Be("wilma@flintstone.com");
        obj.GetProperty("recipients")[0].GetProperty("address").GetProperty("name").GetString().Should().Be("Wilma Flintstone");
        obj.GetProperty("recipients")[0].GetProperty("substitution_data").GetProperty("first_name").GetString().Should().Be("Wilma");
        obj.GetProperty("recipients")[0].GetProperty("substitution_data").GetProperty("last_name").GetString().Should().Be("Flintstone");
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
    public void SendRfc822Content_request_returns_expected_result()
    {
        var recipient = new Recipient(new Address("wilma@flintstone.com") { Name = "Wilma Flintstone" })
        {
            SubstitutionData = new Dictionary<string, object>
            {
                { "first_name", "Wilma" },
                { "customer_type", "Platinum" },
                { "year", "Freshman" }
            }
        };
        var content = new Rfc822TemplateContent
        {
            EmailRfc822 = "Content-Type: text/plain\r\nTo: \"{{address.name}}\" <{{address.email}}>\r\n\r\n Hi {{first_name}} \nSave big this Christmas in your area {{place}}! \nClick http://www.mysite.com and get huge discount\n Hurry, this offer is only to {{customer_type}}\n {{sender}}\r\n" 
        };
        var transmission = TransmissionExtensions.CreateTransmission(recipient, content)
            .WithDescription("Christmas Campaign Email");
        
        var json = JsonSerializer.Serialize(transmission, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        /* expected
        {
            "description": "Christmas Campaign Email",
            "recipients": [
            {
                "address": {
                    "email": "wilma@flintstone.com",
                    "name": "Wilma Flintstone"
                },
                "substitution_data": {
                    "first_name": "Wilma",
                    "customer_type": "Platinum",
                    "year": "Freshman"
                }
            }
            ],
            "content": {
                "email_rfc822": "Content-Type: text/plain\r\nTo: \"{{address.name}}\" <{{address.email}}>\r\n\r\n Hi {{first_name}} \nSave big this Christmas in your area {{place}}! \nClick http://www.mysite.com and get huge discount\n Hurry, this offer is only to {{customer_type}}\n {{sender}}\r\n"
            }
        }
        */
        
        var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        
        using var scope = new AssertionScope();
        obj.GetProperty("description").GetString().Should().Be("Christmas Campaign Email");

        obj.GetProperty("recipients")[0].GetProperty("address").GetProperty("email").GetString().Should().Be("wilma@flintstone.com");
        obj.GetProperty("recipients")[0].GetProperty("address").GetProperty("name").GetString().Should().Be("Wilma Flintstone");
        obj.GetProperty("recipients")[0].GetProperty("substitution_data").GetProperty("first_name").GetString().Should().Be("Wilma");
        obj.GetProperty("recipients")[0].GetProperty("substitution_data").GetProperty("customer_type").GetString().Should().Be("Platinum");
        obj.GetProperty("recipients")[0].GetProperty("substitution_data").GetProperty("year").GetString().Should().Be("Freshman");
        
        obj.GetProperty("content").GetProperty("email_rfc822").GetString().Should().Be("Content-Type: text/plain\r\nTo: \"{{address.name}}\" <{{address.email}}>\r\n\r\n Hi {{first_name}} \nSave big this Christmas in your area {{place}}! \nClick http://www.mysite.com and get huge discount\n Hurry, this offer is only to {{customer_type}}\n {{sender}}\r\n");
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
    public void ScheduleTransmission_request_returns_expected_result()
    {
        var recipient = new StoredRecipientList("all_subscribers");
        var content = new StoredTemplateContent("fall_deals");
        var transmission = TransmissionExtensions.CreateTransmission(recipient, content)
            .WithName("Fall Sale")
            .WithCampaignId("fall")
            .WithOptions(new TransmissionOptions
            {
                StartTime = new DateTimeOffset(2018, 9, 11, 8, 0, 0, TimeSpan.FromHours(-4))
            });
        
        var json = JsonSerializer.Serialize(transmission, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        /* expected:
        {
            "name": "Fall Sale",
            "campaign_id": "fall",
            "options": {
                "start_time": "2018-09-11T08:00:00-04:00"
            },
            "recipients": {
                "list_id": "all_subscribers"
            },
            "content": {
                "template_id": "fall_deals"
            }
        }        
        */
        var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        
        using var scope = new AssertionScope();
        obj.GetProperty("name").GetString().Should().Be("Fall Sale");
        obj.GetProperty("campaign_id").GetString().Should().Be("fall");

        obj.GetProperty("options").GetProperty("start_time").GetDateTimeOffset().Should().Be(new DateTimeOffset(2018, 9, 11, 8, 0, 0, TimeSpan.FromHours(-4)));
        
        obj.GetProperty("recipients").GetProperty("list_id").GetString().Should().Be("all_subscribers");
        obj.GetProperty("content").GetProperty("template_id").GetString().Should().Be("fall_deals");
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
    public void HandleCcAndBccRecipients_with_cc_returns_expected_result()
    {
        var recipients = new List<Recipient>
        {
            new(new Address("to@thisperson.com")),
            new(new Address("cc@thatperson.com")) { Type = RecipientType.Cc }
        };
        var content = new InlineContent("you@fromyou.com", "To and CC")
        {
            Text = "This mail was sent to to@thisperson.com while CCing cc@thatperson.com."
        };
        var transmission = TransmissionExtensions.CreateTransmission(recipients, content);
        var handledTransmission = TransmissionExtensions.HandleCcAndBccRecipients(transmission);
        var json = JsonSerializer.Serialize(handledTransmission,
            JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        
        var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        
        using var scope = new AssertionScope();
        obj.GetProperty("recipients")[0].GetProperty("address").GetProperty("email").GetString().Should().Be("to@thisperson.com");
        obj.GetProperty("recipients")[1].GetProperty("address").GetProperty("email").GetString().Should().Be("cc@thatperson.com");
        obj.GetProperty("recipients")[1].GetProperty("address").GetProperty("header_to").GetString().Should().Be("to@thisperson.com");
        obj.GetProperty("content").GetProperty("from").GetString().Should().Be("you@fromyou.com");
        obj.GetProperty("content").GetProperty("headers").GetProperty("CC").GetString().Should().Be("cc@thatperson.com");
        obj.GetProperty("content").GetProperty("subject").GetString().Should().Be("To and CC");
        obj.GetProperty("content").GetProperty("text").GetString().Should().Be("This mail was sent to to@thisperson.com while CCing cc@thatperson.com.");
    }
    
    [Fact]
    public void HandleCcAndBccRecipients_with_bcc_returns_expected_result()
    {
        var recipients = new List<Recipient>
        {
            new(new Address("to@thisperson.com")),
            new(new Address("bcc@thatperson.com")) { Type = RecipientType.Bcc }
        };
        var content = new InlineContent("you@fromyou.com", "To and BCC")
        {
            Text = "This mail was sent To to@thisperson.com while BCCing an unnamed recipient. Sneaky."
        };
        var transmission = TransmissionExtensions.CreateTransmission(recipients, content);
        var handledTransmission = TransmissionExtensions.HandleCcAndBccRecipients(transmission);
        var json = JsonSerializer.Serialize(handledTransmission,
            JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        
        var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        
        using var scope = new AssertionScope();
        obj.GetProperty("recipients")[0].GetProperty("address").GetProperty("email").GetString().Should().Be("to@thisperson.com");
        obj.GetProperty("recipients")[1].GetProperty("address").GetProperty("email").GetString().Should().Be("bcc@thatperson.com");
        obj.GetProperty("recipients")[1].GetProperty("address").GetProperty("header_to").GetString().Should().Be("to@thisperson.com");
        obj.GetProperty("content").GetProperty("from").GetString().Should().Be("you@fromyou.com");
        obj.GetProperty("content").GetProperty("subject").GetString().Should().Be("To and BCC");
        obj.GetProperty("content").GetProperty("text").GetString().Should().Be("This mail was sent To to@thisperson.com while BCCing an unnamed recipient. Sneaky.");
    }

    [Fact]
    public void HandleCcAndBccRecipients_with_cc_and_bcc_returns_expected_result()
    {
        var recipients = new List<Recipient>
        {
            new(new Address("to@thisperson.com")),
            new(new Address("cc@thatperson.com")) { Type = RecipientType.Cc },
            new(new Address("bcc@thatperson.com")) { Type = RecipientType.Bcc }
        };
        var content = new InlineContent("you@fromyou.com", "To, CC and BCC")
        {
            Text = "This mail was sent To to@thisperson.com while CCing cc@thatperson.com and BCCing an unnamed recipient. You know who you are."
        };
        var transmission = TransmissionExtensions.CreateTransmission(recipients, content);
        var handledTransmission = TransmissionExtensions.HandleCcAndBccRecipients(transmission);
        var json = JsonSerializer.Serialize(handledTransmission,
            JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        
        var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        
        using var scope = new AssertionScope();
        obj.GetProperty("recipients")[0].GetProperty("address").GetProperty("email").GetString().Should().Be("to@thisperson.com");
        
        obj.GetProperty("recipients")[1].GetProperty("address").GetProperty("email").GetString().Should().Be("cc@thatperson.com");
        obj.GetProperty("recipients")[1].GetProperty("address").GetProperty("header_to").GetString().Should().Be("to@thisperson.com");
        
        obj.GetProperty("recipients")[2].GetProperty("address").GetProperty("email").GetString().Should().Be("bcc@thatperson.com");
        obj.GetProperty("recipients")[2].GetProperty("address").GetProperty("header_to").GetString().Should().Be("to@thisperson.com");
        
        obj.GetProperty("content").GetProperty("from").GetString().Should().Be("you@fromyou.com");
        obj.GetProperty("content").GetProperty("headers").GetProperty("CC").GetString().Should().Be("cc@thatperson.com");
        obj.GetProperty("content").GetProperty("subject").GetString().Should().Be("To, CC and BCC");
        obj.GetProperty("content").GetProperty("text").GetString().Should().Be("This mail was sent To to@thisperson.com while CCing cc@thatperson.com and BCCing an unnamed recipient. You know who you are.");
    }
}