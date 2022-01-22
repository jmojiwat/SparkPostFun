using System.Collections.Generic;
using System.Text.Json;
using FluentAssertions;
using SparkPostFun.Infrastructure;
using SparkPostFun.Sending;
using Xunit;

namespace SparkPostFun.Tests.Serialization
{
    public class AttachmentSerializationTest
    {
        [Fact]
        public void DocumentationExample1_returns_expected_result()
        {
            const string name = "billing.pdf";
            const string type = "application/pdf";
            const string data = "Q29uZ3JhdHVsYXRpb25zLCB5b3UgY2FuIGJhc2U2NCBkZWNvZGUh";
            var attachments = new List<Attachment>
            {
                new(name, type, data)
            };

            var json = JsonSerializer.Serialize(attachments,
                JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            json.Should().Contain("name");
            json.Should().Contain("billing.pdf");
        }
    }
}