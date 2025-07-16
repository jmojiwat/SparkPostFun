using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit3;
using FluentAssertions.LanguageExt;
using Microsoft.Extensions.Configuration;
using SparkPostFun.Sending;
using Xunit;
using static System.Reflection.Assembly;

namespace SparkPostFun.Tests;

public class SnippetTest
{
    [Theory, SnippetAutoData]
    public async Task ListSnippets_returns_expected_result(SparkPostEnvironment env)
    {
        var response = await SnippetExtensions.ListSnippets()(env).IfFailThrow();

        response.Should().BeRight();
    }
    
    private class SnippetAutoDataAttribute() : AutoDataAttribute(() => new Fixture().Customize(new Customization()));

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
                var env = SparkPostEnvironmentExtension.InitializeEnvironment(httpClient, apiKey);
                return env;
            });
        }
    }
}