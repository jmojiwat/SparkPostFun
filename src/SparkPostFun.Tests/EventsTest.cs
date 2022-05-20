using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions.LanguageExt;
using Microsoft.Extensions.Configuration;
using SparkPostFun.Analytics;
using Xunit;

namespace SparkPostFun.Tests;

public class EventsTest
{
    [Theory, AccountAutoData]
    public async Task RetrieveFirstPage_returns_expected_result(Client client)
    {
        var filter = new FirstPageFilter
        {
            PerPage = 1_000
        };
        var result = await client.RetrieveFirstPage(filter);
        
        result.Should().BeRight();
    }

    [Theory, AccountAutoData]
    public async Task SearchMessageEvents_returns_expected_result(Client client)
    {
        var filter = new SearchMessageEventsFilter
        {
            Recipients = new List<string> { "recipient@example.com" }
        };
        var result = await client.SearchMessageEvents(filter);
        
        result.Should().BeRight();
    }

    [Theory(Skip = "error_typessubaccounts used but no specifications in the documentation"), AccountAutoData]
    public async Task SearchIngestEvents_returns_expected_result(Client client)
    {
        var filter = new SearchIngestEventsFilter();
        var result = await client.SearchIngestEvents(filter);
        
        result.Should().BeRight();
    }

    [Theory, AccountAutoData]
    public async Task EventsDocumentation_returns_expected_result(Client client)
    {
        var result = await client.EventsDocumentation();
        
        result.Should().BeRight();
    }

    [Theory, AccountAutoData]
    public async Task EventsSamples_returns_expected_result(Client client)
    {
        var result = await client.EventsSamples("bounce");
        
        result.Should().BeRight();
    }

    private class AccountAutoDataAttribute : AutoDataAttribute
    {
        public AccountAutoDataAttribute() : base(() => new Fixture().Customize(new Customization()))
        {
        }
    }

    private class Customization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets(Assembly.GetExecutingAssembly())
                .Build();
            
            var apiKey = configuration.GetSection("SparkPost:ApiKey").Value;
            var httpClient = new HttpClient();
            var client = new Client(httpClient, apiKey);

            fixture.Register(() => client);
        }
    }
}