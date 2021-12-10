using System.Net;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using SparkPostFun.Accounts;
using Xunit;
using static System.Reflection.Assembly;

namespace SparkPostFun.ResponseWrappers.Tests;

public class AccountTest
{
    [Theory, AccountAutoData]
    public async Task RetrieveAccountInformation_returns_expected_result(Client client)
    {
        var result = await ResponseExtensions.Wrap(client.RetrieveAccount());
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
                .AddUserSecrets(GetExecutingAssembly())
                .Build();
            
            var apiKey = configuration.GetSection("SparkPost:ApiKey").Value;
            var client = new Client(apiKey);

            fixture.Register(() => client);
        }
    }
}

