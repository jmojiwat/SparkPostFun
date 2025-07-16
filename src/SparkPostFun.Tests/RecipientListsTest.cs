using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit3;
using FluentAssertions.LanguageExt;
using Microsoft.Extensions.Configuration;
using SparkPostFun.Sending;
using Xunit;

namespace SparkPostFun.Tests;

public class RecipientListsTest
{
    [Theory, RecipientListsAutoData]
    public async Task ListRecipientLists_returns_expected_result(SparkPostEnvironment env)
    {
        var response = await RecipientListExtensions.ListRecipientLists()(env).IfFailThrow();

        response.Should().BeRight();
    }
    
    private class RecipientListsAutoDataAttribute()
        : AutoDataAttribute(() => new Fixture().Customize(new Customization()));

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
                var env = SparkPostEnvironmentExtension.InitializeEnvironment(httpClient, apiKey);
                return env;
            });
        }
    }
}