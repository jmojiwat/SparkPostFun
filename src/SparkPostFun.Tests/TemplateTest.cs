using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using FluentAssertions.LanguageExt;
using Microsoft.Extensions.Configuration;
using SparkPostFun.Sending;
using Xunit;
using static System.Reflection.Assembly;

namespace SparkPostFun.Tests
{
    public class TemplateTest
    {
        [Fact]
        public void ParseTemplateContentFrom_with_SenderAddress_returns_expected_result()
        {
            var sender = new SenderAddress("abc@example.com");
            var template = new TemplateContent
            {
                From = sender
            };
        
            var result = TemplateExtensions.ParseTemplateContentFrom(template);
        
            result.Should().Be(new SenderAddress("abc@example.com"));
        }
    
        [Fact]
        public void ParseTemplateContentFrom_with_string_returns_expected_result()
        {
            var template = new TemplateContent
            {
                From = "abc@example.com"
            };
        
            var result = TemplateExtensions.ParseTemplateContentFrom(template);
        
            result.Should().Be(new SenderAddress("abc@example.com"));
        }
    
        [Theory, TemplateAutoData]
        public async Task ListTemplates_returns_expected_result(Client client)
        {
            var response = await client.ListTemplates();

            response.Should().BeRight();
        }

        private class TemplateAutoDataAttribute : AutoDataAttribute
        {
            public TemplateAutoDataAttribute() : base(() => new Fixture().Customize(new Customization()))
            {
            }
        }

        private class Customization : ICustomization
        {
            public void Customize(IFixture fixture)
            {
                fixture.Register(() =>
                {
                    var configuration = new ConfigurationBuilder()
                        .AddUserSecrets(GetExecutingAssembly())
                        .Build();

                    var apiKey = configuration.GetSection("SparkPost:ApiKey").Value;
                    var httpClient = new HttpClient();
                    var client = new Client(httpClient, apiKey);
                    return client;
                });
            }
        }

    }
}