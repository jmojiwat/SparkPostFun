using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit3;
using FluentAssertions.LanguageExt;
using Microsoft.Extensions.Configuration;
using SparkPostFun.Analytics;
using Xunit;

namespace SparkPostFun.Tests;

public class EventsTest
{
    [Theory, AccountAutoData]
    public async Task RetrieveFirstPage_returns_expected_result(SparkPostEnvironment env)
    {
        var filter = new FirstPageFilter
        {
            PerPage = 1_000
        };
        var result = await EventsExtensions.RetrieveFirstPage(filter)(env).IfFailThrow();
        
        result.Should().BeRight();
    }

    [Theory, AccountAutoData]
    public async Task SearchMessageEvents_returns_expected_result(SparkPostEnvironment env)
    {
        var filter = new SearchMessageEventsFilter
        {
            Recipients = new List<string> { "recipient@example.com" }
        };
        var result = await EventsExtensions.SearchMessageEvents(filter)(env).IfFailThrow();
        
        result.Should().BeRight();
    }

    [Theory(Skip = "error_typessubaccounts used but no specifications in the documentation"), AccountAutoData]
    public async Task SearchIngestEvents_returns_expected_result(SparkPostEnvironment env)
    {
        var filter = new SearchIngestEventsFilter();
        var result = await EventsExtensions.SearchIngestEvents(filter)(env).IfFailThrow();
        
        result.Should().BeRight();
    }

    [Theory, AccountAutoData]
    public async Task EventsDocumentation_returns_expected_result(SparkPostEnvironment env)
    {
        var result = await EventsExtensions.EventsDocumentation()(env).IfFailThrow();
        
        result.Should().BeRight();
    }

    [Theory, AccountAutoData]
    public async Task EventsSamples_returns_expected_result(SparkPostEnvironment env)
    {
        var result = await EventsExtensions.EventsSamples("bounce")(env).IfFailThrow();
        
        result.Should().BeRight();
    }

    private class AccountAutoDataAttribute() : AutoDataAttribute(() => new Fixture().Customize(new Customization()));

    private class Customization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets(Assembly.GetExecutingAssembly())
                .Build();
            
            var apiKey = configuration.GetSection("SparkPost:ApiKey").Value;
            var httpClient = new HttpClient();

            var env = SparkPostEnvironmentExtension.InitializeEnvironment(httpClient, apiKey);

            fixture.Register(() => env);
        }
    }
}