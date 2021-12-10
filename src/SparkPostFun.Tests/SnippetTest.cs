using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.LanguageExt;
using Microsoft.Extensions.Configuration;
using SparkPostFun.Sending;
using Xunit;
using static System.Reflection.Assembly;

namespace SparkPostFun.Tests;

public class SnippetTest
{
    [Theory(Skip = "Did not define any snippet"), SnippetAutoData]
    public async Task List_returns_expected_result(Client client)
    {
        var response = await client.ListSnippets();

        using var scope = new AssertionScope();
        response.Should().BeRight(s => s.Results.Should().BeEmpty());
    }

    private class SnippetAutoDataAttribute : AutoDataAttribute
    {
        public SnippetAutoDataAttribute() : base(() => new Fixture().Customize(new Customization()))
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