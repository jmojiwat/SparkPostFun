using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions.LanguageExt;
using Microsoft.Extensions.Configuration;
using SparkPostFun.Sending;
using Xunit;
using static System.Reflection.Assembly;

namespace SparkPostFun.Tests;

public class AbTestingTest
{
    [Theory, AbTestingAutoData]
    public async Task ListAbTests_returns_expected_result(Client client)
    {
        var response = await client.ListAbTests();

        response.Should().BeRight();
    }

    private class AbTestingAutoDataAttribute : AutoDataAttribute
    {
        public AbTestingAutoDataAttribute() : base(() => new Fixture().Customize(new Customization()))
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
                    .AddUserSecrets(GetExecutingAssembly())
                    .Build();

                var apiKey = configuration.GetSection("SparkPost:ApiKey").Value;
                return new Client(apiKey);
            });
        }
    }
}

