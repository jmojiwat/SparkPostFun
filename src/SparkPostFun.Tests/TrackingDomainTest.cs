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

public class TrackingDomainTest
{
    [Theory, TrackingDomainAutoData]
    public async Task RetrieveAccountInformation_returns_expected_result(SparkPostEnvironment env)
    {
        var result = await TrackingDomainExtensions.ListTrackingDomains()(env).IfFailThrow();
        result.Should().BeRight();
    }

    private class TrackingDomainAutoDataAttribute()
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