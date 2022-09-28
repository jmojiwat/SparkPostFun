using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.LanguageExt;
using Microsoft.Extensions.Configuration;
using SparkPostFun.Receiving;
using Xunit;

namespace SparkPostFun.Tests
{
    public class InboundDomainTest
    {
        [Theory, InboundDomainAutoData]
        public async Task CreateInboundDomain_returns_expected_result(Client client)
        {
            var request = new CreateInboundDomain("indbound.example.com");
            var response = await client.CreateInboundDomain(request);

            response.Should().BeRight();
        }

        [Theory, InboundDomainAutoData]
        public async Task RetrieveInboundDomain_returns_expected_result(Client client)
        {
            var response = await client.RetrieveInboundDomain("indbound.example.com");

            using var scope = new AssertionScope();
            response.Should().BeRight();
            response.IfRight(r => r.Results.Domain.Should().NotBeEmpty());
        }

        [Theory, InboundDomainAutoData]
        public async Task DeleteInboundDomain_returns_expected_result(Client client)
        {
            var response = await client.DeleteInboundDomain("indbound.example.com");

            response.Should().BeRight();
        }

        [Theory, InboundDomainAutoData]
        public async Task ListInboundDomains_returns_expected_result(Client client)
        {
            var response = await client.ListInboundDomains();

            using var scope = new AssertionScope();
            response.Should().BeRight();
            response.IfRight(r => r.Results.Should().BeEmpty());
        }

        private class InboundDomainAutoDataAttribute : AutoDataAttribute
        {
            public InboundDomainAutoDataAttribute() : base(() => new Fixture().Customize(new Customization()))
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
}