using System.Reflection;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions.LanguageExt;
using Microsoft.Extensions.Configuration;
using SparkPostFun.Accounts;
using Xunit;

namespace SparkPostFun.Tests;

public class SubaccountTest
{
    [Theory, SubaccountAutoData]
    public async Task ListSubaccounts_returns_expected_result(Client client)
    {
        var result = await client.ListSubaccounts();
        
        result.Should().BeRight();
    }

    private class SubaccountAutoDataAttribute : AutoDataAttribute
    {
        public SubaccountAutoDataAttribute() : base(() => new Fixture().Customize(new Customization()))
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
            var client = new Client(apiKey);

            fixture.Register(() => client);
        }
    }
}