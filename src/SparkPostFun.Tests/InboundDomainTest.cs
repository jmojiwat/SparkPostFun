using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit3;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.LanguageExt;
using Microsoft.Extensions.Configuration;
using SparkPostFun.Receiving;
using Xunit;

namespace SparkPostFun.Tests;

public class InboundDomainTest
{
    [Theory, InboundDomainAutoData]
    public async Task CreateInboundDomain_returns_expected_result(SparkPostEnvironment env)
    {
        var request = new CreateInboundDomainRequest("indbound.example.com");
        var response = await InboundDomainExtensions.CreateInboundDomain(request)(env).IfFailThrow();

        response.Should().BeRight();
    }

    [Theory, InboundDomainAutoData]
    public async Task RetrieveInboundDomain_returns_expected_result(SparkPostEnvironment env)
    {
        var response = await InboundDomainExtensions.RetrieveInboundDomain("indbound.example.com")(env).IfFailThrow();

        using var scope = new AssertionScope();
        response.Should().BeRight();
        response.IfRight(r => r.Results.Domain.Should().NotBeEmpty());
    }

    [Theory, InboundDomainAutoData]
    public async Task DeleteInboundDomain_returns_expected_result(SparkPostEnvironment env)
    {
        var response = await InboundDomainExtensions.DeleteInboundDomain("indbound.example.com")(env).IfFailThrow();

        response.Should().BeRight();
    }

    [Theory, InboundDomainAutoData]
    public async Task ListInboundDomains_returns_expected_result(SparkPostEnvironment env)
    {
        var response = await InboundDomainExtensions.ListInboundDomains()(env).IfFailThrow();

        using var scope = new AssertionScope();
        response.Should().BeRight();
        response.IfRight(r => r.Results.Should().BeEmpty());
    }

    private class InboundDomainAutoDataAttribute()
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