using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions.LanguageExt;
using Microsoft.Extensions.Configuration;
using SparkPostFun.Sending;
using Xunit;

namespace SparkPostFun.Tests;

public class SuppressionListTest
{
    [Theory, SuppresionListAutoData]
    public async Task RetrieveSummary_returns_expected_result(Client client)
    {
        var response = await client.RetrieveSuppressionSummary();

        response.Should().BeRight();
    }
    
    private class SuppresionListAutoDataAttribute : AutoDataAttribute
    {
        public SuppresionListAutoDataAttribute() : base(() => new Fixture().Customize(new Customization()))
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
                    .AddUserSecrets(Assembly.GetExecutingAssembly())
                    .Build();

                var apiKey = configuration.GetSection("SparkPost:ApiKey").Value;
                var httpClient = new HttpClient();
                var client = new Client(httpClient, apiKey);
                return client;
            });
        }
    }
}