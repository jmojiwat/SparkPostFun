using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using SparkPostFun.Accounts;
using SparkPostFun.Sending;
using Xunit;

namespace SparkPostFun.ResponseWrappers.Tests;

public class AbTestingTest
{
    [Theory, AccountAutoData]
    public async Task RetrieveAccountInformation_returns_expected_result(Client client)
    {
        var result = await SendingResponseExtensions.Wrap(client.ListAbTests());
        result.StatusCode.Should().Be(HttpStatusCode.OK);
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