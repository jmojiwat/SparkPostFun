using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit3;
using FluentAssertions.LanguageExt;
using Microsoft.Extensions.Configuration;
using SparkPostFun.Accounts;
using Xunit;
using static System.Reflection.Assembly;

namespace SparkPostFun.Tests;

public class AccountTest
{
    [Theory, AccountAutoData]
    public async Task RetrieveAccount_returns_expected_result(SparkPostEnvironment env)
    {
        var result = await AccountExtensions.RetrieveAccount("usage")(env).IfFailThrow();
        
        result.Should().BeRight();
    }

    private class AccountAutoDataAttribute() : AutoDataAttribute(() => new Fixture().Customize(new Customization()));

    private class Customization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets(GetExecutingAssembly())
                .Build();
            
            var apiKey = configuration.GetSection("SparkPost:ApiKey").Value;
            var httpClient = new HttpClient();
            var env = SparkPostEnvironmentExtension.InitializeEnvironment(httpClient, apiKey);
            fixture.Register(() => env);
        }
    }
}