using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit3;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.LanguageExt;
using Microsoft.Extensions.Configuration;
using SparkPostFun.Sending;
using Xunit;

namespace SparkPostFun.Tests;

public class RecipientValidationTest
{
    [Theory(Skip = "Need to pay for validation. Not tested."), RecipientValidationAutoData]
    public async Task EmailAddressValidation_returns_expected_result(SparkPostEnvironment env)
    {
        var response = await RecipientValidationExtensions.EmailAddressValidation("jmojiwat@gmail.com")(env).IfFailThrow();

        using var scope = new AssertionScope();
        response.Should().BeRight();
        response.IfRight(r => r.Results.Valid.Should().BeTrue());
    }

    private class RecipientValidationAutoDataAttribute()
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