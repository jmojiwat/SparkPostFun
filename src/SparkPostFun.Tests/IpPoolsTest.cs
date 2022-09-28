using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions.LanguageExt;
using Microsoft.Extensions.Configuration;
using SparkPostFun.Sending;
using Xunit;

namespace SparkPostFun.Tests
{
    public class IpPoolsTest
    {
        [Theory, IpPoolsAutoData]
        public async Task ListSendingIps_returns_expected_result(Client client)
        {
            var response = await client.ListIpPools();

            response.Should().BeRight();
        }
    
        private class IpPoolsAutoDataAttribute : AutoDataAttribute
        {
            public IpPoolsAutoDataAttribute() : base(() => new Fixture().Customize(new Customization()))
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
}