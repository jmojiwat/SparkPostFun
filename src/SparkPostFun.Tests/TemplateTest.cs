using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions.LanguageExt;
using Microsoft.Extensions.Configuration;
using SparkPostFun.Sending;
using Xunit;
using static System.Reflection.Assembly;

namespace SparkPostFun.Tests;

public class TemplateTest
{
    [Theory, TemplateAutoData]
    public async Task ListTemplates_returns_expected_result(Client client)
    {
        var response = await client.ListTemplates();

        response.Should().BeRight();
    }

    private class TemplateAutoDataAttribute : AutoDataAttribute
    {
        public TemplateAutoDataAttribute() : base(() => new Fixture().Customize(new Customization()))
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