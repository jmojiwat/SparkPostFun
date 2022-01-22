using System.Collections.Generic;
using System.Text.Json;
using FluentAssertions;
using SparkPostFun.Infrastructure;
using SparkPostFun.Sending;
using Xunit;

namespace SparkPostFun.Tests.Serialization
{
    public class InlineImageSerializationTest
    {
        [Fact]
        public void DocumentationExample1_returns_expected_result()
        {
            const string name = "my_image.jpeg";
            const string type = "image/jpeg";
            const string data = "VGhpcyBkb2Vzbid0IGxvb2sgbGlrZSBhIGpwZWcgdG8gbWUh";

            var images = new List<InlineImage>
            {
                new(name, type, data)
            };

            var json = JsonSerializer.Serialize(images, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            json.Should().Contain("name");
            json.Should().Contain("my_image.jpeg");
        }
    }
}