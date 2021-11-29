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
            var images = new List<InlineImage>
            {
                new()
                {
                    Name = "my_image.jpeg",
                    Type = "image/jpeg",
                    Data = "VGhpcyBkb2Vzbid0IGxvb2sgbGlrZSBhIGpwZWcgdG8gbWUh",
                }
            };

            var json = JsonSerializer.Serialize(images, JsonSerializerOptionsExtensions.DefaultJsonSerializerOptions());

            json.Should().Contain("name");
            json.Should().Contain("my_image.jpeg");
        }
    }
}