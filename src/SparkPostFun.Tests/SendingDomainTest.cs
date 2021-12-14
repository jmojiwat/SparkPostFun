using System.Reflection;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions.LanguageExt;
using Microsoft.Extensions.Configuration;
using SparkPostFun.Analytics;
using SparkPostFun.Sending;
using Xunit;

namespace SparkPostFun.Tests;

public class SendingDomainTest
{
    [Theory, SendingDomainAutoData]
    public async Task ListSendingDomains_returns_expected_result(Client client)
    {
        var response = await client.ListSendingDomains();

        response.Should().BeRight();
    }
    
    private class SendingDomainAutoDataAttribute : AutoDataAttribute
    {
        public SendingDomainAutoDataAttribute() : base(() => new Fixture().Customize(new Customization()))
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
                return new Client(apiKey);
            });
        }
    }

}