using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit3;
using FluentAssertions.LanguageExt;
using Microsoft.Extensions.Configuration;
using SparkPostFun.Analytics;
using Xunit;

namespace SparkPostFun.Tests
{
    public class SeedListTest
    {
        [Theory(Skip = "The Seed List API is available to the SparkPost Deliverability Add-On customers only."), SeedListAutoData]
        public async Task RetrieveSeedList_returns_expected_result(SparkPostEnvironment env)
        {
            var response = await SeedListExtensions.RetrieveSeedList()(env).IfFailThrow();

            response.Should().BeRight();
        }
    
        private class SeedListAutoDataAttribute()
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
}