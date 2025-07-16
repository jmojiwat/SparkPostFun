using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit3;
using FluentAssertions.LanguageExt;
using Microsoft.Extensions.Configuration;
using SparkPostFun.Accounts;
using Xunit;

namespace SparkPostFun.Tests;

public class SubaccountTest
{
    [Theory, SubaccountAutoData]
    public async Task ListSubaccounts_returns_expected_result(SparkPostEnvironment env)
    {
        var result = await SubaccountExtensions.ListSubaccounts()(env).IfFailThrow();
        
        result.Should().BeRight();
    }

    private class SubaccountAutoDataAttribute()
        : AutoDataAttribute(() => new Fixture().Customize(new Customization()));

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