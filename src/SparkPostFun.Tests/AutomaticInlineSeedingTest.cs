using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using FluentAssertions.LanguageExt;
using Microsoft.Extensions.Configuration;
using SparkPostFun.Analytics;
using Xunit;

namespace SparkPostFun.Tests;

public class AutomaticInlineSeedingTest
{
    [Theory(Skip = "The Automatic Inline Seeding API is available to the SparkPost Deliverability Add-On customers only."), AutomaticInlineSeedingAutoData]
    public async Task GetSeedingConfig_returns_expected_result(Client client)
    {
        var response = await client.GetSeedConfig();

        response.Should().BeRight(s => s.Results.Configs.Should().NotBeEmpty());
    }
    
    [Theory(Skip = "The Automatic Inline Seeding API is available to the SparkPost Deliverability Add-On customers only."), AutomaticInlineSeedingAutoData]
    public async Task ListActiveCampaigns_returns_expected_result(Client client)
    {
        var response = await client.ListActiveCampaigns();

        response.Should().BeRight();
    }
    
    [Theory(Skip = "The Automatic Inline Seeding API is available to the SparkPost Deliverability Add-On customers only."), AutomaticInlineSeedingAutoData]
    public async Task GetOptions_returns_expected_result(Client client)
    {
        var response = await client.GetOptions();

        response.Should().BeRight();
    }
    
    private class AutomaticInlineSeedingAutoDataAttribute : AutoDataAttribute
    {
        public AutomaticInlineSeedingAutoDataAttribute() : base(() => new Fixture().Customize(new Customization()))
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