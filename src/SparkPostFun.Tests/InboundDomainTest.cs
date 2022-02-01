using System.Reflection;
using System.Threading.Tasks;
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
        [Fact]
        public async Task CreateInboundDomain_returns_expected_result()
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets(Assembly.GetExecutingAssembly())
                .Build();
            var apiKey = configuration.GetSection("SparkPost:ApiKey").Value;
            var client = new Client(apiKey);

            var request = new CreateInboundDomain("indbound.example.com");
            var response = await client.CreateInboundDomain(request);

            response.Should().BeRight();
        }

        [Fact]
        public async Task RetrieveInboundDomain_returns_expected_result()
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets(Assembly.GetExecutingAssembly())
                .Build();
            var apiKey = configuration.GetSection("SparkPost:ApiKey").Value;
            var client = new Client(apiKey);

            var response = await client.RetrieveInboundDomain("indbound.example.com");

            using var scope = new AssertionScope();
            response.Should().BeRight();
            response.IfRight(r => r.Results.Domain.Should().NotBeEmpty());
        }

        [Fact]
        public async Task DeleteInboundDomain_returns_expected_result()
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets(Assembly.GetExecutingAssembly())
                .Build();
            var apiKey = configuration.GetSection("SparkPost:ApiKey").Value;
            var client = new Client(apiKey);

            var response = await client.DeleteInboundDomain("indbound.example.com");

            response.Should().BeRight();
        }

        [Fact]
        public async Task ListInboundDomains_returns_expected_result()
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets(Assembly.GetExecutingAssembly())
                .Build();
            var apiKey = configuration.GetSection("SparkPost:ApiKey").Value;
            var client = new Client(apiKey);

            var response = await client.ListInboundDomains();

            using var scope = new AssertionScope();
            response.Should().BeRight();
            response.IfRight(r => r.Results.Should().BeEmpty());
        }
    }
}