using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions.LanguageExt;
using Microsoft.Extensions.Configuration;
using SparkPostFun.Sending;
using Xunit;
using static System.Reflection.Assembly;

namespace SparkPostFun.Tests
{
    public class SnippetTest
    {
        [Theory, SnippetAutoData]
        public async Task ListSnippets_returns_expected_result(Client client)
        {
            var response = await client.ListSnippets();

            response.Should().BeRight();
        }
    
        private class SnippetAutoDataAttribute : AutoDataAttribute
        {
            public SnippetAutoDataAttribute() : base(() => new Fixture().Customize(new Customization()))
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