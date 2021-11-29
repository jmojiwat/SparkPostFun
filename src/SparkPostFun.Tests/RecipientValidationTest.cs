using System.Reflection;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.LanguageExt;
using Microsoft.Extensions.Configuration;
using SparkPostFun.Sending;
using Xunit;

namespace SparkPostFun.Tests
{
    public class RecipientValidationTest
    {
        [Fact(Skip = "Need to pay for validation. Not tested.")]
        public async Task EmailAddressValidation_returns_expected_result()
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets(Assembly.GetExecutingAssembly())
                .Build();
            var apiKey = configuration.GetSection("SparkPost:ApiKey").Value;
            var client = new Client(apiKey);

            var response = await client.EmailAddressValidation("jmojiwat@gmail.com");

            using var scope = new AssertionScope();
            response.Should().BeRight();
            response.IfRight(r => r.Results.Valid.Should().BeTrue());
        }
    }
}