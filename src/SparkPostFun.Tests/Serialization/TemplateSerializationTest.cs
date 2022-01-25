using System;
using System.Collections.Generic;
using System.Text.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using SparkPostFun.Infrastructure;
using SparkPostFun.Sending;
using Xunit;

namespace SparkPostFun.Tests.Serialization;

public class TemplateSerializationTest
{
    [Fact]
    public void CreateTemplate_error_response_returns_expected_result()
    {
        const string json = "{                                                                                             " +
                            "  \"errors\": [                                                                               " +
                            "    {                                                                                         " +
                            "      \"part\": \"text\",                                                                     " +
                            "      \"description\": \"Error while compiling part text: line 4: syntax error near 'age'\",  " +
                            "      \"line\": 4,                                                                            " +
                            "      \"code\": \"3000\",                                                                     " +
                            "      \"message\": \"substitution language syntax error in template content\"                 " +
                            "    }                                                                                         " +
                            "  ]                                                                                           " +
                            "}                                                                                             ";

        var response = JsonSerializer.Deserialize<TemplateErrorResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        response!.Errors[0].Part.Should().Be("text");
        response.Errors[0].Description.Should().Be("Error while compiling part text: line 4: syntax error near 'age'");
        response.Errors[0].Line.Should().Be(4);
        response.Errors[0].Code.Should().Be("3000");
        response.Errors[0].Message.Should().Be("substitution language syntax error in template content");
    }

    [Fact]
    public void CreateTemplate_request_returns_expected_result()
    {
        var content = new CreateTemplateContent(new SenderAddress("marketing@bounces.company.example") { Name = "Example Company Marketing" },
            "Summer deals for {{name}}")
        {
            ReplyTo = "Summer deals <summer_deals@company.example>",
            Text = "Check out these deals {{name}}!",
            Html = "<b>Check out these deals {{name}}!</b>",
            Headers = new Dictionary<string, object>
            {
                { "X-Example-Header", "Summer2014" }
            }
        };
        var request = new CreateTemplate(content)
        {
            Id = "summer_sale",
            Name = "Summer Sale!",
            Published = true,
            Description = "Template for a Summer Sale!",
            SharedWithSubaccounts = false,
            Options = new TemplateOptions
            {
                OpenTracking = false,
                ClickTracking = true
            },
            Content = content
        };
        var json = JsonSerializer.Serialize(request, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        /* expected
          {
            "id": "summer_sale",
            "name": "Summer Sale!",
            "published": true,
            "description": "Template for a Summer Sale!",
            "shared_with_subaccounts": false,
            "options": {
              "open_tracking": false,
              "click_tracking": true
            },
            "content": {
              "from": {
                "email": "marketing@bounces.company.example",
                "name": "Example Company Marketing"
              },
              "subject": "Summer deals for {{name}}",
              "reply_to": "Summer deals <summer_deals@company.example>",
              "text": "Check out these deals {{name}}!",
              "html": "<b>Check out these deals {{name}}!</b>",
              "headers": {
                "X-Example-Header": "Summer2014"
              }
            }
          }
        */

        var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        obj.GetProperty("id").GetString().Should().Be("summer_sale");
        obj.GetProperty("name").GetString().Should().Be("Summer Sale!");
        obj.GetProperty("published").GetBoolean().Should().BeTrue();
        obj.GetProperty("description").GetString().Should().Be("Template for a Summer Sale!");
        obj.GetProperty("shared_with_subaccounts").GetBoolean().Should().BeFalse();
        obj.GetProperty("options").GetProperty("open_tracking").GetBoolean().Should().BeFalse();
        obj.GetProperty("options").GetProperty("click_tracking").GetBoolean().Should().BeTrue();
        obj.GetProperty("content").GetProperty("from").GetProperty("email").GetString().Should().Be("marketing@bounces.company.example");
        obj.GetProperty("content").GetProperty("from").GetProperty("name").GetString().Should().Be("Example Company Marketing");
        obj.GetProperty("content").GetProperty("subject").GetString().Should().Be("Summer deals for {{name}}");
        obj.GetProperty("content").GetProperty("reply_to").GetString().Should().Be("Summer deals <summer_deals@company.example>");
        obj.GetProperty("content").GetProperty("text").GetString().Should().Be("Check out these deals {{name}}!");
        obj.GetProperty("content").GetProperty("html").GetString().Should().Be("<b>Check out these deals {{name}}!</b>");
        obj.GetProperty("content").GetProperty("headers").GetProperty("X-Example-Header").GetString().Should().Be("Summer2014");
    }

    [Fact]
    public void CreateTemplate_response_returns_expected_result()
    {
        const string json = "{                            " +
                            "  \"results\": {             " +
                            "    \"id\": \"summer_sale\"  " +
                            "  }                          " +
                            "}                            ";

        var response = JsonSerializer.Deserialize<CreateTemplateResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        response!.Results.Id.Should().Be("summer_sale");
    }

    [Fact]
    public void PreviewTemplate_request_returns_expected_result()
    {
        var request = new PreviewTemplate
        {
            SubstitutionData = new Dictionary<string, object>
            {
                { "name", "Natalie" },
                { "age", 35 },
                { "member", true }
            }
        };
        var json = JsonSerializer.Serialize(request, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        /* expected
          {
            "substitution_data": {
              "name": "Natalie",
              "age": 35,
              "member": true
            }
          }
        */

        var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        obj.GetProperty("substitution_data").GetProperty("name").GetString().Should().Be("Natalie");
        obj.GetProperty("substitution_data").GetProperty("age").GetInt32().Should().Be(35);
        obj.GetProperty("substitution_data").GetProperty("member").GetBoolean().Should().BeTrue();
    }

    [Fact]
    public void PreviewTemplate_response_returns_expected_result()
    {
        const string json = "{                                                                   " +
                            "  \"results\": {                                                    " +
                            "    \"from\": {                                                     " +
                            "      \"email\": \"marketing@bounces.company.example\",             " +
                            "      \"name\": \"Example Company Marketing\"                       " +
                            "    },                                                              " +
                            "    \"subject\": \"Summer deals for Natalie\",                      " +
                            "    \"reply_to\": \"Summer deals <summer_deals@company.example>\",  " +
                            "    \"text\": \"Check out these deals Natalie!\",                   " +
                            "    \"html\": \"<b>Check out these deals Natalie!</b>\",            " +
                            "    \"headers\": {                                                  " +
                            "      \"X-Example-Header\": \"Summer2018\"                          " +
                            "    }                                                               " +
                            "  }                                                                 " +
                            "}                                                                   ";
        
        var response = JsonSerializer.Deserialize<PreviewTemplateResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        var sender = TemplateExtensions.ParseTemplateContentFrom(response!.Results);
        sender.Email.Should().Be("marketing@bounces.company.example");
        sender.Name.Should().Be("Example Company Marketing");
        
        response.Results.Subject.Should().Be("Summer deals for Natalie");
        response.Results.ReplyTo.Should().Be("Summer deals <summer_deals@company.example>");
        response.Results.Text.Should().Be("Check out these deals Natalie!");
        response.Results.Html.Should().Be("<b>Check out these deals Natalie!</b>");
        response.Results.Headers.Should().ContainKey("X-Example-Header");
        response.Results.Headers["X-Example-Header"].Should().Be("Summer2018");
    }

    [Fact]
    public void PublishDraftTemplate_request_returns_expected_result()
    {
        var request = new PublishTemplateDraft();

        var json = JsonSerializer.Serialize(request, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        /* expected
          {
            "published": true
          }
        */

        var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        obj.GetProperty("published").GetBoolean().Should().BeTrue();
    }

    [Fact]
    public void RetrieveTemplate_response_returns_expected_result()
    {
        const string json = "{                                                                    " +
                            "  \"results\": {                                                     " +
                            "    \"id\": \"summer_sale\",                                         " +
                            "    \"name\": \"Summer Sale!\",                                      " +
                            "    \"description\": \"\",                                           " +
                            "    \"has_draft\": true,                                             " +
                            "    \"has_published\": true,                                         " +
                            "    \"published\": false,                                            " +
                            "    \"shared_with_subaccounts\": false,                              " +
                            "    \"last_update_time\": \"2014-05-22T15:12:59+00:00\",             " +
                            "    \"last_use\": \"2014-06-02T08:15:30+00:00\",                     " +
                            "    \"options\": {                                                   " +
                            "      \"open_tracking\": false,                                      " +
                            "      \"click_tracking\": true,                                      " +
                            "      \"transactional\": false                                       " +
                            "    },                                                               " +
                            "    \"content\": {                                                   " +
                            "      \"from\": {                                                    " +
                            "        \"email\": \"marketing@bounces.company.example\",            " +
                            "        \"name\": \"Example Company Marketing\"                      " +
                            "      },                                                             " +
                            "      \"subject\": \"Summer deals for {{name}}\",                    " +
                            "      \"reply_to\": \"Summer deals <summer_deals@company.example>\", " +
                            "      \"text\": \"Check out these deals {{name}}!\",                 " +
                            "      \"html\": \"<b>Check out these deals {{name}}!</b>\",          " +
                            "      \"headers\": {                                                 " +
                            "        \"X-Example-Header\": \"Summer2014\"                         " +
                            "      }                                                              " +
                            "    }                                                                " +
                            "  }                                                                  " +
                            "}                                                                    ";

        var response = JsonSerializer.Deserialize<RetrieveTemplateResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        response!.Results.Id.Should().Be("summer_sale");
        response.Results.Name.Should().Be("Summer Sale!");
        response.Results.Description.Should().Be("");
        response.Results.HasDraft.Should().BeTrue();
        response.Results.HasPublished.Should().BeTrue();
        response.Results.Published.Should().BeFalse();
        response.Results.SharedWithSubaccounts.Should().BeFalse();
        response.Results.LastUpdateTime.Should().Be(new DateTimeOffset(2014, 5, 22, 15, 12, 59, TimeSpan.Zero));
        response.Results.LastUse.Should().Be(new DateTimeOffset(2014, 6, 2, 8, 15, 30, TimeSpan.Zero));

        response.Results.Options.OpenTracking.Should().BeFalse();
        response.Results.Options.ClickTracking.Should().BeTrue();
        response.Results.Options.Transactional.Should().BeFalse();

        var sender = TemplateExtensions.ParseTemplateContentFrom(response.Results.Content);
        sender.Email.Should().Be("marketing@bounces.company.example");
        sender.Name.Should().Be("Example Company Marketing");
        response.Results.Content.Subject.Should().Be("Summer deals for {{name}}");
        response.Results.Content.ReplyTo.Should().Be("Summer deals <summer_deals@company.example>");
        response.Results.Content.Text.Should().Be("Check out these deals {{name}}!");
        response.Results.Content.Html.Should().Be("<b>Check out these deals {{name}}!</b>");
        response.Results.Content.Headers.Should().ContainKey("X-Example-Header");
        response.Results.Content.Headers["X-Example-Header"].Should().Be("Summer2014");
    }

    [Fact]
    public void ListTemplates_response_returns_expected_result()
    {
        const string json = "{                                                               " +
                            "  \"results\": [                                                " +
                            "      {                                                         " +
                            "          \"id\": \"summer_sale\",                              " +
                            "          \"name\": \"Summer Sale!\",                           " +
                            "          \"published\": false,                                 " +
                            "          \"description\": \"\",                                " +
                            "          \"has_draft\": true,                                  " +
                            "          \"has_published\": true,                              " +
                            "          \"last_update_time\": \"2017-08-11T12:12:12+00:00\",  " +
                            "          \"shared_with_subaccounts\": true                     " +
                            "      },                                                        " +
                            "      {                                                         " +
                            "          \"id\": \"daily\",                                    " +
                            "          \"name\": \"daily\",                                  " +
                            "          \"published\": false,                                 " +
                            "          \"description\": \"Daily roundup email.\",            " +
                            "          \"has_draft\": true,                                  " +
                            "          \"has_published\": true,                              " +
                            "          \"last_use\": \"2018-05-08T14:49:03+00:00\",          " +
                            "          \"last_update_time\": \"2018-02-10T14:15:16+00:00\",  " +
                            "          \"shared_with_subaccounts\": true                     " +
                            "      }                                                         " +
                            "  ]                                                             " +
                            "}                                                               ";

        var response = JsonSerializer.Deserialize<ListTemplatesResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        response!.Results[0].Id.Should().Be("summer_sale");
        response.Results[0].Name.Should().Be("Summer Sale!");
        response.Results[0].Published.Should().BeFalse();
        response.Results[0].Description.Should().Be("");
        response.Results[0].HasDraft.Should().BeTrue();
        response.Results[0].HasPublished.Should().BeTrue();
        response.Results[0].LastUpdateTime.Should().Be(new DateTimeOffset(2017, 8, 11, 12, 12, 12, TimeSpan.Zero));
        response.Results[0].SharedWithSubaccounts.Should().BeTrue();

        response.Results[1].Id.Should().Be("daily");
        response.Results[1].Name.Should().Be("daily");
        response.Results[1].Published.Should().BeFalse();
        response.Results[1].Description.Should().Be("Daily roundup email.");
        response.Results[1].HasDraft.Should().BeTrue();
        response.Results[1].HasPublished.Should().BeTrue();
        response.Results[1].LastUse.Should().Be(new DateTimeOffset(2018, 5, 8, 14, 49, 3, TimeSpan.Zero));
        response.Results[1].LastUpdateTime.Should().Be(new DateTimeOffset(2018, 2, 10, 14, 15, 16, TimeSpan.Zero));
        response.Results[1].SharedWithSubaccounts.Should().BeTrue();
    }

    [Fact]
    public void UpdateDraftTemplate_request_returns_expected_result()
    {
        var content = new UpdateTemplateContent(
            new SenderAddress("marketing@bounces.company.example") { Name = "Example Company Marketing" },
            "Updated Summer deals for {{name}}")
        {
            ReplyTo = "Summer deals <summer_deals@company.example>",
            Text = "Updated: Check out these deals {{name}}!",
            Html = "<b>Updated: Check out these deals {{name}}!</b>"
        };
        var request = new UpdateTemplate
        {
            Options = new TemplateOptions
            {
                OpenTracking = true
            },
            Name = "A new name!",
            SharedWithSubaccounts = true,
            Content = content
        };
        var json = JsonSerializer.Serialize(request, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        /* expected
          {
            "options": {
              "open_tracking": true
            },
            "name": "A new name!",
            "shared_with_subaccounts": true,
            "content": {
              "from": {
                "email": "marketing@bounces.company.example",
                "name": "Example Company Marketing"
              },
              "subject": "Updated Summer deals for {{name}}",
              "reply_to": "Summer deals <summer_deals@company.example>",
              "text": "Updated: Check out these deals {{name}}!",
              "html": "<b>Updated: Check out these deals {{name}}!</b>"
            }
          }
        */

        var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        obj.GetProperty("options").GetProperty("open_tracking").GetBoolean().Should().BeTrue();

        obj.GetProperty("name").GetString().Should().Be("A new name!");
        obj.GetProperty("shared_with_subaccounts").GetBoolean().Should().BeTrue();

        obj.GetProperty("content").GetProperty("from").GetProperty("email").GetString().Should().Be("marketing@bounces.company.example");
        obj.GetProperty("content").GetProperty("from").GetProperty("name").GetString().Should().Be("Example Company Marketing");
        obj.GetProperty("content").GetProperty("subject").GetString().Should().Be("Updated Summer deals for {{name}}");
        obj.GetProperty("content").GetProperty("reply_to").GetString().Should().Be("Summer deals <summer_deals@company.example>");
        obj.GetProperty("content").GetProperty("text").GetString().Should().Be("Updated: Check out these deals {{name}}!");
        obj.GetProperty("content").GetProperty("html").GetString().Should().Be("<b>Updated: Check out these deals {{name}}!</b>");
    }

    [Fact]
    public void UpdatePublishedTemplate_request_returns_expected_result()
    {
        var content = new UpdateTemplateContent(
            new SenderAddress("marketing@bounces.company.example") { Name = "Example Company Marketing" },
            "Updated Summer deals for {{name}}")
        {
            ReplyTo = "Summer deals <summer_deals@company.example>",
            Text = "Updated: Check out these deals {{name}}!",
            Html = "<b>Updated: Check out these deals {{name}}!</b>"
        };
        var request = new UpdatePublishedTemplate
        {
            Options = new TemplateOptions
            {
                OpenTracking = true
            },
            Name = "A new name!",
            SharedWithSubaccounts = true,
            Content = content
        };
        var json = JsonSerializer.Serialize(request, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        /* expected
          {
            "options": {
              "open_tracking": true
            },
            "name": "A new name!",
            "shared_with_subaccounts": true,
            "content": {
              "from": {
                "email": "marketing@bounces.company.example",
                "name": "Example Company Marketing"
              },
              "subject": "Updated Summer deals for {{name}}",
              "reply_to": "Summer deals <summer_deals@company.example>",
              "text": "Updated: Check out these deals {{name}}!",
              "html": "<b>Updated: Check out these deals {{name}}!</b>"
            }
          }
        */

        var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        obj.GetProperty("options").GetProperty("open_tracking").GetBoolean().Should().BeTrue();

        obj.GetProperty("name").GetString().Should().Be("A new name!");
        obj.GetProperty("shared_with_subaccounts").GetBoolean().Should().BeTrue();

        obj.GetProperty("content").GetProperty("from").GetProperty("email").GetString().Should().Be("marketing@bounces.company.example");
        obj.GetProperty("content").GetProperty("from").GetProperty("name").GetString().Should().Be("Example Company Marketing");
        obj.GetProperty("content").GetProperty("subject").GetString().Should().Be("Updated Summer deals for {{name}}");
        obj.GetProperty("content").GetProperty("reply_to").GetString().Should().Be("Summer deals <summer_deals@company.example>");
        obj.GetProperty("content").GetProperty("text").GetString().Should().Be("Updated: Check out these deals {{name}}!");
        obj.GetProperty("content").GetProperty("html").GetString().Should().Be("<b>Updated: Check out these deals {{name}}!</b>");
    }
    
    [Fact]
    public void CreateRfc822Template_request_returns_expected_result()
    {
        var request = new CreateRfc822Template
        {
            Id = "another_summer_sale",
            Name = "Summer Sale!",
            Published = true,
            Options = new TemplateOptions
            {
                OpenTracking = false,
                ClickTracking = true
            },
            Content = new CreateRfc822TemplateContent
            {
                EmailRfc822 = "Content-Type: text/plain\nFrom: Example Company Marketing <marketing@bounces.company.example>\nReply-To:Summer deals <summer_deals@company.example>\nX-Example-Header: Summer2014\nSubject: Summer deals for {{name}}\n\nCheck out these deals {{name}}!" 
            }
        };

        var json = JsonSerializer.Serialize(request, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        /* expected
            {
              "id": "another_summer_sale",
              "name": "Summer Sale!",
              "published": true,
              "options": {
                "open_tracking": false,
                "click_tracking": true
              },
              "content": {
                "email_rfc822": "Content-Type: text/plain\nFrom: Example Company Marketing <marketing@bounces.company.example>\nReply-To:Summer deals <summer_deals@company.example>\nX-Example-Header: Summer2014\nSubject: Summer deals for {{name}}\n\nCheck out these deals {{name}}!"
              }
            }
        */

        var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        obj.GetProperty("id").GetString().Should().Be("another_summer_sale");
        obj.GetProperty("name").GetString().Should().Be("Summer Sale!");
        obj.GetProperty("published").GetBoolean().Should().BeTrue();
        obj.GetProperty("options").GetProperty("open_tracking").GetBoolean().Should().BeFalse();
        obj.GetProperty("options").GetProperty("click_tracking").GetBoolean().Should().BeTrue();
        obj.GetProperty("content").GetProperty("email_rfc822").GetString().Should().Be("Content-Type: text/plain\nFrom: Example Company Marketing <marketing@bounces.company.example>\nReply-To:Summer deals <summer_deals@company.example>\nX-Example-Header: Summer2014\nSubject: Summer deals for {{name}}\n\nCheck out these deals {{name}}!");
    }

    [Fact]
    public void CreateRfc822Template_response_returns_expected_result()
    {
        const string json = "{                                    " +
                            "  \"results\": {                     " +
                            "    \"id\": \"another_summer_sale\"  " +
                            "  }                                  " +
                            "}                                    ";

        var response = JsonSerializer.Deserialize<CreateTemplateResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        response!.Results.Id.Should().Be("another_summer_sale");
    }

    [Fact]
    public void PreviewInlineTemplate_request_returns_expected_result()
    {
        var content = new TemplateContent
        {
            From = "sandbox@sparkpostbox.com",
            Subject = "Summer deals for {{name}}",
            Html = "<b>Check out these deals {{name}}!</b>"
        };
        var request = new PreviewInlineTemplate
        {
            SubstitutionData = new Dictionary<string, object>
            {
                { "name", "Natalie" },
                { "age", 35 },
                { "member", true }
            },
            Content = content
        };

        var json = JsonSerializer.Serialize(request, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());
        /* expected
            {
              "substitution_data": {
                "name": "Natalie",
                "age": 35,
                "member": true
              },
              "content": {
                "from": "sandbox@sparkpostbox.com",
                "subject": "Summer deals for {{name}}",
                "html": "<b>Check out these deals {{name}}!</b>"
              }
            }
        */

        var obj = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        using var scope = new AssertionScope();
        obj.GetProperty("substitution_data").GetProperty("name").GetString().Should().Be("Natalie");
        obj.GetProperty("substitution_data").GetProperty("age").GetInt32().Should().Be(35);
        obj.GetProperty("substitution_data").GetProperty("member").GetBoolean().Should().BeTrue();
        
        obj.GetProperty("content").GetProperty("from").GetString().Should().Be("sandbox@sparkpostbox.com");
        obj.GetProperty("content").GetProperty("subject").GetString().Should().Be("Summer deals for {{name}}");
        obj.GetProperty("content").GetProperty("html").GetString().Should().Be("<b>Check out these deals {{name}}!</b>");
    }

    [Fact]
    public void PreviewInlineTemplate_response_returns_expected_result()
    {
        const string json = "{                                                        " +
                            "  \"results\": {                                         " +
                            "    \"subject\": \"Summer deals for Natalie\",           " +
                            "    \"html\": \"<b>Check out these deals Natalie!</b>\"  " +
                            "  }                                                      " +
                            "}                                                        ";

        var response = JsonSerializer.Deserialize<PreviewTemplateResponse>(json, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

        response!.Results.Subject.Should().Be("Summer deals for Natalie");
        response!.Results.Html.Should().Be("<b>Check out these deals Natalie!</b>");
    }
}