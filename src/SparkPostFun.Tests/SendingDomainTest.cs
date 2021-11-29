using System.Reflection;
using System.Threading.Tasks;
using FluentAssertions.LanguageExt;
using Microsoft.Extensions.Configuration;
using SparkPostFun.Sending;
using Xunit;

namespace SparkPostFun.Tests
{
    public class SendingDomainTest
    {
        [Fact]
        public async Task ListSendingDomains_returns_expected_result()
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets(Assembly.GetExecutingAssembly())
                .Build();
            var apiKey = configuration.GetSection("SparkPost:ApiKey").Value;
            var client = new Client(apiKey);

            var response = await client.ListSendingDomains();

            response.Should().BeRight();

        }
    }
}